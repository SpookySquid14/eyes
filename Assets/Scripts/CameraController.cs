using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    //declaring variables (cameras)
    public Camera[] cameras;
    /*[SerializeField] Camera cam1a;
    [SerializeField] Camera cam1b;
    [SerializeField] Camera cam2a;
    [SerializeField] Camera cam2b;
    [SerializeField] Camera cam3a;

    public Image[] cameraPreviews;
    [SerializeField] Image camPreview1a;
    [SerializeField] Image camPreview1b;
    [SerializeField] Image camPreview1_2;
    [SerializeField] Image camPreview2a;
    [SerializeField] Image camPreview2b;*/
    public int currentCam;
    Controls controls;
    Methods methods;
    LightSwitch lightSwitch;

    private void Awake()
    {
        //cameras = new Camera[5];
        //cameraPreviews = new Image[5];
        controls = new Controls();
        methods = new Methods();
        lightSwitch = GetComponent<LightSwitch>();

        /*cameras[0] = cam1a;
        cameras[1] = cam1b;
        cameras[2] = cam2a;
        cameras[3] = cam2b;
        cameras[4] = cam3a;

        cameraPreviews[0] = camPreview1a;
        cameraPreviews[1] = camPreview1b;
        cameraPreviews[2] = camPreview1_2;
        cameraPreviews[3] = camPreview2a;
        cameraPreviews[4] = camPreview2b;*/


        controls.Game.Cameras.Enable();
        controls.Game.Cameras.performed += Cameras_performed;
        


        resetPreviews();
    }
    void resetPreviews()
    {
        /*for (int i = currentCam; i <= cameraPreviews.Length; i++)
        {
            cameraPreviews[currentCam].enabled = false;
            currentCam = i;
        }*/
        currentCam = 0;
        cameras[currentCam].enabled = true;
        //cameraPreviews[currentCam].enabled = true;
        
    }

    void disableCam()
    {
        cameras[currentCam].tag = "Untagged";
        cameras[currentCam].GetComponent<AudioListener>().enabled = false;
        cameras[currentCam].enabled = false;
        //cameraPreviews[currentCam].enabled = false;
    }
    void enableCam()
    {
        cameras[currentCam].tag = "MainCamera";
        cameras[currentCam].GetComponent<AudioListener>().enabled = true;
        cameras[currentCam].enabled = true;
        //cameraPreviews[currentCam].enabled = true;
    }

    void incCamera()
    {
        disableCam();
        while (true)
        {
            currentCam = methods.mod(currentCam + 1, cameras.Length);
            if (cameras[currentCam].tag != "Locked")
            {
                break;
            }
            
        }
        enableCam();
    }
    void decCamera()
    {
        disableCam();
        while (true)
        {
            currentCam = methods.mod(currentCam - 1, cameras.Length);
            if (cameras[currentCam].tag != "Locked")
            {
                break;
            }

        }
        enableCam();
    }

    private void Cameras_performed(InputAction.CallbackContext obj)
    {
        float direction = controls.Game.Cameras.ReadValue<float>();
        if (direction > 0)
        {
            incCamera();
        }
        if (direction < 0)
        {
            decCamera();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
