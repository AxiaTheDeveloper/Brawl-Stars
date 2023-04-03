using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRotasi : MonoBehaviour
{
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private float kecepatanRotasi;
    private Vector3 arahPindah;
    
    private void Update() {
        RotasiPlayer();
    }

    private void RotasiPlayer(){
        arahPindah = playerAttack.GetArahPerpindahanAttack();
        transform.forward = Vector3.Slerp(transform.forward, arahPindah, kecepatanRotasi * Time.deltaTime);
    }
}
