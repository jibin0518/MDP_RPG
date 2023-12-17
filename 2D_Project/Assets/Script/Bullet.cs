using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // �̻��� �̵� �ӵ�
    private float lifetime = 1.5f;  // �̻��� ���� (��)
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
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(bulletDirection==-1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        // �̻����� ������ �� �Ǹ� ����
        if (Time.time - spawnTime > lifetime)
        {
            bulletrigid.velocity = Vector2.zero;
            anima.SetTrigger("TimeOver");
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
        if (collision.gameObject.tag == "BossMissle")
        {
            anima.SetTrigger("Destory");
            bulletrigid.velocity = Vector2.zero;
            Destroy(gameObject,1);
        }
    }
}
