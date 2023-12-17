using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Transform player;
    public float bulletspd;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, bulletspd * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bolt")
        {
            Destroy(gameObject);
        }
    }
}
