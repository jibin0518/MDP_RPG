using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float spd;

    bool islive = true;
    public bool targetting = false;
    public int nextMove;
    public int targetcount=0;

    public Transform target;
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Vector2 dir;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!islive)
        {
            return;
        }
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
        nextMove = Random.Range(-1, 2);

        //Invoke("Think", 1);
    }

    private void LateUpdate()
    {
        if (!islive)
        {
            return;
        }
        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            targetting = true;
        }
    }
}
