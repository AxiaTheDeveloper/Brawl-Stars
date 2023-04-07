using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrawlGameManager : MonoBehaviour
{
    public static BrawlGameManager Instance {get; private set;}
    public enum StateGame{
        CountDownToStart, GameStart, GameOver
    }
    
    private StateGame state;
    private bool isGameStart;
    [SerializeField]private float countDownTimer;

    public event EventHandler OnCountDownDone;

    private void Awake() {
        Instance = this;
        state = StateGame.CountDownToStart;
    }

    private void Start() {
        //di sini ngespawn karakternya di tmpt
    }

    private void Update() {
        if(state == StateGame.CountDownToStart){
            countDownTimer -= Time.deltaTime;
            if(countDownTimer <= 0f){
                state = StateGame.GameStart;
                OnCountDownDone?.Invoke(this,EventArgs.Empty);
                //matiin ui countdown
            }
        }

    }
    
    public bool IsGameStart(){
        return state == StateGame.GameStart;
    }

    public float GetCountDownTimer(){
        return countDownTimer;
    }

    public void GameOver(){
        state = StateGame.GameOver;
    }

    
}
