using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    InitializeScript initializeScript;
    Collider asteroidCollider;
    [SerializeField]
    Rigidbody player;
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
        asteroidCollider = initializeScript.Initialize(10).GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Collider GetAsteroidCollider()
    {
        return asteroidCollider;
    }
    public Rigidbody GetPlayer()
    {
        return player;
    }
    public void AddPoints(int points)
    {

    }
}
