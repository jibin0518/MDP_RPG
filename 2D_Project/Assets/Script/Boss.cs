using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

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
}
