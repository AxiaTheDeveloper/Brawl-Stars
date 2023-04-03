using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}
    private Vector2 keyInputMove = new Vector2 (0,0);
    private Vector2 keyInputAttack = new Vector2 (0,0);
    private PlayerInput playerInput;

    private void Awake() {
        Instance = this;
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

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
