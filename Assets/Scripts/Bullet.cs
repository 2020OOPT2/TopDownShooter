using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CircleCollider2D Bullet_Col;
    // Start is called before the first frame update
    void Awake()
    {
        Bullet_Col = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > 20 || this.transform.position.x < -20 || this.transform.position.y > 20 || this.transform.position.y < -20)
            Destroy(this.gameObject); // 총알이 일정 범위를 넘어서면 해당 총알을 지웁니다.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject);
       */  
    }
}
