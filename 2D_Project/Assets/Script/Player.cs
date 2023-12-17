using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 3.5f;
    [SerializeField] float      m_rollForce = 1f;
    [SerializeField] bool       m_noBlood = false;
    [SerializeField] GameObject m_slideDust;
    public GameObject bullet_position;
    public GameObject bolt_position;
    public GameObject GameOver_Panel;

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
    private float               m_rollDuration = 8.0f / 16.0f;
    private float               m_rollCurrentTime;
    
    public float CurHp = 100;
    public float MaxHp = 100;

    public bool deathing = true;

    public bool isJump;

    public int maxbullet;
    public int curbullet;

    public GameObject leftwall;
    public GameObject rightwall;

    bool reload;
    bool skill1ready=true;

    public GameObject boltPrefab;
    public GameObject missilePrefab;
    Renderer player_body;

    public bool firebool;

    public float skillcnt=0;

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
        if (deathing)
        {
            Live();
        }

    }

    void Live()
    {
        if (CurHp > 0)
        {
            deathing = true;
        }
        // Increase timer that controls attack combo
        m_timeSinceAttack += Time.deltaTime;

        // Increase timer that checks roll duration
        if (m_rolling)
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
            m_animator.SetFloat("Move", inputX);
        }

        else if (inputX < 0 && deathing)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
            m_animator.SetFloat("Move", inputX);
        }

        // Move
        if (!m_rolling && deathing && !firebool)
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        //Death
        if (CurHp <= 0 && deathing)
        {
            m_animator.SetTrigger("Death");
            deathing = false;
            GameOver_Panel.SetActive(true);
            Invoke("AppQuit",2f);
            
        }

        Attack();
        ReLoad();
        Skill1();

        // Roll
        if (Input.GetKeyDown("left shift") && !m_rolling && leftwall.transform.position.x + 5 < transform.position.x && rightwall.transform.position.x-5>transform.position.x)
        {
            m_body2d.velocity = Vector2.zero;
            m_animator.SetTrigger("Roll");
            m_rolling = true;
            Invoke("Roll_Delay", 0.3f);
        }


        //Jumpf
        if (Input.GetKeyDown("space") && m_grounded && !m_rolling && !isJump)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
            isJump = true;
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
            if (m_delayToIdle < 0)
                m_animator.SetInteger("AnimState", 0);
        }
    }

    void AppQuit()
    {
        Application.Quit();
    }

    void Skill1()
    {
        
        if (Input.GetKey(KeyCode.E)&&skill1ready && curbullet>5 && !isJump)
        {
            m_body2d.velocity = Vector2.zero;
            m_animator.SetBool("Razer_Skill",true);
            skillcnt += 0.1f;
            if (skillcnt >= 10)
            {
                m_animator.SetBool("Razer_Skill", false);
                m_animator.SetTrigger("Razer_Fire");
                GameObject missile = Instantiate(boltPrefab, bolt_position.transform.position, transform.rotation);
                curbullet -= 5;
                skillcnt = 0;
                skill1ready = false;
                Invoke("Razer_Delay",3);
            }
        }
        
        else if (Input.GetKeyUp(KeyCode.E))
        {
            m_animator.SetBool("Razer_Skill", false);
            skillcnt = 0;
        }

        
    }

    void ReLoad()
    {
        if (curbullet < maxbullet && !reload)
        {
            reload = true;
            Invoke("ReLoad_Delay",0.9f);
        }
    }

    void ReLoad_Delay()
    {
        curbullet++;
        reload = false;
    }

    void Razer_Delay()
    {
        skill1ready = true;
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !m_rolling && !isJump && curbullet > 0)
        {
            firebool = true;
            m_animator.SetTrigger("Attack");
            curbullet--;
            GameObject missile = Instantiate(missilePrefab, bullet_position.transform.position, transform.rotation);
        }
        else
        {
            firebool = false;
        }
    }

    void Roll_Delay()
    {
        transform.position = new Vector2(transform.position.x + (5 * m_facingDirection), transform.position.y);
        m_body2d.velocity = Vector2.zero;
        m_rolling = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BossMissile" && CurHp > 0 || collision.gameObject.tag == "Enemy")
        {
            CurHp -= 12;
            player_body.material.color = Color.red;
            Invoke("Color_delay", 1);
        }
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossMissile" && CurHp > 0)
        {
            CurHp -= 20;
            player_body.material.color = Color.red;
            Invoke("Color_delay", 1);
        }
    }

    void Color_delay()
    {
        player_body.material.color = Color.white;
    }
}
