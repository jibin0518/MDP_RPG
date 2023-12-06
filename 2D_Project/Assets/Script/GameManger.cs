using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Player player;
    public Bullet bullet;

    void Start()
    {
        
    }

    void Update()
    {
        if (player.GetComponent<SpriteRenderer>().flipX)
        {
            bullet.bulletDirection = -1;
        }
        else
        {
            bullet.bulletDirection = 1;
        }
    }
}
