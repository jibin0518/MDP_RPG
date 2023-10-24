using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
{
    public Vector2 Inputvec;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator aim;

    GameManger Manger;

    [SerializeField]
    int maxHp;

    public int curHp;
    public float spd;

    public int CurHp { get => curHp; set => curHp = value; }

    public int MaxHp { get => maxHp; set => maxHp = value; }

    void Awake()
    {
        curHp = maxHp;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        aim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 nextvec = Inputvec.normalized * spd * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);

        if (Input.GetMouseButtonDown(0))
        {
            aim.SetTrigger("Atk");
        }
    }

    void OnMove(InputValue value)
    {
        Inputvec = value.Get<Vector2>();
    }

    /*void OnClickLeftMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(context.interaction is PressInteraction)
            {
                aim.SetTrigger("Atk");
            }
        }
    }*/

    void LateUpdate()
    {
        aim.SetFloat("Spd", Inputvec.magnitude);

        if (Inputvec.x != 0)
        {
            spriteRenderer.flipX = Inputvec.x < 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Safe_Local")
        {
           
        }
        if (collision.gameObject.tag == "Danger_Local")
        {

        }
        if (collision.gameObject.tag == "Boss_Local")
        {

        }
    }
}
