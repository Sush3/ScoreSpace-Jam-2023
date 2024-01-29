using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    int credits;
    [SerializeField]
    InitializeScript initializeScript;
    Collider asteroidCollider;
    [SerializeField]
    Rigidbody player;
    int playerPoints;
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
        asteroidCollider = initializeScript.Initialize(credits).GetComponent<Collider>();
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
        if (points == 0) { return; }

        playerPoints += points;
        scoreText.text = "Score: " + playerPoints.ToString();
    }
}
