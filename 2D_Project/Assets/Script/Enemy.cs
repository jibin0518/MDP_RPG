using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float spd;
    public Rigidbody2D target;

    bool islive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!islive)
        {
            return;
        }
        Vector2 dirvec = target.position - rigid.position;
        Vector2 nextvec = dirvec.normalized * spd * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!islive)
        {
            return;
        }
        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }
}
