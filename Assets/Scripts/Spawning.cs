using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    private int side, pos, type;
    private float time;
    public float spawntime;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
        if (time >= spawntime)
        {
            side = Random.Range(0, 4);
            type = Random.Range(0, 3);
            if (side % 2 == 0)
            {
                pos = Random.Range(-19, 20);
            }
            else
            {
                pos = Random.Range(-15, 16);
            }
            time = 0;
        }
    }
}
