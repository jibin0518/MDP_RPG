using UnityEngine;

public class Bim2 : MonoBehaviour
{
    public float speed = 20f;  // �̻��� �̵� �ӵ�
    private float lifetime = 1.5f;  // �̻��� ���� (��)
    private float spawnTime;  // �̻��� ���� �ð�
    public int bulletDirection;
    public int BossBimDirection;
    //public Player player;

    void Start()
    {
        spawnTime = Time.time;  // ���� �ð��� ����
    }

    void Update()
    {
        if (bulletDirection == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (bulletDirection == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        transform.position += new Vector3(speed * Time.deltaTime * -1, 0, 0);

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
        if (collision.gameObject.tag == "Bolt")
        {
            Destroy(gameObject);
        }
    }
}
