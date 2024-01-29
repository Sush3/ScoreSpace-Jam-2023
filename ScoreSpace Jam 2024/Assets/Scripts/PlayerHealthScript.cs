using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
    int health;
    [SerializeField]
    Transform horizontalLayoutGroup;
    [SerializeField]
    GameObject healthSegment;
    PlayerDeathScript pds;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdateInterface();
        pds = GetComponent<PlayerDeathScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit()
    {
        health--;
        UpdateInterface();
        if (health<=0)
        {
            pds.Die();
        }
    }
    public void AddHealth(int h)
    {
        health+=h;
        for (int i = 0; i < h; i++)
        {
            UpdateInterface();
        }
    }
    void UpdateInterface()
    {
        if (horizontalLayoutGroup.childCount>health)
        {
            Destroy(horizontalLayoutGroup.GetChild(0).gameObject);
        }
        else if (horizontalLayoutGroup.childCount < health)
        {
            Instantiate(healthSegment, horizontalLayoutGroup);
        }
    }
}
