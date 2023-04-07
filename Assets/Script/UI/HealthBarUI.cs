using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarUI : MonoBehaviour
{
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private Image fillHealth;
    [SerializeField]private Transform Player;
    private bool isFirstHit;
    
    // private bool firstUpdate = true;

    private void Start() {
        playerIdentity.OnHit += playerIdentity_OnHit;
        fillHealth.fillAmount = 0f;
        
        isFirstHit = true;
        
        Hide();
        
    }

    private void Update() {
        transform.position = new Vector3(Player.position.x, 28, Player.position.z);
    }

    private void playerIdentity_OnHit(object sender, PlayerIdentity.OnHitEventArgs e){
        // Debug.Log(e.playerHealthNormalized);
        
        if(isFirstHit){
            // Debug.Log("Test ???");
            Show();
            isFirstHit = false;
        }
        else{
            
            if(e.playerHealthNormalized == 0f){
                // Debug.Log("Test ?????");
                Hide();
            }
            else{
                // Debug.Log("Test ?????SSS");
                fillHealth.fillAmount = e.playerHealthNormalized;
                if(e.playerHealthNormalized >= 0.6f){
                    fillHealth.color = new Color32(44,255,0,255);

                }
                else if(e.playerHealthNormalized >= 0.3f){
                    fillHealth.color = new Color32(255,96,0,255);

                }
                else{
                    fillHealth.color = new Color32(255,0,27,255);

                }
            }
            
        }
        
        
    }

    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }




}
