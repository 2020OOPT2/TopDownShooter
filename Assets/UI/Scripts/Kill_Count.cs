using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill_Count : MonoBehaviour
{
    public Text KillCountText;
    public static float KillCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        KillCountText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        KillCountText.text = "Kill: " + KillCount.ToString();
    }
}
