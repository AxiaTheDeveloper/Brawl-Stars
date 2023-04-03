using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private LineRenderer line;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private Transform attackSprite;
    private Vector2 keyInputAttack = new Vector2 (0,0);
    private Vector3 arahPerpindahan = new Vector3(0,0,0);
    private float melihatKeyInput = 10;
    [SerializeField]private float trailDistance;
    private bool IsAttack;
    [SerializeField]private Transform Player;
    private RaycastHit hit;

    // Update is called once per frame
    private void Start() {
        IsAttack = false;
    }
    void Update()
    {
        Attack();
    }
    private void Attack(){
        keyInputAttack = gameInput.GetInputAttackNormalized();
        
        IsAttack = keyInputAttack != Vector2.zero;
        
        attackSprite.gameObject.SetActive(true);
        transform.position = new Vector3(Player.position.x,4.2f,Player.position.z);
        
        attackSprite.position = new Vector3(keyInputAttack.x * melihatKeyInput + transform.position.x, 0 ,keyInputAttack.y * melihatKeyInput+transform.position.z);

        arahPerpindahan.Set(keyInputAttack.x,0f, keyInputAttack.y);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        line.SetPosition(0,transform.position);

        if(Physics.Raycast(transform.position, transform.forward, out hit, trailDistance)){
            line.SetPosition(1,hit.point);
            Debug.Log("yey");
        }
        else{
            line.SetPosition(1,transform.position + transform.forward * trailDistance);
            Debug.Log("boom");
        }
    }

    public Vector3 GetArahPerpindahanAttack(){
        return arahPerpindahan;
    }
}
