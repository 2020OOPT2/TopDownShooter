using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Time_Control : MonoBehaviour
{
    public float Max_Time_Force;
    public float Cur_Time_Force;
    private bool Is_Time_Delaying = false;
    AudioSource AU1;
    AudioSource AU2;
    AudioSource AU3;

    // Start is called before the first frame update
    void Start()
    {
        Cur_Time_Force = Max_Time_Force;
        StartCoroutine(Time_Control());
        AU1 = this.GetComponent<AudioSource>();
        AU2 = transform.GetChild(0).GetComponent<AudioSource>();
        AU3 = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // 시간 조작 토글키는 스페이스 키입니다.
        {                                  
            if (!Is_Time_Delaying && Cur_Time_Force > 0)
                Is_Time_Delaying = true;
            else if (Is_Time_Delaying)
                Is_Time_Delaying = false;
        }
        if(Is_Time_Delaying)
        {
            AU1.pitch = 0.25f;
            AU2.pitch = 0.5f;
            AU3.pitch = 0.5f;
        }
        else
        {
            AU1.pitch = 1;
            AU2.pitch = 1;
            AU3.pitch = 1;
        }        
    }
    public void Stop_this_CoR() // 서브 메뉴 스크립트에서 코루틴을 활성/비활성하기 위한 함수
    {
        StopCoroutine("Time_Control");
    }
    public void Start_this_CoR()
    {
        StartCoroutine(Time_Control());
    }
    public IEnumerator Time_Control()
    {
        while(true)
        {
            if (Is_Time_Delaying && Cur_Time_Force > 0)
            {
                Cur_Time_Force -= 2;
                Time.timeScale = 0.25f;
                Debug.Log("현재 타임 포스 : " + Cur_Time_Force);
                Debug.Log(Cur_Time_Force);
                yield return new WaitForSecondsRealtime(0.1f);
            }
            else
            {
                if (Cur_Time_Force < Max_Time_Force)
                {
                    Cur_Time_Force += 1;
                    Time.timeScale = 1;
                    Is_Time_Delaying = false;
                    Debug.Log("현재 타임 포스 : "+Cur_Time_Force);
                    Debug.Log("시간이 정상적으로 흐릅니다.");
                    yield return new WaitForSecondsRealtime(0.1f);
                }
                else
                {
                    Is_Time_Delaying = false;
                    Debug.Log("현재 타임 포스 : " + Cur_Time_Force);
                    yield return new WaitForSecondsRealtime(0.1f);                    
                }
            }
        }        
    }
}
