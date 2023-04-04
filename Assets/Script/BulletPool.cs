using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]private int totalBullet;
    [SerializeField]private Transform bulletPrefab;
    [SerializeField]private Transform bulletSpawnPlace;

    public List<Transform> bullets = new List<Transform>();

    private void Start() {
        for(int i=0;i<totalBullet;i++){
            Transform bull = Instantiate(bulletPrefab, bulletSpawnPlace.position, transform.rotation);
            bull.gameObject.SetActive(false);
            bullets.Add(bull);
        }
    }

}
