using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPlace : MonoBehaviour
{
    [SerializeField]private Transform Player;
    void Update()
    {
        transform.position = new Vector3(Player.position.x,Player.position.y + 6f,Player.position.z+7f);
    }
}
