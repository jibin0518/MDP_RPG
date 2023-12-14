using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bim1 : MonoBehaviour
{
    public float speed = 20f;  // 미사일 이동 속도
    private float lifetime = 1.5f;  // 미사일 수명 (초)
    private float spawnTime;  // 미사일 생성 시간
    public int BossBimDirection;
    //public Player player;

    void Start()
    {
        spawnTime = Time.time;  // 현재 시간을 저장
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * 1, 0, 0);

        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
