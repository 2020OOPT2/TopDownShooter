using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    public GameObject SubMenu;
    public GameObject IngameScreen;
    private bool pause = false;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
        }
        if (pause)
        {
            SubMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            SubMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
