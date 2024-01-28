using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 4;
    int health;
    [SerializeField]
    Transform horizontalLayoutGroup;
    [SerializeField]
    GameObject healthSegment;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdateInterface();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit()
    {
        health--;
        UpdateInterface();
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
