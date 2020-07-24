using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float AttackRange;
    public float AttackingTime;
    public float Strength;
    public float HP;

    public float Dead = 0;
    float NowAttackingTime = 0;
    float Distance() { return this.GetComponent<Movement_Mob>().Distance(); }
    GameObject Poison = GameObject.Find("GhoulPoison");


    void Update()
    {
        NowAttackingTime += Time.deltaTime;
        if (Distance() < AttackRange && AttackingTime <= NowAttackingTime)
        {
            if (GameObject.Find("Player").GetComponent<Player>().Player_Current_HP >= 0)
            {
                GameObject.Find("Player").GetComponent<Player>().Player_Current_HP -= Strength;
                Debug.Log("플레이어가 " + gameObject.name + "에게 " + Strength + "만큼의 피해를 받았습니다.");
            }
            NowAttackingTime = 0;
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && HP > 0)
        {
            HP -= collision.gameObject.GetComponent<Bullet>().Bullet_Damage;
            Debug.Log(gameObject.name + "가 "+ collision.gameObject.GetComponent<Bullet>().Bullet_Damage + "만큼의 피해를 받았습니다.");
            if (HP <= 0)
            {
                if (gameObject.name == "Ghoul") 
                    Instantiate(Poison, this.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
