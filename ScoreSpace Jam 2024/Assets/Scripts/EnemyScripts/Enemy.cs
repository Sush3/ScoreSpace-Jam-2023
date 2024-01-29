using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int points;
    [SerializeField]
    float health;
    void Awake() 
    {
    }
    public void Die()
    {
        GameManager.Instance.AddPoints(points);
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
