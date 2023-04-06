using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 bulletDistanceMati, arahPindah;
    [SerializeField]private float bulletSpeed, bulletDistances;

    private PlayerIdentity playerIdentity;
    

    private const string BULLET_TAG = "Bullet";
    private const string PLAYER_TAG = "Player";

    [SerializeField]private int damageMin, damageMax;

    private void Update() {

        // if(transform.position.magnitude >= bulletDistanceMati.magnitude){
        //     // Debug.Log(transform.position.x +" "+ transform.position.y + " " + transform.position.z);
        //     // Debug.Log(bulletDistanceMati.x +" "+ bulletDistanceMati.y + " " + bulletDistanceMati.z);
        //     // Debug.Log("yey");
        //     gameObject.SetActive(false);
        
        // }
        transform.position += (arahPindah * bulletSpeed * Time.deltaTime);
        

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag(PLAYER_TAG)){
            
            PlayerIdentity playerID = other.gameObject.GetComponent<PlayerIdentity>();
            if(playerID != playerIdentity){
                gameObject.SetActive(false);
                int damage = Random.Range(damageMin,damageMax);
                playerID.GetHit(damage);
            }
        }
        else if(other.gameObject.CompareTag(BULLET_TAG)){
            
        }
        else{
            gameObject.SetActive(false);
        }
        
        
    }

    public void changeBulletDistance(float jarakBullet, Vector3 arahPindah){
        bulletDistances = jarakBullet/100 - jarakBullet/1000;
        this.arahPindah = arahPindah;
    }
    public void startTimerBullet(){
        StopCoroutine(bulletDistance());
        StartCoroutine(bulletDistance());
    }
    private IEnumerator bulletDistance(){
        yield return new WaitForSeconds(bulletDistances);
        gameObject.SetActive(false);
    }
    public void SetIdentity(PlayerIdentity playerIdentitys){
        playerIdentity = playerIdentitys;
    }
}
