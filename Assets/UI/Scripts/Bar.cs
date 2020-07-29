using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider HPBar;
    public Slider StaminaBar;
    

    void Start()
    {
        float CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        float MaxHP = GameObject.Find("Player").GetComponent<Player>().Player_Max_HP;
        float CurStamina = GameObject.Find("Player").GetComponent<Player>().Player_Current_Stamina;
        float MaxStamina = GameObject.Find("Player").GetComponent<Player>().Player_Max_Stamina;

        HPBar.value = CurHP / MaxHP;
        StaminaBar.value = CurStamina / MaxStamina;
    }

    void Update()
    {
        float CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        float MaxHP = GameObject.Find("Player").GetComponent<Player>().Player_Max_HP;
        float CurStamina = GameObject.Find("Player").GetComponent<Player>().Player_Current_Stamina;
        float MaxStamina = GameObject.Find("Player").GetComponent<Player>().Player_Max_Stamina;
        HPBar.value = CurHP / MaxHP;
        StaminaBar.value = CurStamina / MaxStamina;
        Debug.Log(HPBar.value);
        Debug.Log(StaminaBar.value);
    }

}
