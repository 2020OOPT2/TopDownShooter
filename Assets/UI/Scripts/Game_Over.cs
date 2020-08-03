using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over : MonoBehaviour
{
    float AfterDeathTime = 0;
    public GameObject IngameScreen;
    public GameObject GameOver;

    void Update()
    {
        float CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        if (CurHP <= 0)
        {
            AfterDeathTime = AfterDeathTime + Time.deltaTime;                  
            Debug.Log("AfterDeathTime" + AfterDeathTime);
            if (AfterDeathTime >= 2)
            {   
                GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponentInChildren<AudioSource>().Stop();//브금 멈춤
                IngameScreen.SetActive(false);
                GameOver.SetActive(true);
            }

        }
    }
}
