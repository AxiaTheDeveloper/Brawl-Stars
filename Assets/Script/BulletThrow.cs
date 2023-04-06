using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletThrow : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private Vector3[] Points;
    Rigidbody rb;
    [SerializeField]private float kecepatan;
    private bool isThrow;
    private int currentIndex;
    // private const string ENEMY_TAG = "Enemy";
    private const string BULLET_TAG = "Bullet";
    private const string PLAYER_TAG = "Player";

    [SerializeField]private int damageMin, damageMax;

    private PlayerIdentity playerIdentity;
    private void Awake() {
        Points = new Vector3[9];
        rb = GetComponent<Rigidbody>();
    }
    private void Start() {
        // playerAttack = GameObject.Find("AttackTrail").GetComponent<PlayerAttack>();
        playerAttack.bulletPoints.CopyTo(Points,0);
        isThrow = true;
        currentIndex = 0;
    }

    private void Update() {
        transform.Translate(Vector3.forward * kecepatan);
        // Debug.Log(currentIndex);
        // Debug.Log(Points[currentIndex]);
        // Debug.Log("Posisi" + transform.position);
        // Debug.Log((Points[currentIndex] - transform.position).sqrMagnitude);
        // if(i < 11){
        //     Debug.Log(i);
        //     i++;
        // }
        if(isThrow){
            transform.LookAt(Points[currentIndex]);
            
            isThrow = false;
        }
        else if((Points[currentIndex] - transform.position).sqrMagnitude < 0.2f && currentIndex == 0){
            currentIndex++;
            transform.LookAt(Points[currentIndex]);
        }
        else if(transform.position.y > 19.5f){
            transform.LookAt(Points[5]);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag(PLAYER_TAG)){
            
            PlayerIdentity playerID = other.gameObject.GetComponent<PlayerIdentity>();
            if(playerID != playerIdentity){
                Destroy(this.gameObject);
                int damage = Random.Range(damageMin,damageMax);
                playerID.GetHit(damage);
            }
            playerAttack.CanThrowAgain();
        }
        else if(other.gameObject.CompareTag(BULLET_TAG)){
            
        }
        else{
            
            Destroy(this.gameObject,0.5f);
            playerAttack.CanThrowAgain();
        }
        
        
    }
    public void SetTrail(PlayerAttack playerAttacks, PlayerIdentity playerIdentitys){
        playerAttack = playerAttacks;
        playerIdentity = playerIdentitys;
    }
}
