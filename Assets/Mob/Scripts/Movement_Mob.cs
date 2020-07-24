using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Mob : MonoBehaviour
{
    public float Range;
    public float velocity;

    Vector2 PlayerPos;
    void Update()
    {
        PlayerPos = (Vector2)GameObject.Find("Player").transform.position;
        if (Distance() > Range)
        {
            transform.position =
            Vector2.MoveTowards(transform.position,
                                PlayerPos,
                                velocity * Time.deltaTime);
        }
        Rotate();
    }
    public float Distance()
    {
        float X = transform.position.x - PlayerPos.x;
        float Y = transform.position.y - PlayerPos.y;
        return Mathf.Sqrt(X * X + Y * Y);
    }

    void Rotate()
    {
        Vector2 direction;
        direction = PlayerPos - (Vector2)transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.Rotate(0, 90, -90);
    }
}
