using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private float kecepatanRotasi;
    private Vector3 arahPindah;
    private void Update() {
        RotasiPlayer();
    }

    private void RotasiPlayer(){
        if(playerAttack.GetIsAttack()){
            arahPindah = playerAttack.GetArahPerpindahanAttack();
        }
        else{
            arahPindah = playerMovement.GetArahPerpindahan();
        }
        
        transform.forward = Vector3.Slerp(transform.forward, arahPindah, kecepatanRotasi * Time.deltaTime);
    }
}
