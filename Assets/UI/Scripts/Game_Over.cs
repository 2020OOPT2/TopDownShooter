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
            GameObject.Find("Player").GetComponent<Player>().Player_Audio.Play();
            Debug.Log("AfterDeathTime" + AfterDeathTime);
            if (AfterDeathTime >= 2)
            {
                IngameScreen.SetActive(false);
                GameOver.SetActive(true);
            }

        }
    }
}
