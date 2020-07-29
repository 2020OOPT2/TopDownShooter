using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    public GameObject SubMenu;
    public GameObject IngameScreen;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SubMenu.SetActive(true);
            IngameScreen.SetActive(false);
            //타임스케일을 0으로 만든다?
        }
    }
}
