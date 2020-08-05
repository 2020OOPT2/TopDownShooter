using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameRestart()
    {
        Survival_Time.SurvivalTime = 0;
        Kill_Count.KillCount = 0;
        Application.LoadLevel("UIScene");
    }

    public AudioClip Death_SE;
    AudioSource Audio;
    private void Awake()
    {
         Audio = GetComponent<AudioSource>();
    }

    public void Death_Sound()
    {
        Audio.Play();
    }

    /*  폐기된 코드 / 사유 : 일시정지 해 놓은 상태에서도 쿨타임을 돌림.

    public GameObject Pl;
    public bool Is_Unbeatable = false;
    public List<bool> CanShoot = new List<bool>();

    public void Initiate(int Bullet_Num)
    {
        for (int i = 0; i < Bullet_Num; i++) // 각 총알 별 발사 가능 여부를 담는 리스트
        {
            CanShoot.Add(true);
        }
    }
    public void Cooldown(int bul_kind)
    {
        StartCoroutine(Bullet_CoolDown_Manager2(bul_kind));
    }

    public void UnBeatable(float Unbeatable_Time)
    {
        StartCoroutine(Unbeatable_State_Manager2(Unbeatable_Time));
    }


    public IEnumerator Bullet_CoolDown_Manager2(int bullet_kind) // 총알의 종류마다 발사 쿨타임을 따로 돌리게 만들어 줍니다.
    {
        GameObject bullet = GameObject.Find("Player").GetComponent<Player_Bullet_Control>().Select_Bullet(bullet_kind);
        float cooldown = bullet.GetComponent<Bullet>().Reload_Time;
        Debug.Log("GameMa" + cooldown);
        CanShoot[bullet_kind - 1] = false;
        yield return new WaitForSeconds(cooldown);
        Debug.Log("장전 완료");
        CanShoot[bullet_kind - 1] = true;
    }

    public IEnumerator Unbeatable_State_Manager2(float Unbeatable_Time) // 무적 시간을 관리해 줍니다.
    {
        GameObject.Find("Player").GetComponent<Player>().Is_Unbeatable = true;
        GameObject.Find("Player").GetComponent<Player_Material_Control>().Change_State_ToUnbeatable();
        yield return new WaitForSeconds(Unbeatable_Time);
        GameObject.Find("Player").GetComponent<Player>().Is_Unbeatable = false;
        GameObject.Find("Player").GetComponent<Player_Material_Control>().Change_State_ToDefault();
    }



    public IEnumerator Bullet_CoolDown_Manager(int bullet_kind) // 총알의 종류마다 발사 쿨타임을 따로 돌리게 만들어 줍니다.
    {
        GameObject bullet = GameObject.Find("Player").GetComponent<Player_Bullet_Control>().Select_Bullet(bullet_kind);
        float cooldown = bullet.GetComponent<Bullet>().Reload_Time;
        Debug.Log("GameMa" + cooldown);
        GameObject.Find("Player").GetComponent<Player>().CanShoot[bullet_kind - 1] = false;
        yield return new WaitForSeconds(cooldown);
        Debug.Log("장전 완료");
        Debug.Log(GameObject.Find("Canvas").transform.Find("Player"));
        GameObject.Find("Canvas").transform.Find("Player").GetComponent<Player>().CanShoot[bullet_kind - 1] = true;
    }

    public IEnumerator Unbeatable_State_Manager(float Unbeatable_Time) // 무적 시간을 관리해 줍니다.
    {
        GameObject.Find("Player").GetComponent<Player>().Is_Unbeatable = true;
        GameObject.Find("Player").GetComponent<Player_Material_Control>().Change_State_ToUnbeatable();
        yield return new WaitForSeconds(Unbeatable_Time);
        GameObject.Find("Player").GetComponent<Player>().Is_Unbeatable = false;
        GameObject.Find("Player").GetComponent<Player_Material_Control>().Change_State_ToDefault();
    }*/
}
