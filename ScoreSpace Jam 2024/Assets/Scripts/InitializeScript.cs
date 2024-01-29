using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeScript : MonoBehaviour
{
    AsteroidScript[] asteroids;
    [SerializeField]
    float randomScaleMin;
    [SerializeField]
    float randomScaleMax;
    public Transform Initialize(int credits)
    {
        asteroids = new AsteroidScript[transform.childCount];
        for (int i = 0; i < asteroids.Length; i++)
        {
            asteroids[i] = transform.GetChild(i).GetComponent<AsteroidScript>();
        }
        int rnd = Random.Range((int)0,(int)asteroids.Length);
        asteroids[rnd].gameObject.SetActive(true);
        asteroids[rnd].Spawn(credits);
        asteroids[rnd].transform.rotation = Random.rotation;
        float scale=  Random.Range(randomScaleMin, randomScaleMax);
        asteroids[rnd].transform.localScale = Vector3.one * scale;
        return asteroids[rnd].transform;
    }
}
