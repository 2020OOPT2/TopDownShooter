using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Material_Control : MonoBehaviour
{
    public Material Default;
    public Material Is_Unbeatable;
    private MeshRenderer Pl_Mesh; // 무적 효과를 위해 임시로 사용.
    // Start is called before the first frame update
    void Awake()
    {
        Pl_Mesh = this.GetComponent<MeshRenderer>();
    }

    public void Change_State_ToUnbeatable() { Pl_Mesh.material = Is_Unbeatable; }
    public void Change_State_ToDefault() { Pl_Mesh.material = Default; }

}
