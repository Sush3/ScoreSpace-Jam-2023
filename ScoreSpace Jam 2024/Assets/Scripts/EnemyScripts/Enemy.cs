using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    int points;
    [SerializeField]
    float health;
    public void Die()
    {
        Debug.Log(transform.name + " died points: " + points);
        DieEffect();
        Destroy(gameObject);
    }
    protected virtual void DieEffect()
    {

    }
}
