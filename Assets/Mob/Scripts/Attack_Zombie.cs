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
    private void OnTriggerEnter2D(Collider2D collision) //총알에 Is trigger가 체크되어 있으므로 OnTriggerEnter2D로 변경하였습니다.
    {
        if (collision.gameObject.tag == "Bullet" && ZombieHP > 0)
        {   // Find("Bullet")을 사용 시 NullReference 에러가 발생하여 충돌한 오브젝트의 태그를 활용하는 방식으로 변경하였습니다.
            ZombieHP -= collision.gameObject.GetComponent<Bullet>().Bullet_Damage;
            Debug.Log("좀비가"+ collision.gameObject.GetComponent<Bullet>().Bullet_Damage + "만큼의 피해를 받았습니다.");
            if (ZombieHP <= 0) Destroy(gameObject);
        }
    }
}
