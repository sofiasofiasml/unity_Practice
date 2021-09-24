using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{
    public GameObject CameraUp;
    public GameObject CameraPlayer;
    public GameObject CameraDice;
    public GameObject Dice;

    AudioListener cameraUpAudio;
    AudioListener cameraPlayerAudio;
    AudioListener cameraDiceAudio;

    int camPos = 0; 
    // Start is called before the first frame update
    void Start()
    {
        // Camera Listeners
        cameraUpAudio = CameraUp.GetComponent<AudioListener>();
        cameraPlayerAudio = CameraPlayer.GetComponent<AudioListener>();
        cameraDiceAudio = CameraDice.GetComponent<AudioListener>();

        ////Camera Position 
        //CameraPositionChange(); 
    }

    // Update is called once per frame
    void Update()
    {
        switchCamera(); 
    }
    void switchCamera()
    {
		if (Input.GetKeyDown(KeyCode.C))
		{
            cameraChangeCounter(); 
		}
    }
    void cameraChangeCounter()
    {
        camPos += 1; 
        if (camPos > 2)
            camPos = 0;
		if (camPos==0)
		{
            CameraUp.SetActive(true);
            cameraUpAudio.enabled = true;

            CameraPlayer.SetActive(false);
            cameraPlayerAudio.enabled = false;

            Dice.SetActive(false);
            CameraDice.SetActive(false);
            cameraDiceAudio.enabled = false;

        }
        if (camPos == 1)
        {
            CameraPlayer.SetActive(true);
            cameraPlayerAudio.enabled = true;

            CameraUp.SetActive(false);
            cameraUpAudio.enabled = false;

            Dice.SetActive(false);
            CameraDice.SetActive(false);
            cameraDiceAudio.enabled = false;

        }
        if (camPos == 2)
        {
            Dice.SetActive(true); 
            CameraDice.SetActive(true);
            cameraDiceAudio.enabled = true;

            CameraPlayer.SetActive(false);
            cameraPlayerAudio.enabled = false;

            CameraUp.SetActive(false);
            cameraUpAudio.enabled = false;

        }

    }
}
