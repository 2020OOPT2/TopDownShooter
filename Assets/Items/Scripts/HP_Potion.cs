using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Potion : MonoBehaviour
{
    public float Heal_Quantity;
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
