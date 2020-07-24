using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CircleCollider2D Bullet_Col;
    public float Bullet_Damage;
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
  
    private void OnTriggerEnter2D(Collider2D collision) // 총알끼리 충돌하는 것을 막기 위해 Is trigger를 체크해 둔 상태입니다.
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy_Bullet") // 이후 벽 등이 추가될 경우 조건이 추가되어야 할 수 있습니다.
        {
            Debug.Log("적을 맞혔습니다!");
            Destroy(this.gameObject);
        }
    }
}
