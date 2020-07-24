using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack_Skeleton : MonoBehaviour
{
    public GameObject Arrow;
    public float ShootingTime;
    public float ShotRange;
    float Distance() { return GameObject.Find("Skeleton").GetComponent<Movement_Mob>().Distance(); }
    float NowShootingTime = 0;


    void Update()
    {
        //화살을 쏘는 코드
        NowShootingTime += Time.deltaTime;
        if (Distance() < ShotRange && ShootingTime <= NowShootingTime){
            Instantiate(Arrow, this.transform.position, Quaternion.identity);
            NowShootingTime = 0;
        }
    }
}
