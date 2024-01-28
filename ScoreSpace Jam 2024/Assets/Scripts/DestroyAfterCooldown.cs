using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCooldown : MonoBehaviour
{
    [SerializeField]
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown += Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time>cooldown)
        {
            Destroy(gameObject);
        }
    }
}
