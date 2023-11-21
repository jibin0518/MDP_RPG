using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // �̻��� �̵� �ӵ�
    private float lifetime = 1.5f;  // �̻��� ���� (��)
    private float spawnTime;  // �̻��� ���� �ð�
    public int bulletDirection;
    HeroKnight player;

    void Start()
    {
        player = GetComponent<HeroKnight>();
        spawnTime = Time.time;  // ���� �ð��� ����
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

        // �̻����� ������ �� �Ǹ� ����
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
