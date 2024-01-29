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

    }
    public void AddUpgrade(int index)
    {
        GameManager.Instance.AddUpgrade(index);
    }
}
