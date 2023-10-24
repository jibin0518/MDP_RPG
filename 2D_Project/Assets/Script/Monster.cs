using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Monster : MonoBehaviour
{
    public int at;
    public float critical = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //플레이어공격
            AttacPlayer(collision.gameObject.GetComponent<Player>());
        }

    }

    public void AttacPlayer(Player _player)
    {
        if (UnityEngine.Random.Range(0,101) < 10f)
        {
            GiveDamage(_player, at * 1.5f);
            Debug.Log("크리티컬");
            //터짐
        }
        else
        {
            GiveDamage(_player, at);
            Debug.Log("그냥공격");
            //안터짐
        }
    }

    public void GiveDamage(Player target ,float damage)
    {
        if (at == 0)
        {
            target.CurHp -= (int)damage;
        }
        else
        {
            target.CurHp -= (int)damage;
        }
    }


}
