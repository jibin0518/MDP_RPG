using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;
    public GameObject buleltfire;
    public GameObject bossbullet_position;
    public bool skill = true;
    public GameObject[] droppos = new GameObject[4];

    void Start()
    {
        player = GetComponent<Player>();
        
    }

    void Update()
    {
        int mod;
        if (skill)
        {
            mod = Random.Range(0,3);
            Debug.Log(mod);
            switch (mod)
            {
                case 0:
                    Fire();
                    skill = false;
                    Invoke("Skil_delay",2);
                    break;
                case 1:
                    Drop();
                    skill = false;
                    Invoke("Skil_delay", 2);
                    break;
                case 2:
                    Razer();
                    skill = false;
                    Invoke("Skil_delay", 2);
                    break;
            }
        }
    }

    void Fire()
    {
        GameObject missile = Instantiate(buleltfire, bossbullet_position.transform.position, transform.rotation);
    }

    void Drop()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject dropObj = Instantiate(droppos[i], bossbullet_position.transform.position, transform.rotation);
        }
    }

    void Razer()
    {

    }

    void Skil_delay()
    {
        skill = true;
    }
}
