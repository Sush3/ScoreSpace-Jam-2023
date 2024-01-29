using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeScript : MonoBehaviour
{
    [SerializeField]
    int credits;
    AsteroidScript[] asteroids;
    [SerializeField]
    float randomScaleMin;
    [SerializeField]
    float randomScaleMax;
    // Start is called before the first frame update
    void Start()
    {
        asteroids = new AsteroidScript[transform.childCount];
        for (int i = 0; i < asteroids.Length; i++)
        {
            asteroids[i] = transform.GetChild(i).GetComponent<AsteroidScript>();
        }
        Initialize(30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(int credits)
    {
        int rnd = Random.Range((int)0,(int)asteroids.Length);
        asteroids[rnd].gameObject.SetActive(true);
        asteroids[rnd].Spawn(credits);
        asteroids[rnd].transform.rotation = Random.rotation;
        float scale=  Random.Range(randomScaleMin, randomScaleMax);
        asteroids[rnd].transform.localScale = Vector3.one * scale;
    }
}
