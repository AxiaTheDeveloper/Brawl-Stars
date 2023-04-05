using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    [SerializeField]private int playerHealth;

    public void GetHit(int damage){
        if(playerHealth <= 0){
            //ntr ksh event ui lalalala
            Debug.Log("weeee");
        }
        playerHealth -= damage;
    }
}
