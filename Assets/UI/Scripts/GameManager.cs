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
}
