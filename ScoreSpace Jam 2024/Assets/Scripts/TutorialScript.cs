using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public static TutorialScript Instance { get; private set; }
    [SerializeField]
    float scrollSpeed;
    [SerializeField]
    Transform scrollTransform;
    Vector3 startPos;
    bool[] conditionArray;

    [SerializeField]
    float mouseTravelThreshold;
    float mouseTraveledDist;
    [SerializeField]
    int targetCount;
    Vector3 targetLocalPos;
    [SerializeField]
    GameObject[] floatingTargets;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        startPos = scrollTransform.localPosition;
        conditionArray = new bool[10];
    }
    void FixedUpdate()
    {
        int i = 0;
        foreach (var x in conditionArray)
        {
            if (x == true)
            {
                i++;
            }
        }
        targetLocalPos = startPos + new Vector3(0, -600, 0) * i;
        scrollTransform.localPosition = Vector3.Lerp(scrollTransform.localPosition, targetLocalPos, scrollSpeed);
        // look around 
        mouseTraveledDist += Input.mousePositionDelta.magnitude;
    }
    // Update is called once per frame
    void Update()
    {

        if (mouseTraveledDist > mouseTravelThreshold)
        {
            conditionArray[0]=true;
        }
        // press W
        if (conditionArray[0]&&Input.GetKey(KeyCode.W))
        {
            conditionArray[1] = true;     
        }
        // press A or D
        if (conditionArray[1]&&(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)))
        {
            conditionArray[2] = true;
        }
        // press space
        if (conditionArray[2] && Input.GetKey(KeyCode.Space))
        {
            conditionArray[3] = true;
        }
        // press 2
        if (conditionArray[3] && Input.GetKey(KeyCode.Alpha2))
        {
            conditionArray[4] = true;
            foreach (var item in floatingTargets)
            {
                item.SetActive(true);
            }
            floatingTargets = new GameObject[0];
        }
        // press LMB
        if (conditionArray[4] && Input.GetMouseButton(0))
        {
            conditionArray[5] = true;
        }
        // press WSAD
        if (conditionArray[5] && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)||
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            conditionArray[6] = true;
        }
        // press Q or E
        if (conditionArray[6] && (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E)))
        {
            conditionArray[7] = true;
        }
        // press 2
        if (conditionArray[7] && Input.GetKey(KeyCode.Alpha2))
        {
            conditionArray[8] = true;
        }
        // press 1
        if (conditionArray[8] && Input.GetKey(KeyCode.Alpha1))
        {
            conditionArray[9] = true;
        }
        // DESTROY ALL TARGETS!
        if (conditionArray[9] && targetCount <=0)
        {
            SceneManager.LoadScene(2);
            // GAME SCENE
        }
    }
    public void TargetDestroyed()
    {
        targetCount--;
    }
}
