using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float speed = 10f;  // �̻��� �̵� �ӵ�
    private float lifetime = 2f;  // �̻��� ���� (��)
    private float spawnTime;  // �̻��� ���� �ð�
    public int bulletDirection;
    Animator anima;
    Rigidbody2D bulletrigid;

    void Start()
    {
        spawnTime = Time.time;  // ���� �ð��� ����
        anima = GetComponent<Animator>();
        bulletrigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (bulletDirection == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(bulletDirection==-1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // �̻����� ������ �� �Ǹ� ����
        if (Time.time - spawnTime > lifetime)
        {
            bulletrigid.velocity = Vector2.zero;
            anima.SetTrigger("Destory");
            Destroy(gameObject,1);
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime * bulletDirection, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            anima.SetTrigger("Destory");
            bulletrigid.velocity = Vector2.zero;
            Destroy(gameObject,1);
        }
    }
}
