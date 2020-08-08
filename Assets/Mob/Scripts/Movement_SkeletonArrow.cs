using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_SkeletonArrow : MonoBehaviour
{
    public float velocity;
    public float Damage;
    Vector2 followPos;

    void Awake()
    {
        followPos = GameObject.Find("Player").transform.position;
        Rotate();
        if (GameObject.Find("IngameScreen") != null)
            transform.parent = GameObject.Find("IngameScreen").transform;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Player>().Player_Damaged(Damage);
            Debug.Log("플레이어가 " + Damage + "만큼의 피해를 받았습니다.");
        }
        Destroy(gameObject);
    }
}
