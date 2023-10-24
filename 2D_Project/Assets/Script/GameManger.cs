using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public GameObject Message_Dangerous;
    public GameObject Message_Safe;
    public GameObject Message_Boss;

    public GameObject Local_Safe_Box;
    public GameObject Local_Dangerous_Box;
    public GameObject Local_Boss_Box;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Local_Message(int local)
    {
        if (local == 1)
        {
            Message_Safe.SetActive(true);
        }
        if (local == 2)
        {
            Message_Dangerous.SetActive(true);
        }
        if (local == 3)
        {
            Message_Boss.SetActive(true);
        }
    }
}
