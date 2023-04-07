using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    [SerializeField]private Button restartButton, mainMenuButton;
    [SerializeField]private TextMeshProUGUI p1, p2;
    [SerializeField]private PlayerRecognition player1, player2;
    private const string SCENE_MAIN_GAME_TAG = "MainGame";
    private const string SCENE_MAIN_MENU_TAG = "MainMenu";

    private void Awake() {
        restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SCENE_MAIN_GAME_TAG, LoadSceneMode.Single);
        });

        mainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SCENE_MAIN_MENU_TAG, LoadSceneMode.Single);
        });
    }
    private void Start() {
        player1.OnDeathUI += player1_OnDeath;
        player2.OnDeathUI += player2_OnDeath;

        gameObject.SetActive(false);

        
    }

    private void player1_OnDeath(object sender, System.EventArgs e){
        gameObject.SetActive(true);
        // Debug.Log("player1");
        p1.gameObject.SetActive(false);
        p2.gameObject.SetActive(true);
    }
    private void player2_OnDeath(object sender, System.EventArgs e){
        gameObject.SetActive(true);
        // Debug.Log("player2");
        p1.gameObject.SetActive(true);
        p2.gameObject.SetActive(false);
    }
}
