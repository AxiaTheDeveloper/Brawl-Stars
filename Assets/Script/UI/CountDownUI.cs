using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI cdNumber;
    private void Start() {
        BrawlGameManager.Instance.OnCountDownDone += gameManager_OnCountDownDone;
        gameObject.SetActive(true);
    }
    private void Update() {
        int cdNo = Mathf.CeilToInt(BrawlGameManager.Instance.GetCountDownTimer());
        cdNumber.text = cdNo.ToString();
    }

    private void gameManager_OnCountDownDone(object sender, System.EventArgs e){
        gameObject.SetActive(false);
    }


}
