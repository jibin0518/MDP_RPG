using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // �̻��� �̵� �ӵ�
    private float lifetime = 1.5f;  // �̻��� ���� (��)
    private float spawnTime;  // �̻��� ���� �ð�
    //HeroKnight Player;

    void Start()
    {
        //Player = GetComponent<HeroKnight>();
        spawnTime = Time.time;  // ���� �ð��� ����
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

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
