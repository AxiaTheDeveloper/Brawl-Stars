using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttackThrow : MonoBehaviour
{
    [SerializeField]private LineRenderer line;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private Transform bulletSpawnPlace;
    private Vector2 keyInputAttack = new Vector2 (0,0);
    private Vector3 arahPerpindahan = new Vector3(0,0,0);
    private float melihatKeyInput = 10;
    [SerializeField]private float trailDistance;
    private bool IsAttack, canShoot, checkShootOnce;
    [SerializeField]private Transform Player;
    private RaycastHit hit;


    //bullet
    [SerializeField]private BulletPool bulletPool;
    [SerializeField]private float bulletSpawnWait, canShootAgainWait;
    
    [SerializeField]private GameObject prefabBullet;
    private GameObject theBullet;
    [SerializeField]private int totalBullet;
    private int totalBulletSave;



    public event EventHandler OnAnimasiThrow;

    public Vector3[] bulletPoints;
    

    // Update is called once per frame
    private void Start() {
        gameInput.OnShoot += gameInput_OnShoot;
        
        checkShootOnce = true;
        bulletPoints = new Vector3[9];
    }
    void Update()
    {
        Attack();
    }

    private void gameInput_OnShoot(object sender, System.EventArgs e){
        if(canShoot && checkShootOnce){
            OnAnimasiThrow?.Invoke(this,EventArgs.Empty);
            Debug.Log("pew pew");
            // totalBulletSave = totalBullet;
            checkShootOnce = false;
            StartCoroutine(BulletSpawn());
            canShoot = false;
        }
    }

    private void Attack(){
        keyInputAttack = gameInput.GetInputAttackNormalized();
        
        IsAttack = keyInputAttack != Vector2.zero;
        // Debug.Log(IsAttack);
        // Debug.Log
        line.enabled = IsAttack;
        canShoot = IsAttack;
        transform.position = new Vector3(Player.position.x,4.2f,Player.position.z);
        
        

        arahPerpindahan.Set(keyInputAttack.x,0f, keyInputAttack.y);
        // Debug.Log(keyInputAttack);
        // transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        line.SetPosition(0,transform.position);

        if(Physics.Raycast(transform.position, transform.forward, out hit, trailDistance)){
            line.SetPosition(1,hit.point);
            // Debug.Log("yey");
        }else{
            line.SetPosition(1,transform.position + transform.forward * trailDistance);
            line.SetPosition(1, new Vector3(line.GetPosition(1).x, 4.2f,line.GetPosition(1).z));
            // Debug.Log("boom");
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
}
