using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    GameObject Player;
    public float Calibrate; // 카메라 시점 내에서 플레이어의 위치를 조정하기 위한 변수입니다.
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() // 카메라가 플레이어를 따라가게 만듭니다.
    {
        this.transform.position = new Vector3(  Player.transform.position.x, 
                                                Player.transform.position.y + Calibrate, 
                                                this.transform.position.z);       
    }
}
