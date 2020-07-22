using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Move_Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
            this.transform.position += new Vector3(0, 1, 0) * Move_Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            this.transform.position += new Vector3(0, -1, 0) * Move_Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            this.transform.position += new Vector3(-1, 0, 0) * Move_Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(1, 0, 0) * Move_Speed * Time.deltaTime;
    }
}
