using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour

{
    private bool musicOn;

    // Start is called before the first frame update
    void Start()
    {
        musicOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (musicOn == true)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicToggle", 0);
                musicOn = false;
                //Debug.Log("MusicOff");
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicToggle", 1);
                musicOn = true;
                //Debug.Log("MusicOn");
            }
        }
    }
}
