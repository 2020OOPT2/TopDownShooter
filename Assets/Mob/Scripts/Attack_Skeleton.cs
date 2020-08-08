using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack_Skeleton : MonoBehaviour
{
    public float AttackRange;
    public float AttackingTime;
    public float Strength;
    public float HP;
    public GameObject Arrow;
    public float ShootingTime;
    public float ShotRange;

    float Time_Damaged = 0;
    bool Damaged_velocity = false;
    float Time_Attacking = 0;
    bool Attacking_velocity = false;
    public float ChangeVelocity;

    float Distance() { return this.GetComponent<Movement_Mob>().Distance(); }
    float NowShootingTime = 0;
    float NowAttackingTime = 0;

    void Update()
    {
        if (Damaged_velocity == true) // 데미지를 입었는가
        {
            Time_Damaged += Time.deltaTime;
            if (Time_Damaged >= 0.5)
            {
                this.GetComponent<Movement_Mob>().velocity = this.GetComponent<Movement_Mob>().Rvelocity;
                Damaged_velocity = false;
            }
        }
        if (Attacking_velocity == true) // 공격을 하였는가
        {
            Time_Attacking += Time.deltaTime;
            if (Time_Attacking >= 0.5)
            {
                this.GetComponent<Movement_Mob>().velocity = this.GetComponent<Movement_Mob>().Rvelocity;
                Attacking_velocity = false;
            }
        }

        NowShootingTime += Time.deltaTime;

        //if (Distance() >= AttackRange // 화살을 쏨
        //    && Distance() < ShotRange && ShootingTime <= NowShootingTime)
        //{
            Instantiate(Arrow, this.transform.position, Quaternion.identity);
            NowShootingTime = 0;
        //}

        NowAttackingTime += Time.deltaTime;
        if (Distance() < AttackRange && AttackingTime <= NowAttackingTime)
        {
            if (GameObject.Find("Player").GetComponent<Player>().Player_Current_HP >= 0)
            {
                //GameObject.Find("Player").GetComponent<Player>().Player_Current_HP -= Strength; <- 기존 코드
                GameObject.Find("Player").GetComponent<Player>().Player_Damaged(Strength);
                if (Attacking_velocity == false) // 공격을 함
                {
                    Attacking_velocity = true;
                    Time_Attacking = 0;
                    this.GetComponent<Movement_Mob>().velocity += ChangeVelocity;
                }
                Debug.Log("플레이어가 " + this.gameObject.name + "에게 " + Strength + "만큼의 피해를 받았습니다.");
            }
            NowAttackingTime = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && HP > 0)
        {
            HP -= collision.gameObject.GetComponent<Bullet>().Bullet_Damage;
            if (Damaged_velocity == false) // 데미지를 입음
            {
                Damaged_velocity = true;
                Time_Damaged = 0;
                this.GetComponent<Movement_Mob>().velocity -= ChangeVelocity;
            }

            Debug.Log(gameObject.name + "가 " + collision.gameObject.GetComponent<Bullet>().Bullet_Damage + "만큼의 피해를 받았습니다.");
            if (HP <= 0)
            {
                PotionGenerate();
                Destroy(gameObject);
                Kill_Count.KillCount += 1;
            }
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