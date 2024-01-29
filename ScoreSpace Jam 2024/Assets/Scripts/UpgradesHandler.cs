using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddUpgrade(int index)
    {
        GameManager.Instance.AddUpgrade(index);
    }
}
