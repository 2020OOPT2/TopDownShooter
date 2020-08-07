using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival_Time : MonoBehaviour
{
    //생존 시간 변수
    public Text SurvivalTimeText;
    public static float SurvivalTime = 0;
    public static double STime;

    // Start is called before the first frame update
    void Start()
    {
        SurvivalTimeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float CurHP = GameObject.Find("Player").GetComponent<Player>().Player_Current_HP;
        
        if(CurHP > 0)
        {
            SurvivalTime += Time.deltaTime;
        }
        STime = Math.Round(SurvivalTime, 2);
        SurvivalTimeText.text = "Time: " + STime.ToString();
    }
}
