using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField]
    Image diePanel;
    [SerializeField]
    float blackoutSpeed;
    [SerializeField]
    float endGameCooldown;
    float dieTimer;
    float endGameTimer=float.MaxValue;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Die();
        }
        if (isDead)
        {
            diePanel.color = new Color(0, 0, 0, (Time.time-dieTimer)* blackoutSpeed);

        }
        else
        {
            diePanel.color = new Color(0, 0, 0, 1-Time.timeSinceLevelLoad* blackoutSpeed);
        }
        if (Time.time> endGameTimer)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
    public void Die()
    {
        dieTimer = Time.time;
        endGameTimer = Time.time+ endGameCooldown;
        isDead = true;
        GetComponent<PredictOrbit>().StopPrediction();
    }
    
}
