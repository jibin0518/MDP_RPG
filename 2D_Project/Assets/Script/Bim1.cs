using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bim1 : MonoBehaviour
{
    public float speed = 20f;  // �̻��� �̵� �ӵ�
    private float lifetime = 1.5f;  // �̻��� ���� (��)
    private float spawnTime;  // �̻��� ���� �ð�
    public int BossBimDirection;
    //public Player player;

    void Start()
    {
        spawnTime = Time.time;  // ���� �ð��� ����
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
