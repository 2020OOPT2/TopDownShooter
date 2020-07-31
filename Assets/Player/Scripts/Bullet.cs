using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D Bullet_RB;
    Vector2 vel;
    public float Bullet_Damage;
    public float Bullet_Speed;
    public float Reload_Time;
    // Start is called before the first frame update
    void Start()
    {
        Bullet_RB = this.GetComponent<Rigidbody2D>();
        vel = Bullet_RB.velocity;
        this.transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Bullet_RB.velocity = vel;
    }
  
    private void OnTriggerEnter2D(Collider2D collision) // 총알끼리 충돌하는 것을 막기 위해 Is trigger를 체크해 둔 상태입니다.
    {
        if (collision.gameObject.tag == "Enemy") // 이후 벽 등이 추가될 경우 조건이 추가되어야 할 수 있습니다.
        {
            Debug.Log("적을 맞혔습니다!");
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("총알이 벽에 맞아 파괴됩니다.");
            Destroy(this.gameObject);
        }
    }
}
