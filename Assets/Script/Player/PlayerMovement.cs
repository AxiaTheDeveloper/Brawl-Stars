using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Transform PlayerSprite;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private float kecepatanPlayer;
    [SerializeField]private PlayerCollision playerCollision;
    private float melihatKeyInput = 10;
    // [SerializeField]private Transform cameraS;
    private Vector2 keyInput = new Vector2 (0,0);
    private Vector3 arahPerpindahan = new Vector3(0,0,0);
    private bool isJalan, bisaGerak;
    private void Start() {
        isJalan = false;
    }
    void Update()
    {
        Move();
    }

    private void Move(){
        keyInput = gameInput.GetInputMovementNormalized();
        isJalan = keyInput != Vector2.zero;
        
        PlayerSprite.gameObject.SetActive(isJalan);
        
        PlayerSprite.position = new Vector3(keyInput.x * melihatKeyInput + transform.position.x, 5 ,keyInput.y * melihatKeyInput+transform.position.z);

        

        // Debug.Log(PlayerSprite.position);
        arahPerpindahan.Set(keyInput.x,0f, keyInput.y);
        bisaGerak = playerCollision.GetBisaGerak(arahPerpindahan);
        if(!bisaGerak){
            Vector3 arahPerpindahanHorizontal = new Vector3(arahPerpindahan.x, 0f, 0f).normalized;
            bisaGerak = arahPerpindahan.x != 0 && playerCollision.GetBisaGerak(arahPerpindahanHorizontal);
            if(bisaGerak){
                arahPerpindahan = arahPerpindahanHorizontal;
            }
            else{
                //coba gerak atas bawah 
                Vector3 arahPerpindahanVertikal = new Vector3(0f, 0f, arahPerpindahan.z).normalized;
                bisaGerak = arahPerpindahan.z != 0 && playerCollision.GetBisaGerak(arahPerpindahanVertikal);
                if(bisaGerak){{
                    arahPerpindahan = arahPerpindahanVertikal;
                }}
            }
        }

        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y,0);

        

        if((keyInput.x > 0 || keyInput.x < 0 || keyInput.y > 0 || keyInput.y < 0)&& bisaGerak){
            transform.position += (arahPerpindahan * kecepatanPlayer * Time.deltaTime);
        }
        
        
    }

    public bool GetIsJalan(){
        return isJalan;
    }
    public float GetJarakPindah(){
        return kecepatanPlayer * Time.deltaTime;
    }
    public Vector3 GetArahPerpindahan(){
        return arahPerpindahan;
    }
}
