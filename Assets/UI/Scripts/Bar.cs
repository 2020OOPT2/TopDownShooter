using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider HPBar;
    public Slider StaminaBar;
    public Slider BulletTimeBar;
    

    void Start()
    {
        float CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        float MaxHP = GameObject.Find("Player").GetComponent<Player>().Player_Max_HP;
        float CurStamina = GameObject.Find("Player").GetComponent<Player>().Player_Current_Stamina;
        float MaxStamina = GameObject.Find("Player").GetComponent<Player>().Player_Max_Stamina;
        float MaxTimeForce = GameObject.Find("Player").GetComponent<Player_Time_Control>().Max_Time_Force;
        float CurTimeForce = GameObject.Find("Player").GetComponent<Player_Time_Control>().Cur_Time_Force;

        HPBar.value = CurHP / MaxHP;
        StaminaBar.value = CurStamina / MaxStamina;
        BulletTimeBar.value = CurTimeForce / MaxTimeForce;
    }

    void Update()
    {
        float CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        float MaxHP = GameObject.Find("Player").GetComponent<Player>().Player_Max_HP;
        float CurStamina = GameObject.Find("Player").GetComponent<Player>().Player_Current_Stamina;
        float MaxStamina = GameObject.Find("Player").GetComponent<Player>().Player_Max_Stamina;
        float MaxTimeForce = GameObject.Find("Player").GetComponent<Player_Time_Control>().Max_Time_Force;
        float CurTimeForce = GameObject.Find("Player").GetComponent<Player_Time_Control>().Cur_Time_Force;
        HPBar.value = CurHP / MaxHP;
        StaminaBar.value = CurStamina / MaxStamina;
        BulletTimeBar.value = CurTimeForce / MaxTimeForce;
        //Debug.Log(HPBar.value);
        //Debug.Log(StaminaBar.value);
    }

}
