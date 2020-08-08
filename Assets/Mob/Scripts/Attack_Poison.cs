using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Poison : MonoBehaviour
{
    public float Time_Delete;
    float Time_Appear = 0;
    public float AttackingTime;
    float NowAttackingTime = 0;
    public float Velocity;
    public float Strength;

    float Velocity_radius;
    float Velocity_Scale;
    float Rradius;

    private void Awake()
    {
        Rradius = this.GetComponent<CircleCollider2D>().radius;
        this.GetComponent<CircleCollider2D>().radius = 0;
        transform.localScale = new Vector3(0, 0, (float)0.001);
        Velocity_radius = (float)(0.5 / Velocity); // Prefab의 Collider2D에 보면 radius는 0.5이다.
        Velocity_Scale = (float)(Velocity);
    }

    void Update()
    {
        Time_Appear += Time.deltaTime;
        NowAttackingTime += Time.deltaTime;
        if (Time_Delete < Time_Appear)
        {
            Destroy(gameObject);
        }
        if (this.GetComponent<CircleCollider2D>().radius <= Rradius)
        {
            this.GetComponent<CircleCollider2D>().radius += Velocity_radius * Time.deltaTime;
        }
        if (transform.localScale.x <= 1 && transform.localScale.y <= 1)
        {
            transform.localScale = 
            new Vector3(transform.localScale.x + Velocity_Scale * Time.deltaTime,
                            transform.localScale.y + Velocity_Scale * Time.deltaTime,
                            transform.localScale.z);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && NowAttackingTime >= AttackingTime)
        {
            GameObject.Find("Player").GetComponent<Player>().Player_Damaged(Strength);
            Debug.Log("플레이어가 " + Strength + "만큼의 피해를 받았습니다.");
            NowAttackingTime = 0;
        }
    }
}
