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
    public Player player;

    void Start()
    {
        spawnTime = Time.time;  // ���� �ð��� ����
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * bulletDirection, 0, 0);

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
