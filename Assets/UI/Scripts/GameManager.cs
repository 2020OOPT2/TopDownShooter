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
        Application.LoadLevel("UIScene");
    }
}
