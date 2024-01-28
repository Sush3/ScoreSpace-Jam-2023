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
    public void Hit(float dmg)
    {
        health -= dmg;
        if (health<=0)
        {
            Die();
        }
    }
    protected virtual void DieEffect()
    {

    }
}