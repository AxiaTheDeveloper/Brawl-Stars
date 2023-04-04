using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 bulletDistanceMati, arahPindah;
    [SerializeField]private float bulletSpeed, bulletDistances;
    

    private const string ENEMY_TAG = "Enemy";


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
        if(other.gameObject.CompareTag(ENEMY_TAG)){
            Debug.Log("Ded");
            gameObject.SetActive(false);
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
}
