using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int[] creditsCurve;
    [SerializeField]
    UpgradesHandler upgradesHandler;
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    TMP_Text highscoreText;
    [SerializeField]
    InitializeScript initializeScript;
    Collider asteroidCollider;
    [SerializeField]
    Rigidbody player;
    int playerPoints;
    public static GameManager Instance { get; private set; }
    int[] upgrades = new int[5];
    bool won;
    const string highscoreKey = "Highscore";
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance!=this)
        {
            if (Instance!=null)
            {
                upgrades = Instance.GetUpgrades();
                playerPoints = GetPoints();
                Destroy(Instance.gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(upgrades);
        }
        if (PlayerPrefs.HasKey(highscoreKey))
        {
            highscoreText.text = "Highscore: "+PlayerPrefs.GetInt(highscoreKey).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(highscoreKey, 0);
        }
        int level = 0;
        foreach (var item in upgrades)
        {
            level += item;
        }
        asteroidCollider = initializeScript.Initialize((creditsCurve[Mathf.Clamp(level,0,creditsCurve.Length-1)])).GetComponent<Collider>();
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
        if (points> PlayerPrefs.GetInt(highscoreKey))
        {
            PlayerPrefs.SetInt(highscoreKey, points);
            highscoreText.text = "Highscore: " + points;
        }
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
    public int GetPoints()
    { return playerPoints; }
    public int[] GetUpgrades()
    {
        return upgrades;
    }
}
