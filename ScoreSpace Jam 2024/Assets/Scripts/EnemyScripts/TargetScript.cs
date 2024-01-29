using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : Enemy
{
    [SerializeField]
    GameObject explosionVFX;
    protected override void DieEffect()
    {
        TutorialScript.Instance.TargetDestroyed();
        Instantiate(explosionVFX, transform.position, transform.rotation);
    }
}
