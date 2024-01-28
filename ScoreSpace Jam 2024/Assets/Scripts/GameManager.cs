using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Collider asteroidCollider;
    [SerializeField]
    GameObject player;
    public static GameManager Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Collider GetAsteroidCollider()
    {
        return asteroidCollider;
    }
    public GameObject GetPlayer()
    {
        return player;
    }
}
