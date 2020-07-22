using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 User_Move_Input;
    private Rigidbody2D Pl_Rigid;
    public float Move_Speed;
    private Vector3 Mouse_Position;
    public float Bullet_Speed;
    public float Shoot_Delay; // 발사 후 다음 발사 까지의 딜레이
    private float Delay_Timer = 0;
    private float Angle; // 플레이어 오브젝트와 마우스포인터 사이의 각도
    GameObject Bullet;
    // Start is called before the first frame update
    void Awake()
    {
        Bullet = GameObject.FindGameObjectWithTag("Bullet");
        Mouse_Position = Input.mousePosition;
        Pl_Rigid = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Move2();
        Player_Rotate();
        Delay_Timer += Time.deltaTime;
        if (Delay_Timer > Shoot_Delay && Input.GetKey(KeyCode.Space)) // Space를 통해 발사, Shoot_Delay를 통해 연사 속도를 조절합니다.
        {
            Fire_Bullet();
            Delay_Timer = 0;
        }
    }


    private void Player_Rotate() // 플레이어 오브젝트가 마우스 포인터를 바라보게 만듭니다.
    {
        Mouse_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Angle = Mathf.Atan2((Mouse_Position.y - this.transform.position.y), (Mouse_Position.x - this.transform.position.x))*Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle));
    }

    private void Fire_Bullet() // 총알 오브젝트를 생성하고, 마우스 포인터를 향해 발사합니다. Bullet_Speed를 통해 총알 속도를 조절합니다.
    {
        GameObject fired_Bullet = Instantiate(Bullet, this.transform.position, this.transform.rotation);
        Rigidbody2D fired_Bullet_Rb = fired_Bullet.GetComponent<Rigidbody2D>();
        fired_Bullet_Rb.velocity = (Mouse_Position - this.transform.position + new Vector3(0,0,20)).normalized * Bullet_Speed;
        // 0,0,20 벡터를 더하는 이유는 마우스 포지션 벡터의 z방향 성분 때문에 정규화 벡터의 크기가 1이 되지 않는 문제를 피하기 위함입니다.
    }

    private void Move() // WSAD를 사용해 플레이어를 움직입니다. 오브젝트의 포지션을 변경합니다.
    {
        if (Input.GetKey(KeyCode.W))
            this.transform.position += new Vector3(0, 1, 0) * Move_Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            this.transform.position += new Vector3(0, -1, 0) * Move_Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            this.transform.position += new Vector3(-1, 0, 0) * Move_Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(1, 0, 0) * Move_Speed * Time.deltaTime;
    }
    private void Move2() // WSAD를 사용해 플레이어를 움직입니다. 오브젝트의 속도를 변경합니다. 뭐가 더 적당할지 몰라 다 만들어 놓았습니다.
    {
        if (Input.GetKey(KeyCode.W))
            User_Move_Input += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            User_Move_Input += new Vector2(0, -1);
        if (Input.GetKey(KeyCode.A))
            User_Move_Input += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.D))
            User_Move_Input += new Vector2(1, 0);
        Pl_Rigid.velocity = User_Move_Input.normalized * Move_Speed;
        User_Move_Input = new Vector2(0, 0);

    }
}
