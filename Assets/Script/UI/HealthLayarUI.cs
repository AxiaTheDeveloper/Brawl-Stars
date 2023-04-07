using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthLayarUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI healthText;
    [SerializeField]private PlayerIdentity playerIdentityA;

    [SerializeField]private PlayerIdentity playerIdentityB;
    [SerializeField]private PlayerRecognition playerID;
    private void Start() {
        healthText.color = new Color32(44,255,0,255);
        
        playerIdentityA.OnHit += playerIdentity_OnHit;
        
        
    }
    private void Update() {
        if(playerID.GetPilihan() == 1){
            UpdateVisualHealthA();
        }
        else{
            UpdateVisualHealthB();
        }
    }

    private void playerIdentity_OnHit(object sender, PlayerIdentity.OnHitEventArgs e){
        // Debug.Log(e.playerHealthNormalized);
        
        if(e.playerHealthNormalized >= 0.6f){
            healthText.color = new Color32(44,255,0,255);
        }
        else if(e.playerHealthNormalized >= 0.3f){
            healthText.color = new Color32(255,96,0,255);
        }
        else{
            healthText.color = new Color32(255,0,27,255);
        }
            
            
    }
    private void UpdateVisualHealthA(){
        healthText.text = "Health: " + playerIdentityA.GetHealth().ToString();

    }
    private void UpdateVisualHealthB(){
        healthText.text = "Health: " + playerIdentityB.GetHealth().ToString();

    }
        
        
    
}
