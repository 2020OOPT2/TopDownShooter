using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ghoul : MonoBehaviour
{

    public GameObject Poison;
    void Update()
    {
        if (this.GetComponent<Attack>().Dead == 1)
        {
            Instantiate(Poison, this.transform.position, Quaternion.identity);
        }
    }
}
