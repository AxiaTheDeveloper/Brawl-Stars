using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}
    private Vector2 keyInputMove = new Vector2 (0,0);
    private Vector2 keyInputAttack = new Vector2 (0,0);
    private PlayerInput playerInput;

    public event EventHandler OnShoot;

    private void Awake() {
        Instance = this;
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnShoot(this, EventArgs.Empty);
    }

    public Vector2 GetInputMovementNormalized(){
        keyInputMove = playerInput.Player.Move.ReadValue<Vector2>();
        keyInputMove = keyInputMove.normalized;
        return keyInputMove;
    }

    public Vector2 GetInputAttackNormalized(){
        keyInputAttack = playerInput.Player.AttackArah.ReadValue<Vector2>();
        keyInputAttack = keyInputAttack.normalized;
        return keyInputAttack;
    }
}
