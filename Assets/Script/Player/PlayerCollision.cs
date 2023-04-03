using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]private float playerScale, playerHeight;

    //ambil arah pindah ama jarak pindah dr PlayerControllerMovement
    [SerializeField]private  PlayerMovement movement;
    
    public bool GetBisaGerak(Vector3 arahPindah){
        bool bisaBergerak = (!Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight, playerScale, arahPindah, movement.GetJarakPindah()));

        return bisaBergerak;
    }
}
