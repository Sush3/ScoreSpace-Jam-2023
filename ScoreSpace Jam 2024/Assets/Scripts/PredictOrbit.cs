using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictOrbit : MonoBehaviour
{
    float gravityStrength;
    Rigidbody rb;
    [SerializeField]
    int stepCount;
    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        gravityStrength=GetComponent<GravitateScript>().GetStrength();
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] prediction = new Vector3[stepCount];
        var currentPos = rb.position;
        var prevPos = currentPos;
        var currentVelocity = rb.velocity;
        var planetCords = gameObject.transform.position;

        for (int i = 0; i < stepCount; i++)
        {
            var distance = -currentPos;

            var forceMag = gravityStrength / distance.sqrMagnitude;
            var forces = distance.normalized * forceMag;
            currentVelocity += forces * Time.fixedDeltaTime;

            currentPos += currentVelocity * Time.fixedDeltaTime;
            prevPos = currentPos;
            prediction[i] = currentPos;
        }
        lr.positionCount = stepCount;
        lr.SetPositions(prediction);

    }
}
