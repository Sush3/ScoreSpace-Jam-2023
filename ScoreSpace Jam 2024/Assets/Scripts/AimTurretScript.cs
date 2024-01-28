using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurretScript : MonoBehaviour
{
    [SerializeField]
    LayerMask aimMask;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Plane plane = new Plane(transform.parent.right,1000);
        float dist;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, aimMask))
        {
            transform.rotation = Quaternion.LookRotation(hit.point, transform.parent.up) * Quaternion.Euler(0, 90, 0);
        }
        else if (plane.Raycast(ray,out dist))
        {
            transform.rotation = Quaternion.LookRotation(ray.direction * dist, transform.parent.up) * Quaternion.Euler(0, 90, 0);
        }
    }
}
