using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider HPBar;
    public Slider StaminaBar;
    //Player player = GameObject.Find("Player").GetComponent<Player>();
    float CurHP;
    float MaxHP;
    float CurStamina;
    float MaxStamina;

    void Start()
    {
        CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        MaxHP = GameObject.Find("Player").GetComponent<Player>().Player_Max_HP;
        CurStamina = GameObject.Find("Player").GetComponent<Player>().Player_Current_Stamina;
        MaxStamina = GameObject.Find("Player").GetComponent<Player>().Player_Max_Stamina;

        HPBar.value = CurHP / MaxHP;
        StaminaBar.value = CurStamina / MaxStamina;
    }

    void Update()
    {
        /*CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        MaxHP = GameObject.Find("Player").GetComponent<Player>().Player_Max_HP;
        CurStamina = GameObject.Find("Player").GetComponent<Player>().Player_Current_Stamina;
        MaxStamina = GameObject.Find("Player").GetComponent<Player>().Player_Max_Stamina;*/

        HPBar.value = CurHP / MaxHP;
        StaminaBar.value = CurStamina / MaxStamina;
        Debug.Log(HPBar.value);
        Debug.Log(StaminaBar.value);
    }

}
