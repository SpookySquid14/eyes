using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraTracker : MonoBehaviour
{
    TextMeshProUGUI currentCamera;
    CameraController controller;
    GameObject[] camsLocked;
    public int unlockedCameras;

    void Awake()
    {
        currentCamera = GetComponent<TextMeshProUGUI>();
        controller = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        camsLocked = GameObject.FindGameObjectsWithTag("Locked");
        unlockedCameras = controller.cameras.Length - camsLocked.Length;
        currentCamera.text = $"{unlockedCameras}";
    }
}
