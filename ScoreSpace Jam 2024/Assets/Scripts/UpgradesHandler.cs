using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class UpgradesHandler : MonoBehaviour
{
    [SerializeField]
    CannonScript[] cannonScripts;
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    GameObject[] buttons;
    [SerializeField]
    Transform[] placeholders;
    // Start is called before the first frame update
    void Start()
    {
        UpgradeShip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpgradesScreen()
    {
        virtualCamera.Priority = 10;
        int toActivate = 3;
        for (int i = 0; i < 10000; i++)
        {
            int rand = Random.Range(0, buttons.Length);
            if (!buttons[rand].activeSelf)
            {
                buttons[rand].SetActive(true);
                buttons[rand].transform.position = placeholders[toActivate - 1].position;
                toActivate--;
                if (toActivate == 0)
                {
                    break;
                }
            }
        }
    }
    public void UpgradeShip()
    {
        GetComponent<CaptainMovementScript>().AddToThrust(GameManager.Instance.GetUpgrades()[0]*2);
        foreach (var script in cannonScripts)
        {
            float x = 0;
            if (GameManager.Instance.GetUpgrades()[1] == 0)
            {
                x = 0;
            }
            else if (GameManager.Instance.GetUpgrades()[1]==1)
            {
                x = -.05f;
            }
            else if(GameManager.Instance.GetUpgrades()[1] == 2)
            {
                x = -.07f;

            }
            else if (GameManager.Instance.GetUpgrades()[1] == 3)
            {
                x = -.09f;
            }
            else if (GameManager.Instance.GetUpgrades()[1] == 4)
            {
                x = -.011f;
            }
            else
            {
                x = -.012f;
            }
            script.AddRateOfFire(x);
        }
        GetComponent<PlayerHealthScript>().AddHealth(GameManager.Instance.GetUpgrades()[3]);
        foreach (var script in cannonScripts)
        {
            float y = 0;
            if (GameManager.Instance.GetUpgrades()[4] == 0)
            {
                y = 0;
            }
            else if (GameManager.Instance.GetUpgrades()[4] == 1)
            {
                y = -.07f;
            }
            else if (GameManager.Instance.GetUpgrades()[4] == 2)
            {
                y = -.1f;

            }
            else if (GameManager.Instance.GetUpgrades()[4] == 3)
            {
                y = -.12f;
            }
            else if (GameManager.Instance.GetUpgrades()[4] == 4)
            {
                y = -.14f;
            }
            else
            {
                y = -.16f;
            }
            script.AddReloadTime(y);
        }
    }
    public void AddUpgrade(int index)
    {
        GameManager.Instance.AddUpgrade(index);
    }
}
