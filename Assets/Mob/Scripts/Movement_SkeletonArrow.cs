using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_SkeletonArrow : MonoBehaviour
{
    public float velocity;
    //float velocity_Arrow;
    //Boolean Stop;

    Vector2 followPos;

    void Awake()
    {
        followPos = GameObject.Find("Player").transform.position;
        //velocity_Arrow = velocity;
        Rotate();
        //Stop = 0;
    }

    void Update()
    {
        transform.position = 
        Vector2.MoveTowards(transform.position,
                         followPos,
                         velocity * Time.deltaTime); // velocity 치환 velocity_Arrow
        //if (Stop)
        //    velocity_Arrow = 0;
        //else velocity_Arrow = velocity;

        if (Distance() < 0.2)
            Destroy(gameObject);
    }
    float Distance()
    {
        float X = transform.position.x - followPos.x;
        float Y = transform.position.y - followPos.y;
        return Mathf.Sqrt(X * X + Y * Y);
    }

    void Rotate()
    {
        Vector2 direction;
        direction = followPos - (Vector2) transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.Rotate(0, 90, 90);
    }
}
