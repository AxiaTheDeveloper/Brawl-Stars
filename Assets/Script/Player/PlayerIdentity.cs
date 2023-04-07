using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIdentity : MonoBehaviour
{
    [SerializeField]private int playerHealth;
    private int playerHealthContainer;

    public event EventHandler OnDeath;

    public event EventHandler<OnHitEventArgs> OnHit;
    
    public class OnHitEventArgs : EventArgs{
        public float playerHealthNormalized;
    }
    private void Start() {
        playerHealthContainer = playerHealth;
        // Debug.Log(playerHealthContainer);
    }

    public void GetHit(int damage){
        playerHealthContainer -= damage;
        
        if(playerHealthContainer <= 0){
            //ntr ksh event ui lalalala
            playerHealthContainer = 0;
            BrawlGameManager.Instance.GameOver();
            //animasi 
            OnDeath?.Invoke(this,EventArgs.Empty);
            // Debug.Log("weeee");
        }
        // Debug.Log((float)playerHealthContainer / playerHealth);
        OnHit?.Invoke(this, new OnHitEventArgs{
            playerHealthNormalized = (float)playerHealthContainer / playerHealth
        });
        
        //animasi trus ubah si game manager
        
    }

    public int GetHealth(){
        // Debug.Log(playerHealthContainer);
        return playerHealthContainer;
    }


}
