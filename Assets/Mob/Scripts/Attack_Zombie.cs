using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack_Zombie : MonoBehaviour
{
    public float AttackRange;
    public float AttackingTime;
    public float ZombieStrength;
    public float ZombieHP;

    float NowAttackingTime = 0;
    float Distance() { return GameObject.Find("Zombie").GetComponent<Movement_Mob>().Distance(); }
    void Update()
    {
        
        NowAttackingTime += Time.deltaTime;
        if (Distance() < AttackRange && AttackingTime <= NowAttackingTime)
        {
            if (GameObject.Find("Player").GetComponent<Player>().Player_Current_HP >= 0) // 좀비의 공격
            {
                GameObject.Find("Player").GetComponent<Player>().Player_Current_HP -= ZombieStrength;
                Debug.Log("플레이어가 좀비에게 "+ZombieStrength+"만큼의 피해를 받았습니다.");
            }
            NowAttackingTime = 0;
        }
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && ZombieHP > 0)
        {
            ZombieHP -= 5; // GameObject.Find("Bullet").GetComponent<Bullet>().불렛공격력
            Debug.Log("좀비가 5만큼의 피해를 받았습니다.");
            if (ZombieHP <= 0) Destroy(gameObject);
        }
    }
}