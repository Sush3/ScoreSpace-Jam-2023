using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{
    [SerializeField]
    AnimationCurve recoilCurve;
    [SerializeField]
    float speed;
    [SerializeField]
    float strength;
    float timer;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = startPos + new Vector3(recoilCurve.Evaluate(timer* speed) * strength, 0, 0);
        timer += Time.deltaTime;
    }
    public void Shoot()
    {
        timer = 0;
    }
}
