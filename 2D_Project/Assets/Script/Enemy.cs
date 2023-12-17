using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float spd;

    bool islive = true;
    public bool targetting = false;
    public int targetcount=0;

    public Transform target;

    public float maxhp=100;
    public float curhp=100;

    Renderer enemy_Body;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Vector2 dir;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy_Body = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Think();
    }

    void FixedUpdate()
    {
        if (targetting)
        {
            dir = target.position - transform.position;
            transform.Translate(dir.normalized * spd * Time.deltaTime);
        }
    }

    void Think()
    {
        int a = (int)transform.position.x + 10;
        int b = (int)transform.position.x - 10;
        int player_position = (int)target.position.x;

        if(a>player_position && b < player_position)
        {
            targetting = true;
        }
        else
        {
            targetting = false;
        }
    }

    private void LateUpdate()
    {
        if (!islive)
        {
            return;
        }
        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            curhp -= 20;
            enemy_Body.material.color = Color.red;
            Invoke("damage_delay",0.5f);
        }
    }

    void damage_delay()
    {
        enemy_Body.material.color = Color.white;
    }
}
