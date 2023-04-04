using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMove;
    [SerializeField]private PlayerAttack playerAttack;
    private Animator animatorController;
    private const string IS_WALK = "IsWalk";
    private const string IS_SHOOT = "IsShoot";



    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    private void Start() {
        animatorController.SetBool(IS_WALK, false);
        playerAttack.OnAnimasiShoot += playerAttack_OnAnimasiShoot;
        // Debug.Log(player.getIsJalan());
    }

    private void Update(){
        // Debug.Log(player.getIsJalan());
        animatorController.SetBool(IS_WALK, playerMove.GetIsJalan());
        
    }

    private void playerAttack_OnAnimasiShoot(object sender, System.EventArgs e){
        animatorController.SetTrigger(IS_SHOOT);
    }
}
