using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // 미사일 이동 속도
    private float lifetime = 1.5f;  // 미사일 수명 (초)
    private float spawnTime;  // 미사일 생성 시간
    public int bulletDirection;
    HeroKnight player;

    void Start()
    {
        player = GetComponent<HeroKnight>();
        spawnTime = Time.time;  // 현재 시간을 저장
    }

    void Update()
    {

        if(player.GetComponent<SpriteRenderer>().flipX == true)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }

        // 미사일의 수명이 다 되면 삭제
        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
