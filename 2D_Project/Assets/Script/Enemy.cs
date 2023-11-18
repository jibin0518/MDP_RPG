using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float spd;

    bool islive = true;
    public bool targetting = false;
    //public int nextMove;
    public int targetcount=0;

    public Transform target;
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Vector2 dir;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        int a = (int)transform.position.x + 5;
        int b = (int)transform.position.x - 5;
        int player_position = (int)target.position.x;

        if(a>player_position && b < player_position)
        {
            targetting = true;
            //Debug.Log("check");
        }
        else
        {
            //Debug.Log("uncheck");
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

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            targetting = true;
            targetcount++;
        }
    }*/
}
