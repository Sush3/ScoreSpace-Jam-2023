using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    UpgradesHandler upgradesHandler;
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
    int[] upgrades = new int[5];
    bool won;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance!=this)
        {
            if (Instance!=null)
            {
                upgrades = Instance.GetUpgrades();
                Destroy(Instance.gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(upgrades);
        }
        asteroidCollider = initializeScript.Initialize(credits).GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length==0&&!won)
        {
            upgradesHandler.UpgradesScreen();
            won = true;         
        }
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
    public void AddUpgrade(int index)
    {
        //thrust
        //rof
        //dmg
        //heal
        //rel
        Debug.Log("AAAAAAAA");
        upgrades[index]++;
        SceneManager.LoadScene(1);
    }
    public int[] GetUpgrades()
    {
        return upgrades;
    }
}
