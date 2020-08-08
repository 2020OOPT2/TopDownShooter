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
                    if (type == 0) { 
                        GameObject mob = Instantiate(Zom, new Vector3(pos, 15, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else if (type == 1) { 
                        GameObject mob = Instantiate(Ske, new Vector3(pos, 15, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else { 
                        GameObject mob = Instantiate(Gho, new Vector3(pos, 15, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                   
                }
                else
                {
                    if (type == 0) { 
                        GameObject mob = Instantiate(Zom, new Vector3(pos, -15, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else if (type == 1) { 
                        GameObject mob = Instantiate(Ske, new Vector3(pos, -15, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else { 
                        GameObject mob = Instantiate(Gho, new Vector3(pos, -15, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                }
            }
            else
            {
                pos = Random.Range(-15, 16);
                if (side == 1)
                {
                    if (type == 0)
                    {
                        GameObject mob = Instantiate(Zom, new Vector3(19, pos, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else if (type == 1)
                    {
                        GameObject mob = Instantiate(Ske, new Vector3(19, pos, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else
                    {
                        GameObject mob = Instantiate(Gho, new Vector3(19, pos, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                }
                else
                {
                    if (type == 0)
                    {
                        GameObject mob = Instantiate(Zom, new Vector3(-19, pos, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else if (type == 1)
                    {
                        GameObject mob = Instantiate(Ske, new Vector3(-19, pos, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                    else
                    {
                        GameObject mob = Instantiate(Gho, new Vector3(-19, pos, 0), Quaternion.identity);
                        Instantiated_Mob_Calibrate(mob);
                    }
                }
            }
            time = 0;
            Debug.Log("pos:" + pos);
        }
    }
    void Instantiated_Mob_Calibrate(GameObject mob)
    {
        mob.transform.parent = GameObject.Find("IngameScreen").transform;
        mob.transform.position += mob.transform.parent.position;
        mob.transform.localScale = new Vector3(1, 1, 1);
    }
}
