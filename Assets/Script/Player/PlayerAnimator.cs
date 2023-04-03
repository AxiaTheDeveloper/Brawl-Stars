using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMove;
    private Animator animatorController;
    private const string IS_WALK = "IsWalk";



    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    private void Start() {
        animatorController.SetBool(IS_WALK, false);
        // Debug.Log(player.getIsJalan());
    }

    private void Update(){
        // Debug.Log(player.getIsJalan());
        animatorController.SetBool(IS_WALK, playerMove.GetIsJalan());
        
    }
}
