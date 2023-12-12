using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;
    public GameObject buleltfire;
    public GameObject bossbullet_position;
    bool skill = true;

    void Start()
    {
        player = GetComponent<Player>();
        
    }

    void Update()
    {
        int mod = Random.Range(0,3);

        if (skill)
        {
            
        }
        switch (mod)
        {
            case 0:
                Fire();
                break;
            case 1:
                Drop();
                break;
            case 2:
                Razer();
                break;
        }

        Debug.Log(mod);

        Invoke("Skill_Delay",5);
    }

    void Fire()
    {
        GameObject missile = Instantiate(buleltfire, bossbullet_position.transform.position, transform.rotation);
    }

    void Drop()
    {

    }

    void Razer()
    {

    }

    void EnemyFIre()
    {
        GameObject missile = Instantiate(buleltfire, bossbullet_position.transform.position, transform.rotation);
    }

    void Skill_Delay()
    {
        skill = false;
    }
}
