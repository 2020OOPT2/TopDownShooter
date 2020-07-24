using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Player_Max_HP;
    public float Player_Current_HP;
    public float Player_Max_Stamina;
    private float Player_Current_Stamina;
    public float Stamina_Decrease_Speed;
    public float Stamina_Regen_Speed;

    private Vector2 User_Move_Dir;
    private Vector3 Mouse_Position;
    private float Move_Speed;
    private float Required_Minimum_Stamina = 0;
    public float Normal_Speed;
    public float Sprint_Speed;
    private float Angle; // 플레이어 오브젝트와 마우스포인터 사이의 각도

    public float Bullet_Speed;
    public float Shoot_Delay; // 발사 후 다음 발사 까지의 딜레이
    private float Delay_Timer = 0;

    private Rigidbody2D Pl_Rigid;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Awake()
    {
        Player_Current_HP = Player_Max_HP;
        Move_Speed = Normal_Speed;
        Player_Current_Stamina = Player_Max_Stamina;
        //Bullet = GameObject.FindGameObjectWithTag("Bullet");
        Mouse_Position = Input.mousePosition;
        Pl_Rigid = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Player_Current_HP > 0)
        {
            Player_Move();
            Player_Rotate();
            Indicator();
            Delay_Timer += Time.deltaTime;
            if (Delay_Timer > Shoot_Delay && Input.GetKey(KeyCode.Space)) // Space를 통해 발사, Shoot_Delay를 통해 연사 속도를 조절합니다.
            {
                Fire_Bullet();
                Delay_Timer = 0;
            }
            //Player_Current_HP -= 10 * Time.deltaTime;
        }
        else
        {
            Pl_Rigid.velocity = new Vector2(0, 0);
            Debug.Log("죽었습니다!"); 
        }
    }

    private void Indicator()
    {
        Debug.Log("현재 체력 : " + Player_Current_HP);
        Debug.Log("현재 스태미너 : " + Player_Current_Stamina);
    }

    private void Player_Sprint(bool Is_Sprinting) // 스프린트 여부에 따른 플레이어 이동 속력 변화, 스태미너 관리를 담당합니다.
    {
        if (Is_Sprinting)
        {
            Required_Minimum_Stamina = 0;
            Move_Speed = Sprint_Speed;
            Debug.Log("현재 열심히 달리는 중입니다.");
            if (Player_Current_Stamina - Time.deltaTime * Stamina_Decrease_Speed <= 0)
            {
                Player_Current_Stamina = 0;
                Required_Minimum_Stamina = 10;
                // 플레이어의 스태미너가 0을 찍으면 10으로 회복될 때까지 Is_Sprinting이 false가 되어 달리지 못합니다.             
            }
            else
                Player_Current_Stamina -= Time.deltaTime * Stamina_Decrease_Speed;
        }
        else
        {
            Move_Speed = Normal_Speed;
            if(Player_Current_Stamina <= Player_Max_Stamina)
                Player_Current_Stamina += Stamina_Regen_Speed * Time.deltaTime;
        }
            
    }   
    private void Player_Move() // 플레이어의 움직임 + 달리기 기능을 담당합니다.
    {
        Player_Sprint(Input.GetKey(KeyCode.LeftShift) && Player_Current_Stamina > Required_Minimum_Stamina);
        Move();
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
        fired_Bullet_Rb.velocity = new Vector2(Mouse_Position.x - this.transform.position.x,
                                               Mouse_Position.y - this.transform.position.y).normalized * Bullet_Speed;
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
            User_Move_Dir += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            User_Move_Dir += new Vector2(0, -1);
        if (Input.GetKey(KeyCode.A))
            User_Move_Dir += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.D))
            User_Move_Dir += new Vector2(1, 0);
        Pl_Rigid.velocity = User_Move_Dir.normalized * Move_Speed;
        User_Move_Dir = new Vector2(0, 0);
    }
}
