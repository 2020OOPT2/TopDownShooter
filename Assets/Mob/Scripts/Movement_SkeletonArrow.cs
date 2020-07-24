using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_SkeletonArrow : MonoBehaviour
{
    public float velocity;

    Vector2 followPos;

    void Awake()
    {
        followPos = GameObject.Find("Player").transform.position;
        Rotate();
    }

    void Update()
    {
        transform.position = 
        Vector2.MoveTowards(transform.position,
                         followPos,
                         velocity * Time.deltaTime);


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
