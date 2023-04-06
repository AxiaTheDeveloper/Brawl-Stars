using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMove;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private PlayerIdentity playerIdentity;
    private Animator animatorController;
    private const string IS_WALK = "IsWalk";
    private const string IS_SHOOT = "IsShoot";
    private const string IS_THROW = "IsThrow";
    private const string IS_DEATH = "IsDeath";



    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    private void Start() {
        animatorController.SetBool(IS_WALK, false);
        if(playerAttack.type == PlayerAttack.AttackType.Shoot){
            playerAttack.OnAnimasiShoot += playerAttack_OnAnimasiShoot;
        }
        if(playerAttack.type == PlayerAttack.AttackType.Throw){
            playerAttack.OnAnimasiThrow += playerAttackThrow_OnAnimasiThrow;
        }
        // Debug.Log(player.getIsJalan());

        playerIdentity.OnDeath += playerIdentity_OnDeath;
    }

    private void Update(){
        // Debug.Log(player.getIsJalan());
        animatorController.SetBool(IS_WALK, playerMove.GetIsJalan());
        
    }

    private void playerAttack_OnAnimasiShoot(object sender, System.EventArgs e){
        animatorController.SetTrigger(IS_SHOOT);
    }
    private void playerAttackThrow_OnAnimasiThrow(object sender, System.EventArgs e){
        animatorController.SetTrigger(IS_THROW);
    }

    private void playerIdentity_OnDeath(object sender, System.EventArgs e){
        animatorController.SetTrigger(IS_DEATH);
        animatorController.StopPlayback();
    }
}
