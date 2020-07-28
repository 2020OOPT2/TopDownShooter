using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Material_Control : MonoBehaviour
{
    Animator Pl_Ani;
    SpriteRenderer Pl_Sprite;
    
    void Awake()
    {
        Pl_Ani = this.GetComponent<Animator>();
        Pl_Sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            Pl_Ani.SetBool("Is_Walking", true);
        else
            Pl_Ani.SetBool("Is_Walking", false);

        if (Input.GetKey(KeyCode.LeftShift) && GetComponent<Player>().Player_Current_Stamina > GetComponent<Player>().Required_Minimum_Stamina)
            Pl_Ani.SetBool("Is_Sprinting", true);
        else
            Pl_Ani.SetBool("Is_Sprinting", false);
    }

    public void Dead()
    {
        Pl_Ani.SetBool("Is_Dead", true);
    }

    public void Change_State_ToDefault()
    {
        Pl_Sprite.color = new Color(1, 1, 1, 1);
    }

    public void Change_State_ToUnbeatable()
    {
        Pl_Sprite.color = new Color(1, 1, 1, 0.4f);
    }
}

/* 기존 코드
 * public Material Default;
    public Material Is_Unbeatable;
    private MeshRenderer Pl_Mesh; // 무적 효과를 위해 임시로 사용.
    // Start is called before the first frame update
    void Awake()
    {
        Pl_Mesh = this.GetComponent<MeshRenderer>();
    }

    public void Change_State_ToUnbeatable() { Pl_Mesh.material = Is_Unbeatable; }
    public void Change_State_ToDefault() { Pl_Mesh.material = Default; }
 */
