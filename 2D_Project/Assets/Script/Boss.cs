using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;
    public GameObject buleltfire;
    public GameObject bossbullet_position;

    void Start()
    {
        player = GetComponent<Player>();
        GameObject missile = Instantiate(buleltfire, bossbullet_position.transform.position, transform.rotation);
    }

    void Update()
    {
        
    }
}
