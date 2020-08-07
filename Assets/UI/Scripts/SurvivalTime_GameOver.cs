using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalTime_GameOver : MonoBehaviour
{
    public Text SurvivalTimeGameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SurvivalTimeGameOverText.text = "Time: " + Survival_Time.STime.ToString();
    }
}
