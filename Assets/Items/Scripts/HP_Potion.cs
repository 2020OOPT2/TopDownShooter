using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Potion : MonoBehaviour
{
    public float Heal_Quantity;
    public float Time_Destroy;
    float NowTime_Destroy = 0;

    private void Update()
    {
        NowTime_Destroy += Time.deltaTime;
        if (NowTime_Destroy > Time_Destroy)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>().Player_Current_HP + Heal_Quantity
                < collision.gameObject.GetComponent<Player>().Player_Max_HP)
            {
                collision.gameObject.GetComponent<Player>().Player_Current_HP += Heal_Quantity;
                Destroy(this.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Player>().Player_Current_HP = collision.gameObject.GetComponent<Player>().Player_Max_HP;
                Destroy(this.gameObject);
            }
        }
    }
}
