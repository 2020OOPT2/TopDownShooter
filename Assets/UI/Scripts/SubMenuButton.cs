using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubMenuButton : MonoBehaviour
{
    public GameObject SubMenu;
    public GameObject IngameScreen;
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && SubMenu.activeInHierarchy) 
        {
            Debug.Log("메뉴 없어짐");         
            SubMenu.SetActive(false);
            IngameScreen.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Time_Control>().Start_this_CoR();
            
        }    
        else if(Input.GetButtonDown("Cancel") && !SubMenu.activeInHierarchy) 
        {
            Debug.Log("메뉴 뜸");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Time_Control>().Stop_this_CoR();
            SubMenu.SetActive(true);
            IngameScreen.SetActive(false);           
        }

    }
    public void OnClickToggle()
    {
        Debug.Log("메뉴 없어짐");
        SubMenu.SetActive(false);
        IngameScreen.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Time_Control>().Start_this_CoR();
    }
    //인게임 -> ESC를 눌렀을 때 메뉴가 나와야 한다
    // ESC를 눌렀을 때, 메뉴가 보이면서 TImeScale = 0으로 만든다.
    

    //메뉴에서는 -> Continue를 눌렀을 때 인게임 화면이 나와야 한다. 인게임 화면이 나온다 => TimeScale이 바뀐다.
    // ESC를 눌렀을 떄, 메뉴가 사라지면서 TImeScale = 1;로 되어야 한다.
}
