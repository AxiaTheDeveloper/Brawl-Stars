using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuUI : MonoBehaviour
{
    private const string SCENE_MAIN_GAME_TAG = "MainGame";
    [SerializeField]private Button ShooterPlayer1, BomberPlayer1, ShooterPlayer2,BomberPlayer2, startButton;
    private int playerONE_Pick, playerTWO_Pick;
    private const string PILIHAN_PLAYER_SATU = "PilihanP1";
    private const string PILIHAN_PLAYER_DUA = "PilihanP2";

    public event EventHandler OnPilihan_PlayerOne_Berubah, OnPilihan_PlayerTwo_Berubah;

    private Color32 colorNotPick = new Color32(130,130,130,255);
    private Color32 colorPick = new Color32(65,65,65,255);

    private void Awake() {
        ShooterPlayer1.onClick.AddListener(()=>{
            playerONE_Pick = 1;
            OnPilihan_PlayerOne_Berubah?.Invoke(this,EventArgs.Empty);
        });
        BomberPlayer1.onClick.AddListener(()=>{
            playerONE_Pick = 2;
            OnPilihan_PlayerOne_Berubah?.Invoke(this,EventArgs.Empty);
        });
        ShooterPlayer2.onClick.AddListener(()=>{
            playerTWO_Pick = 1;
            OnPilihan_PlayerTwo_Berubah?.Invoke(this,EventArgs.Empty);
        });
        BomberPlayer2.onClick.AddListener(()=>{
            
            playerTWO_Pick = 2;
            OnPilihan_PlayerTwo_Berubah?.Invoke(this,EventArgs.Empty);
        });
        startButton.onClick.AddListener(()=>{
            startGame();
        });
    }
    private void Start() {
        OnPilihan_PlayerOne_Berubah += MainMenu_OnPilihanPlayerOne;
        OnPilihan_PlayerTwo_Berubah += MainMenu_OnPilihanPlayerTwo;
        if(PlayerPrefs.HasKey(PILIHAN_PLAYER_SATU)){
            playerONE_Pick = PlayerPrefs.GetInt(PILIHAN_PLAYER_SATU);
        }
        else{
            playerONE_Pick = 1;
        }
        if(PlayerPrefs.HasKey(PILIHAN_PLAYER_DUA)){
            playerTWO_Pick = PlayerPrefs.GetInt(PILIHAN_PLAYER_DUA);
        }
        else{
            playerTWO_Pick = 1;
        }
        OnPilihan_PlayerOne_Berubah?.Invoke(this,EventArgs.Empty);
        OnPilihan_PlayerTwo_Berubah?.Invoke(this,EventArgs.Empty);

    }

    private void MainMenu_OnPilihanPlayerOne(object sender, System.EventArgs e){
        if(playerONE_Pick == 1){
            ShooterPlayer1.image.color = colorPick;
            BomberPlayer1.image.color = colorNotPick;
        }
        else{
            ShooterPlayer1.image.color = colorNotPick;
            BomberPlayer1.image.color = colorPick;
        }
    }
    private void MainMenu_OnPilihanPlayerTwo(object sender, System.EventArgs e){
        if(playerTWO_Pick == 1){
            ShooterPlayer2.image.color = colorPick;
            BomberPlayer2.image.color = colorNotPick;
        }
        else{
            ShooterPlayer2.image.color = colorNotPick;
            BomberPlayer2.image.color = colorPick;
        }
    }

    private void startGame(){
        PlayerPrefs.SetInt(PILIHAN_PLAYER_SATU, playerONE_Pick);
        PlayerPrefs.SetInt(PILIHAN_PLAYER_DUA, playerTWO_Pick);
        SceneManager.LoadScene(SCENE_MAIN_GAME_TAG, LoadSceneMode.Single);
    }
}
