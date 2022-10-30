using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    CameraController controller;
    CameraTracker tracker;
    [SerializeField] TextMeshProUGUI victoryText;

    // Start is called before the first frame update
    void Awake()
    {
        controller = FindObjectOfType<CameraController>();
        tracker = FindObjectOfType<CameraTracker>();
        victoryText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tracker.unlockedCameras == controller.cameras.Length)
        {
            victoryText.enabled = true;
        }
    }
}
