using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputvec;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float spd;
    public float run;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputvec.x = Input.GetAxisRaw("Horizontal");
        inputvec.y = Input.GetAxisRaw("Vertical");
        

        if(Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        if (rigid.velocity.normalized.x == 0)
            anim.SetBool("Test", false);
        else
            anim.SetBool("Test", true);

        run = Input.GetKey(KeyCode.LeftShift) ? 1.3f : 1;
    }

    private void FixedUpdate()
    {
        Vector2 nextvec = inputvec.normalized * spd * Time.fixedDeltaTime * run;
        rigid.MovePosition(rigid.position + nextvec);
    }
}
