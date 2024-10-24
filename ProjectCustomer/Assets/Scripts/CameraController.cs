using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static bool cameraSwith = false;

    CinemachineVirtualCamera activeCamera;

    [SerializeField] UI ui;
    [SerializeField] CinemachineVirtualCamera POVCamera;
    [SerializeField] CinemachineVirtualCamera OtherPOVCamera;

    private bool once = false;

    private void Start()
    {
        // Initialize activeCamera and set starting priorities
        activeCamera = POVCamera; // Start with POVCamera as the active camera
        POVCamera.Priority = 10;  // Give higher priority to POVCamera
        OtherPOVCamera.Priority = 0; // Give lower priority to OtherPOVCamera
    }

    private void Update()
    {
        if (ui.npcscript.colliding && !once)
        {
            CameraChange();
            once = true;
        }
        else if (!ui.npcscript.colliding && once)
        {
            print("false"); 
            once = false;
            CameraChange();
        }

        // Toggle cameraSwith when 'T' key is pressed
/*        if (Input.GetKeyDown(KeyCode.T))
        {
            cameraSwith = !cameraSwith; // Toggles the boolean
            CameraChange(); // Call camera change when the key is pressed
        }*/
    }

    private void CameraChange()
    {
        // If the current active camera is POVCamera, switch to OtherPOVCamera
        if (POVCamera == activeCamera)
        {
            SetCameraPrior(POVCamera, OtherPOVCamera);
        }
        else
        {
            // Otherwise switch back to POVCamera (the camera with lower priority goes first)
            SetCameraPrior(OtherPOVCamera, POVCamera);
        }
    }

    private void SetCameraPrior(CinemachineVirtualCamera currentCam, CinemachineVirtualCamera newCam)
    {
        // Lower the priority of the current camera
        currentCam.Priority = 0;

        // Increase the priority of the new camera
        newCam.Priority = 10;

        // Set the new active camera
        activeCamera = newCam;
    }
}

