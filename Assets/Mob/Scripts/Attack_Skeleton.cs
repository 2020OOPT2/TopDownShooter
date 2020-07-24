using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack_Skeleton : MonoBehaviour
{
    public GameObject Arrow;
    public float ShootingTime;
    public float ShotRange;
    float Distance() { return this.GetComponent<Movement_Mob>().Distance(); }
    float NowShootingTime = 0;

    void Update()
    {
        NowShootingTime += Time.deltaTime;

        if (Distance() >= this.GetComponent<Attack>().AttackRange 
            && Distance() < ShotRange && ShootingTime <= NowShootingTime){
            Instantiate(Arrow, this.transform.position, Quaternion.identity);
            NowShootingTime = 0;
        }
    }
}
