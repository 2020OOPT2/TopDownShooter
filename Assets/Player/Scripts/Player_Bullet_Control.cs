using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Control : MonoBehaviour
{
    public GameObject[] Bullets = new GameObject[2];
  
    public GameObject Select_Bullet(int Bullet_Num)
    {
        return Bullets[Bullet_Num - 1];
    }

    // 총알 오브젝트를 이 스크립트에서 미리 받아온 후 , Player Script에서 누른 버튼에 따라 이 스크립트의 오브젝트를 가져옴.
}
