using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount_GameOver : MonoBehaviour
{
    public Text KillCountGameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillCountGameOverText.text = "Kills: " + Kill_Count.KillCount.ToString();
    }
}
