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

    Transform player;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.GetPlayer().transform;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        transform.rotation=Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(player.position-transform.position)*Quaternion.Euler(90,0,0),
            Mathf.Clamp01((Time.time-timer)*turnSpeed)) ;
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
