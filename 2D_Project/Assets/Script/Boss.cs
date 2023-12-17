
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;
    public GameObject buleltfire;
    public GameObject bossbullet_position;
    public bool skill = true;
    public GameObject[] droppos = new GameObject[4];
    public GameObject drop;
    public GameObject[] Attack_Warring = new GameObject[4];
    public GameObject bim1;
    public GameObject bim2;
    public GameObject bimWarring;

    public GameObject victory;

    public float maxhp = 500;
    public float curhp = 500;
    Renderer bosscolor;

    void Start()
    {
        player = GetComponent<Player>();
        bosscolor = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        int mod;

        Death();
        if (skill && curhp>=120)
        {
            mod = Random.Range(0,3);
            Debug.Log(mod);
            switch (mod)
            {
                case 0:
                    Fire();
                    Invoke("Fire",1);
                    Invoke("Fire", 1);
                    skill = false;
                    Invoke("Skil_delay",2);
                    break;
                case 1:
                    Drop();
                    skill = false;
                    Invoke("Skil_delay", 2);
                    break;
                case 2:
                    bimWarring.SetActive(true);
                    Invoke("Razer",1);
                    skill = false;
                    Invoke("Skil_delay", 2);
                    break;
            }
        }
    }

    void Death()
    {
        if (curhp <= 150)
        {
            victory.SetActive(true);
            Invoke("Out",2f);
        }
    }

    void Out()
    {
        Application.Quit();
    }

    void Fire()
    {
        GameObject missile = Instantiate(buleltfire, bossbullet_position.transform.position, transform.rotation);
    }

    void Drop()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject dropObj = Instantiate(drop, droppos[i].transform.position, transform.rotation);
        }
        for (int i = 0; i < 4; i++)
        {
            Attack_Warring[i].SetActive(true);
        }
    }

    void Razer()
    {
        GameObject Shotbim1 = Instantiate(bim1, bossbullet_position.transform.position, transform.rotation);
        GameObject Shotbim2 = Instantiate(bim2, bossbullet_position.transform.position, transform.rotation);
        bimWarring.SetActive(false);
    }

    void Skil_delay()
    {
        skill = true;
        for (int i = 0; i < 4; i++)
        {
            Attack_Warring[i].SetActive(false);
        }
    }

    void Color_delay()
    {
        bosscolor.material.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            curhp -= 5;
            bosscolor.material.color = Color.red;
            Invoke("Color_delay", 1);
        }

        if (collision.gameObject.tag == "Bolt")
        {
            curhp -= 15;
            bosscolor.material.color = Color.red;
            Invoke("Color_delay", 1);
        }
    }
}
