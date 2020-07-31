using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ghoul : MonoBehaviour
{
    public float AttackRange;
    public float AttackingTime;
    public float Strength;
    public float HP;
    float NowAttackingTime = 0;
    float Distance() { return this.GetComponent<Movement_Mob>().Distance(); }
    public GameObject Poison;

    void Update()
    {
        NowAttackingTime += Time.deltaTime;
        if (Distance() < AttackRange && AttackingTime <= NowAttackingTime)
        {
            if (GameObject.Find("Player").GetComponent<Player>().Player_Current_HP >= 0)
            {
                //GameObject.Find("Player").GetComponent<Player>().Player_Current_HP -= Strength; <- 기존 코드
                GameObject.Find("Player").GetComponent<Player>().Player_Damaged(Strength);
                Debug.Log("플레이어가 " + this.gameObject.name + "에게 " + Strength + "만큼의 피해를 받았습니다.");
            }
            NowAttackingTime = 0;
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && HP >= -1)
        {
            HP -= collision.gameObject.GetComponent<Bullet>().Bullet_Damage;
            Debug.Log(gameObject.name + "가 " + collision.gameObject.GetComponent<Bullet>().Bullet_Damage + "만큼의 피해를 받았습니다.");
        }
        if (HP <= 0)
        {
            PotionGenerate();
            Vector3 PoisonPos = this.transform.position;
            PoisonPos.z += 2;
            Instantiate(Poison, PoisonPos, Quaternion.identity);
            Destroy(gameObject);
            Kill_Count.KillCount += 1;
        }
    }

    public GameObject Potion;
    public float PotionGenerating;
    void PotionGenerate()
    {
        float temp = Time.time * 100f;
        Random.InitState((int)temp);
        int a = Random.Range(0, 100);
        Debug.Log("랜덤변수는 " + a + "입니다.");
        if (a < PotionGenerating)
        {
            Instantiate(Potion, this.transform.position, Quaternion.identity);
        }
    }

    public GameObject Potion;
    public float PotionGenerating;
    void PotionGenerate()
    {
        float temp = Time.time * 100f;
        Random.InitState((int)temp);
        int a = Random.Range(0, 100);
        Debug.Log("랜덤변수는 " + a + "입니다.");
        if (a < PotionGenerating)
        {
            Instantiate(Potion, this.transform.position, Quaternion.identity);
        }
    }

    public GameObject Potion;
    public float PotionGenerating;
    void PotionGenerate()
    {
        float temp = Time.time * 100f;
        Random.InitState((int)temp);
        int a = Random.Range(0, 100);
        Debug.Log("랜덤변수는 " + a + "입니다.");
        if (a < PotionGenerating)
        {
            Instantiate(Potion, this.transform.position, Quaternion.identity);
        }
    }
}
