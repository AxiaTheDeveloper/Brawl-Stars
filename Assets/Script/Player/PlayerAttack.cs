using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IAttackShoot{
    public void Attack(LineRenderer line, RaycastHit hit, Transform siAttack, float trailDistance){}
    
}

public interface IAttackThrow{
    public void Attack(LineRenderer line, Vector2 keyInputAttack, float LinePower_Y, float check, Vector3[] bulletPoints){}
    
}

public class Shoot : IAttackShoot{
    
    public void Attack(LineRenderer line, RaycastHit hit, Transform siAttack, float trailDistance){
        

        if(Physics.Raycast(siAttack.position, siAttack.forward, out hit, trailDistance)){
            line.SetPosition(1,hit.point);
            // Debug.Log("yey");3
        }else{
            line.SetPosition(1,siAttack.position + siAttack.forward * trailDistance);
            line.SetPosition(1, new Vector3(line.GetPosition(1).x, 4.2f,line.GetPosition(1).z));
            // Debug.Log("boom");
        }
        
    }
}

public class Throw : IAttackThrow{
    public void Attack(LineRenderer line, Vector2 keyInputAttack, float LinePower_Y, float check, Vector3[] bulletPoints){
        
        
        for(int i = 1; i < 10; i++){
            line.SetPosition(i, new Vector3((line.GetPosition(i-1).x + keyInputAttack.x*check),i == 1? 4.4f+5 : (float)Math.Cos(LinePower_Y * (i*0.1f)) * (i*0.5f)*(check+3) + 4.2f, (line.GetPosition(i-1).z+keyInputAttack.y*check)));
            // Debug.Log(line.GetPosition(i-1));
            // Debug.Log(keyInputAttack);

            bulletPoints[i-1] = line.GetPosition(i);

        }
        
    }
}

public class PlayerAttack : MonoBehaviour
{
    public enum AttackType{
        Shoot, Throw
    }
    public AttackType type;

    private IAttackShoot shoot;
    private IAttackThrow throws;

    [SerializeField]private float check;


    [SerializeField]private LineRenderer line;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private Transform bulletSpawnPlace;
    private Vector2 keyInputAttack = new Vector2 (0,0);
    private Vector3 arahPerpindahan = new Vector3(0,0,0);

    [SerializeField]private float trailDistance;
    private bool IsAttack, canShoot, checkShootOnce;
    [SerializeField]private Transform Player;
    private RaycastHit hit;


    //Shoot
    [SerializeField]private BulletPool bulletPool;
    [SerializeField]private float bulletSpawnWait, canShootAgainWait;
    
    [SerializeField]private GameObject prefabBullet;
    private GameObject theBullet;


    

    public event EventHandler OnAnimasiShoot, OnAnimasiThrow;

    //THROWWW
    public Vector3[] bulletPoints;
    [SerializeField]private float LinePower_Y;


    //buat identitas bulet;
    
    [SerializeField]private PlayerIdentity playerIdentity;
    // Update is called once per frame
    private void Awake() {
        shoot = new Shoot();
        throws = new Throw();
    }
    private void Start() {
        gameInput.OnShoot += gameInput_OnShoot;
        
        checkShootOnce = true;
        if(type == AttackType.Shoot){
            line.positionCount = 2;
        }
        if(type == AttackType.Throw){
            line.positionCount = 10;
            bulletPoints = new Vector3[9];
        }
        
    }
    void Update()
    {
        if(BrawlGameManager.Instance.IsGameStart()){
            if(type == AttackType.Shoot){
            // Debug.Log("itu");
            keyInputAttack = gameInput.GetInputAttackNormalized();
            }
            if(type == AttackType.Throw){
                // Debug.Log("ini");
                keyInputAttack = gameInput.GetInputAttack();
            }
            
            
            IsAttack = keyInputAttack != Vector2.zero;
            // Debug.Log(IsAttack);
            // Debug.Log
            line.enabled = IsAttack;
            canShoot = IsAttack;
            transform.position = new Vector3(Player.position.x,4.2f,Player.position.z);
            
            

            arahPerpindahan.Set(keyInputAttack.x,0f, keyInputAttack.y);
            // Debug.Log(keyInputAttack);
            // transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            line.SetPosition(0,new Vector3(transform.position.x, 4.2f, transform.position.z));
            if(type == AttackType.Shoot){
                shoot.Attack(line,hit,transform,trailDistance);
            }
            if(type == AttackType.Throw){
                throws.Attack(line,keyInputAttack, LinePower_Y,check, bulletPoints);
            }
        }
        
    }

    private void gameInput_OnShoot(object sender, System.EventArgs e){
        if(canShoot && checkShootOnce){
            checkShootOnce = false;
            
            Debug.Log("pew pew");
            // totalBulletSave = totalBullet;
            if(type == AttackType.Shoot){
                OnAnimasiShoot?.Invoke(this,EventArgs.Empty);
                StartCoroutine(BulletSpawn());
            }
            if(type == AttackType.Throw){
                OnAnimasiThrow?.Invoke(this,EventArgs.Empty);
                theBullet = Instantiate(prefabBullet);
                theBullet.GetComponent<BulletThrow>().SetTrail(this, playerIdentity);
                theBullet.transform.position = bulletPoints[0];
                // checkShootOnce= true;
            }
            
            canShoot = false;
        }
    }


    
    public bool GetIsAttack(){
        return IsAttack;
    }

    public Vector3 GetArahPerpindahanAttack(){
        return arahPerpindahan;
    }
    public float GetTrailDistance(){
        return trailDistance;
    }
    private IEnumerator BulletSpawn(){
        // while(totalBulletSave > 0){
        //     theBullet = Instantiate(prefabBullet, bulletSpawnPlace.position, transform.rotation);
        //     theBullet.GetComponent<Bullet>().changeBulletDistanceMati(trailDistance,arahPerpindahan);
        //     totalBulletSave--;
        //     yield return new WaitForSeconds(bulletSpawnWait);
        // }
        foreach(Transform bull in bulletPool.bullets){
            bull.gameObject.SetActive(true);
            bull.position = bulletSpawnPlace.position;
            bull.GetComponent<Bullet>().changeBulletDistance(trailDistance, arahPerpindahan);
            bull.GetComponent<Bullet>().startTimerBullet();
            // check.position = bull.GetComponent<Bullet>().getDistance();
            yield return new WaitForSeconds(bulletSpawnWait);
        }
        StartCoroutine(canShootAgain());
    }
    private IEnumerator canShootAgain(){
        yield return new WaitForSeconds(canShootAgainWait);
        checkShootOnce = true;
    }

    public void CanThrowAgain(){
        checkShootOnce = true;
    }
}
