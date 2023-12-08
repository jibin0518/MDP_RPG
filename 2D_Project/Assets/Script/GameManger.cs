using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Player player;
    public Bullet bullet;
    public Image a;
    public Image d;
    public Image space;
    public Image mouseleft;
    public Image leftshift;

    void Start()
    {
        
    }

    void Update()
    {
        BulletDirection();
        PlayerMove();
        PlayerJump();
        PlayerShotting();
        PlayerRoll();
    }

    void BulletDirection()
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
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            a.color = Color.gray;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            d.color = Color.gray;
        }
        else
        {
            a.color = Color.white;
            d.color = Color.white;
        }
    }

    void PlayerJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            space.color = Color.gray;
        }
        else
        {
            space.color = Color.white;
        }
    } 

    void PlayerShotting()
    {
        if (Input.GetMouseButton(0))
        {
            mouseleft.color = Color.gray;
        }
        else
        {
            mouseleft.color = Color.white;
        }
    } 

    void PlayerRoll()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            leftshift.color = Color.gray;
        }
        else
        {
            leftshift.color = Color.white;
        }
    }
}
