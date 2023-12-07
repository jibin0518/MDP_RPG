using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossAttack : MonoBehaviour
{
    public Transform player;
    public float bulletspd;
    Vector2 dir;

    void Start()
    {

    }
    void Update()
    {
        dir = player.position - transform.position;
        transform.Translate(dir.normalized * bulletspd * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
