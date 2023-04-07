using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}
    private Vector2 keyInputMove = new Vector2 (0,0);
    private Vector2 keyInputAttack = new Vector2 (0,0);
    [SerializeField] PlayerInput playerInput;

    public event EventHandler OnShoot;

    private const string SHOOT_TAG_INPUT = "Shoot";
    private const string MOVE_TAG_INPUT = "Move";
    private const string ATTACK_ARAH_TAG_INPUT = "AttackArah";


    private void Awake() {
        Instance = this;
        

        playerInput.actions[SHOOT_TAG_INPUT].performed += Shoot_performed;
    }

    private void OnEnable() {
        playerInput.actions[SHOOT_TAG_INPUT].performed -= Shoot_performed;
        playerInput.actions[SHOOT_TAG_INPUT].performed += Shoot_performed;
    }
    private void OnDisable() {
        playerInput.actions[SHOOT_TAG_INPUT].performed -= Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnShoot(this, EventArgs.Empty);
    }

    public Vector2 GetInputMovementNormalized(){
        keyInputMove = playerInput.actions[MOVE_TAG_INPUT].ReadValue<Vector2>();
        keyInputMove = keyInputMove.normalized;
        return keyInputMove;
    }
    public Vector2 GetInputAttack(){
        keyInputAttack = playerInput.actions[ATTACK_ARAH_TAG_INPUT].ReadValue<Vector2>();
        
        return keyInputAttack;
    }

    public Vector2 GetInputAttackNormalized(){
        keyInputAttack = playerInput.actions[ATTACK_ARAH_TAG_INPUT].ReadValue<Vector2>();
        keyInputAttack = keyInputAttack.normalized;
        return keyInputAttack;
    }
}
