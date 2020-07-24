using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ghoul : MonoBehaviour
{
    public float AttackRange;
    public float AttackingTime;
    public float GhoulStrength;
    public float GhoulHP;

    float NowAttackingTime = 0;
    float Distance() { return GameObject.Find("Ghoul").GetComponent<Movement_Mob>().Distance(); }
    void Update()
    {

        NowAttackingTime += Time.deltaTime;
        if (Distance() < AttackRange && AttackingTime <= NowAttackingTime)
        {
            if (GameObject.Find("Player").GetComponent<Player>().Player_Current_HP >= 0) // 구울의 공격
            {
                GameObject.Find("Player").GetComponent<Player>().Player_Current_HP -= GhoulStrength;
                Debug.Log("플레이어가 구울에게 " + GhoulStrength + "만큼의 피해를 받았습니다.");
            }
            NowAttackingTime = 0;
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && GhoulHP > 0)
        {
            GhoulHP -= 5; // GameObject.Find("Bullet").GetComponent<Bullet>().불렛공격력
            Debug.Log("좀비가 5만큼의 피해를 받았습니다.");
            if (GhoulHP <= 0) Destroy(gameObject);
        }
    }
}
