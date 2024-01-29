using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    Spawnable[] spawnables;
    // Start is called before the first frame update
    void Start()
    {
        spawnables = new Spawnable[transform.childCount];
        for (int i = 0; i < spawnables.Length; i++)
        {
            spawnables[i] = transform.GetChild(i).GetComponent<Spawnable>();
        }
    }
    public void Spawn(int credits)
    {
        int safetyLimit = 10000;
        for (int i = 0; i < safetyLimit; i++)
        {
            int rnd = Random.Range(0, spawnables.Length);
            if (spawnables[rnd].GetCost()<=credits)
            {
                spawnables[rnd].Spawn();
                credits -= spawnables[rnd].GetCost();
                if (credits == 0)
                {
                    break;
                }
            }
        }
    }
}
