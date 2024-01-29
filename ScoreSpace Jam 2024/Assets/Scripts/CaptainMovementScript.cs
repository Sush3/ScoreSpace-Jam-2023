using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainMovementScript : MonoBehaviour
{
    [SerializeField]
    ParticleSystem[] thrusterVfxArray;
    [SerializeField]
    float thrust;
    [SerializeField]
    float rollSpeed;
    [SerializeField]
    float pointSpeed;
    [SerializeField]
    float angularDragStrength;
    Rigidbody rb;
    public GameObject audioThruster;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetThrustersActive(true);
            audioThruster.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            SetThrustersActive(false);
            audioThruster.SetActive(false);
        }
        Vector2 mouseDelta = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        rb.AddRelativeTorque(mouseDelta * pointSpeed*Time.deltaTime);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-transform.forward * rollSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(transform.forward * rollSpeed);
        }

        if (!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))
        {
            rb.angularDrag = angularDragStrength;
        }
        else
        {
            rb.angularDrag = 0.05f;
        }
    }
    private void OnDisable()
    {

        SetThrustersActive(false);
    }
    public void AddToThrust(float x)
    {
        thrust += x;
    }
    void SetThrustersActive(bool x)
    {
        if (x)
        {
            foreach (var particleSystem in thrusterVfxArray)
            {
                particleSystem.Play();
            }
        }
        else
        {
            foreach (var particleSystem in thrusterVfxArray)
            {
                particleSystem.Stop();
            }
        }
    }
}
