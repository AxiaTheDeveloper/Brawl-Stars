using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRecognition : MonoBehaviour
{
    [SerializeField]private int PlayerNo;

    [SerializeField]private GameObject character_One, character_Two;
    private const string PILIHAN_PLAYER_SATU = "PilihanP1";
    private const string PILIHAN_PLAYER_DUA = "PilihanP2";
    private int pilihan;
    private PlayerIdentity playerIdentity;

    public event EventHandler OnDeathUI;


    private void Start() {
        
        if(PlayerNo == 1){
            if(PlayerPrefs.HasKey(PILIHAN_PLAYER_SATU)){
                pilihan = PlayerPrefs.GetInt(PILIHAN_PLAYER_SATU);
            }
            else{
                pilihan = 1;
            }
            
        }
        else if(PlayerNo == 2){
            if(PlayerPrefs.HasKey(PILIHAN_PLAYER_DUA)){
                pilihan = PlayerPrefs.GetInt(PILIHAN_PLAYER_DUA);
            }
            else{
                pilihan = 1;
            }
            
        }
        
        if(pilihan == 1){
            character_One.SetActive(true);
            character_Two.SetActive(false);
            playerIdentity = character_One.GetComponentInChildren<PlayerIdentity>();
        }
        else{
            character_One.SetActive(false);
            character_Two.SetActive(true);
            playerIdentity = character_Two.GetComponentInChildren<PlayerIdentity>();
        }
        playerIdentity.OnDeath += playerIdentity_OnDeath;
    }
    public int GetPlayerNo(){
        return PlayerNo;
    }
    public int GetPilihan(){
        return pilihan;
    }

    private void playerIdentity_OnDeath(object sender, System.EventArgs e){
        OnDeathUI?.Invoke(this, EventArgs.Empty);
        // Debug.Log(PlayerNo);
    }
}
