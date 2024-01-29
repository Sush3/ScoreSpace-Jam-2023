using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictOrbit : MonoBehaviour
{
    float gravityStrength;
    Rigidbody rb;
    [SerializeField]
    int stepCount;
    [SerializeField]
    int ghostFrequency;
    [SerializeField]
    GameObject orbitPredictionGhostPrefab;
    [SerializeField]
    Transform collisionPrediction;

    List<GameObject> orbitPredictionList = new List<GameObject>();
    int frameCounter;
    Collider asteroidCollider;
    float shipColliderRadius;
    // Start is called before the first frame update
    void Start()
    {
        gravityStrength=GetComponent<GravitateScript>().GetStrength();
        rb = GetComponent<Rigidbody>();
        asteroidCollider = GameManager.Instance.GetAsteroidCollider();
        shipColliderRadius = GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3[] prediction = new Vector3[stepCount];
        var currentPos = rb.position;
        var prevPos = currentPos;
        var currentVelocity = rb.velocity;
        int ghostsCount = 0;
        collisionPrediction.transform.position = Vector3.zero;
        for (int i = 0; i < stepCount; i++)
        {
            var forceMag = gravityStrength / (-currentPos).sqrMagnitude;
            var forces = (-currentPos).normalized * forceMag;
            currentVelocity += forces * Time.fixedDeltaTime;

            currentPos += currentVelocity * Time.fixedDeltaTime;
            prevPos = currentPos;
            prediction[i] = currentPos;
            if ((i+ frameCounter) % ghostFrequency == 0)
            {
                if (orbitPredictionList.Count-1<ghostsCount)
                {
                    orbitPredictionList.Add(Instantiate(orbitPredictionGhostPrefab, currentPos, Quaternion.LookRotation(currentVelocity)));
                }
                else
                {
                    orbitPredictionList[ghostsCount].transform.position = currentPos;
                    orbitPredictionList[ghostsCount].transform.rotation = Quaternion.LookRotation(currentVelocity);
                }
                ghostsCount++;
            }
            if (Vector3.Distance(asteroidCollider.ClosestPoint(currentPos),currentPos) <= shipColliderRadius)
            {
                collisionPrediction.transform.position = asteroidCollider.ClosestPoint(currentPos);
                break;
            }
        }

        if (orbitPredictionList.Count>ghostsCount)
        {
            Destroy(orbitPredictionList[orbitPredictionList.Count - 1]);
            orbitPredictionList.RemoveAt(orbitPredictionList.Count - 1);
        }

        frameCounter++;
    }
    public void StopPrediction()
    {
        stepCount = 0;
    }
}
