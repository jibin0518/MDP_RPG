using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class HeroKnight : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 3.5f;
    [SerializeField] float      m_rollForce = 1f;
    [SerializeField] bool       m_noBlood = false;
    [SerializeField] GameObject m_slideDust;
    public GameObject bullet_position;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_HeroKnight   m_groundSensor;
    private bool                m_isWallSliding = false;
    private bool                m_grounded = false;
    private bool                m_rolling = false;
    public int                 m_facingDirection;
    private int                 m_currentAttack = 0;
    private float               m_timeSinceAttack = 0.0f;
    private float               m_delayToIdle = 0.0f;
    private float               m_rollDuration = 8.0f / 14.0f;
    private float               m_rollCurrentTime;
    
    public float CurHp = 100;
    public float MaxHp = 100;

    private float roll_speed = 1;

    public bool deathing;

    private bool isJump;

    public GameObject missilePrefab;
    Renderer player_body;

    public bool firebool;

    // Use this for initialization
    void Start ()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
        player_body = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update ()
    {

        if (CurHp > 0)
        {
            deathing = true;
        }
        // Increase timer that controls attack combo
        m_timeSinceAttack += Time.deltaTime;

        // Increase timer that checks roll duration
        if(m_rolling)
            m_rollCurrentTime += Time.deltaTime;

        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0 && deathing)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }
            
        else if (inputX < 0 && deathing)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
        }

        // Move
        if (!m_rolling && deathing && !firebool)
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        //Death
        if (CurHp<=0 && deathing)
        {
            m_animator.SetTrigger("Death");
            deathing = false;
        }

        Attack();

        // Roll
        if (Input.GetKeyDown("left shift") && !m_rolling && !m_isWallSliding && m_body2d.velocity!=Vector2.zero && isJump)
        {
            m_rolling = true;
            m_animator.SetTrigger("Roll");
            roll_speed = 7;
            m_body2d.velocity = new Vector2(m_facingDirection * /*m_rollForce **/ roll_speed, m_body2d.velocity.y);
            Invoke("Roll_Delay", m_rollDuration);
        }
            

        //Jumpf
        if (Input.GetKeyDown("space") && m_grounded && !m_rolling && isJump)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
            isJump = false;
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            // Reset timer
            m_delayToIdle = 0.05f;
            m_animator.SetInteger("AnimState", 1);
        }

        //Idle
        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
                if(m_delayToIdle < 0)
                    m_animator.SetInteger("AnimState", 0);
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !m_rolling)
        {
            firebool = true;
            m_animator.SetTrigger("Attack");
            GameObject missile = Instantiate(missilePrefab, bullet_position.transform.position, transform.rotation);
        }
        else
        {
            firebool = false;
        }
    }

    void Roll_Delay()
    {
        roll_speed = 1;
        m_rolling = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
        }
        if(collision.gameObject.tag == "Enemy" && CurHp>0)
        {
            CurHp -= 20;
            player_body.material.color = Color.red;
            Invoke("Color_delay",1);
        }
    }

    void Color_delay()
    {
        player_body.material.color = Color.white;
    }
}
