using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : Enemy
{
    SphereCollider myCollider;
    Collider[] inside;
    private void OnEnable()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.enabled = false;
        List<Collider> colList = new List<Collider>();
        Debug.Log(Physics.OverlapSphere(transform.position, transform.localScale.x / 2));
        foreach (var col in Physics.OverlapSphere(transform.position, transform.localScale.x/2))
        {
            if (col.CompareTag("Enemy"))
            {
                colList.Add(col);
            }
        }
        inside = colList.ToArray();
        myCollider.enabled = true;

        foreach (var col in inside)
        {
            col.enabled = false;
        }
    }
    protected override void DieEffect()
    {
        foreach (var col in inside)
        {
            col.enabled = true;
        }
    }
}
