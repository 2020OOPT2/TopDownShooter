using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    private int side, type;
    private float time, pos;
    public float spawntime;
    public GameObject Zom, Ske, Gho;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawntime)
        {
            side = Random.Range(0, 4);
            type = Random.Range(0, 3);
            if (side % 2 == 0)
            {
                pos = Random.Range(-19, 20);
                if (side == 0)
                {
                    if (type == 0) Instantiate(Zom, new Vector3(575 + pos, 264 + 15, 0), Quaternion.identity);
                    else if (type == 1) Instantiate(Ske, new Vector3(575 + pos, 264 + 15, 0), Quaternion.identity);
                    else Instantiate(Gho, new Vector3(575 + pos, 264 + 15, 0), Quaternion.identity);
                }
                else
                {
                    if (type == 0) Instantiate(Zom, new Vector3(575 + pos, 264 - 15, 0), Quaternion.identity);
                    else if (type == 1) Instantiate(Ske, new Vector3(575 + pos, 264 - 15, 0), Quaternion.identity);
                    else Instantiate(Gho, new Vector3(575 + pos, 264 - 15, 0), Quaternion.identity);
                }
            }
            else
            {
                pos = Random.Range(-15, 16);
                if (side == 1)
                {
                    if (type == 0) Instantiate(Zom, new Vector3(575 + 19, 264 + pos, 0), Quaternion.identity);
                    else if (type == 1) Instantiate(Ske, new Vector3(575 + 19, 264 + pos, 0), Quaternion.identity);
                    else Instantiate(Gho, new Vector3(575 + 19, 264 + pos, 0), Quaternion.identity);
                }
                else
                {
                    if (type == 0) Instantiate(Zom, new Vector3(575 - 19, 264 + pos, 0), Quaternion.identity);
                    else if (type == 1) Instantiate(Ske, new Vector3(575 - 19, 264 + pos, 0), Quaternion.identity);
                    else Instantiate(Gho, new Vector3(575 - 19, 264 + pos, 0), Quaternion.identity);
                }
            }
            time = 0;
            Debug.Log("pos:" + pos);
        }
    }
}
