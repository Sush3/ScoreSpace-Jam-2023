using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGuidanceScript : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float turnSpeed;
    [SerializeField]
    float deviationAmplitude;
    [SerializeField]
    float deviationFrequency;

    Rigidbody player;
    float timer;
    Vector3 currentDeviation;
    float deviationTimer;
    Quaternion startRotation;
    float startDist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.GetPlayer();
        timer = Time.time;
        startRotation = transform.rotation;
        currentDeviation = Random.onUnitSphere;
        startDist = Vector3.Distance(transform.position, player.position);
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;      
        if ((Time.time - timer) * turnSpeed <1)
        {
            transform.rotation = Quaternion.Slerp(startRotation,
            Quaternion.LookRotation(player.position - transform.position +
            player.velocity * Vector3.Distance(player.position, transform.position) / startDist) * Quaternion.Euler(90, 0, 0),
            Mathf.Clamp01((Time.time - timer) * turnSpeed));
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(player.position - transform.position+
                currentDeviation * Mathf.Sin((Time.time-deviationTimer/deviationFrequency)%(Mathf.PI))*
                deviationAmplitude*Vector3.Distance(player.position,transform.position)/startDist
                + player.velocity * Vector3.Distance(player.position, transform.position) / startDist
                ) *
                Quaternion.Euler(90, 0, 0);
        }
        
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
