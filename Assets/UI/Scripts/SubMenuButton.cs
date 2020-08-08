using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    public GameObject SubMenu;
    public GameObject IngameScreen;
    public GameObject IngameScreenUI;
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && SubMenu.activeInHierarchy) 
        {
            Debug.Log("메뉴 없어짐");          
            SubMenu.SetActive(false);
            IngameScreen.SetActive(true);
            IngameScreenUI.SetActive(true);
        }    
        else if(Input.GetButtonDown("Cancel") && !SubMenu.activeInHierarchy) 
        {
            Debug.Log("메뉴 뜸");
            SubMenu.SetActive(true);
            IngameScreen.SetActive(false);
            IngameScreenUI.SetActive(false);
        }
    }
    public void OnClickToggle()
    {
        Debug.Log("메뉴 없어짐");
        SubMenu.SetActive(false);
        IngameScreen.SetActive(true);
        IngameScreenUI.SetActive(true);
    }
}
