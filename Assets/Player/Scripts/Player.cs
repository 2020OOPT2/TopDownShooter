using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Player_Max_HP;
    public float Player_Current_HP;
    public float Player_Max_Stamina;
    public float Player_Current_Stamina;
    public float Stamina_Decrease_Speed;
    public float Stamina_Regen_Speed;

    private Vector3 Mouse_Position;
    private float Move_Speed;
    public float Required_Minimum_Stamina = 0;
    public float Normal_Speed;
    public float Sprint_Speed;
    private float Angle; // 플레이어 오브젝트와 마우스포인터 사이의 각도

    public bool Is_Unbeatable = false;
    private float Bullet_Speed;
    public float Damage_Delay; // 데미지 받고난 뒤 무적시간
    private float Damage_Timer = 0;

    private int Bullet_Kind = 1;
    public List<bool> CanShoot;
    public List<float> DelayTimer;
    GameObject[] bullet_array;


    public AudioClip SE1;
    public AudioClip SE2;
    public AudioClip Death_SE;
    bool Just_One_Play = true; // 죽는 사운드를 한 번만 재생시키도록 하기 위함.
    public AudioSource Player_Audio;
    // Start is called before the first frame update


    void Start()
    {
        Player_Audio = this.GetComponent<AudioSource>();
        Player_Audio.clip = SE1;
        CanShoot = new List<bool>();
        Player_Current_HP = Player_Max_HP;
        Move_Speed = Normal_Speed;
        Player_Current_Stamina = Player_Max_Stamina;
        this.GetComponent<Player_Material_Control>().Change_State_ToDefault();
        bullet_array = GetComponent<Player_Bullet_Control>().Bullets; // 총알 오브젝트를 담는 배열
        for (int i = 0; i < bullet_array.Length; i++) // 각 총알 별 발사 가능 여부를 담는 리스트
        {
            CanShoot.Add(true);
            DelayTimer.Add(0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("현재 Player 스크립트의 상태 : " + CanShoot[0]);
        if (Player_Current_HP > 0)
        {
            Player_Move();
            Player_Rotate();
            Bullet_Selection();
            Bullet_CoolDown_Manager();
            Unbeatable_State_Manager2();
            if (CanShoot[Bullet_Kind - 1] &&
                Input.GetKey(KeyCode.Mouse0)) // 좌클릭을 통해 발사합니다.
            {
                Fire_Bullet_Fixed(); // fire 후 canshoot을 false로 변경
                CanShoot[Bullet_Kind - 1] = false;
            }
            else if (!CanShoot[Bullet_Kind - 1] && Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("지금은 못쏴요..."); 
            }
        }
        else
        {
            GetComponent<Player_Material_Control>().Dead();
            //Debug.Log("죽었습니다!");
            if(Just_One_Play)
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Death_Sound();
                Just_One_Play = false;
            }
        }
    }
    private void Bullet_CoolDown_Manager() // 총알의 종류마다 발사 쿨타임을 따로 돌리게 만들어 줍니다.
    {
        for (int bullet_kind= 0; bullet_kind < bullet_array.Length; bullet_kind++) 
        {
            float cooldown_time = this.GetComponent<Player_Bullet_Control>().Select_Bullet(bullet_kind+1).GetComponent<Bullet>().Reload_Time;
            if (CanShoot[bullet_kind] == false)
            {
                DelayTimer[bullet_kind] += Time.deltaTime;
                if (DelayTimer[bullet_kind] >= cooldown_time)
                {
                    DelayTimer[bullet_kind] = 0f;
                    CanShoot[bullet_kind] = true;
                    Debug.Log("장전 완료");
                }
            }
        }
    }
    private void Unbeatable_State_Manager2() // 무적 시간을 관리해 줍니다.
    {   // 맞는 순간 Is_Unbeatable = true 가 됨.
        if(Is_Unbeatable == true)
        {
            Damage_Timer += Time.deltaTime;
            if(Damage_Timer >= Damage_Delay)
            {
                Debug.Log("무적이 해제되었습니다");
                Is_Unbeatable = false;
                this.GetComponent<Player_Material_Control>().Change_State_ToDefault();
                Damage_Timer = 0;
            }
        }
    }
    
    public void Player_Damaged(float Mob_Strength)
    {
        if (!Is_Unbeatable) // 무적이 아닐 경우
        {
            Player_Current_HP -= Mob_Strength;
            if (Player_Current_HP > 0)
            {
                Is_Unbeatable = true;
                this.GetComponent<Player_Material_Control>().Change_State_ToUnbeatable();
            }
            Debug.Log("플레이어가 맞았습니다!");
        }
        else
        {
            Debug.Log("지금은 무적입니다!");
        }
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
            if (Player_Current_Stamina <= Player_Max_Stamina)
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
        Angle = Mathf.Atan2((Mouse_Position.y - this.transform.position.y), (Mouse_Position.x - this.transform.position.x)) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle-90));
    }

    private void Bullet_Selection() // 발사할 총알의 종류를 선택합니다.
    {
        if (Input.GetKey(KeyCode.Alpha1))
        { 
            Bullet_Kind = 1;
            Player_Audio.clip = SE1;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        { 
            Bullet_Kind = 2;
            Player_Audio.clip = SE2;
        }
    }
    private void Fire_Bullet_Fixed() // 총알 오브젝트를 생성하고, 마우스 포인터를 향해 발사합니다. Bullet_Speed를 통해 총알 속도를 조절합니다.
    {                                // 총알의 종류를 선택할 수 있습니다.
        Player_Audio.Play(); 
        GameObject bullet = GetComponent<Player_Bullet_Control>().Select_Bullet(Bullet_Kind);
        Bullet_Speed = bullet.GetComponent<Bullet>().Bullet_Speed;
        GameObject fired_Bullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        if(GameObject.Find("IngameScreen") != null)
            fired_Bullet.transform.parent = GameObject.Find("IngameScreen").transform; // Player Scene에서는 동작하지 않을 코드임.
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
}
