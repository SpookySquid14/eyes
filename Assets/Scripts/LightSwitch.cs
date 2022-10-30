using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    //variables
    Camera cam;
    GameObject closestRoom;
    GameObject closestHall;
    [SerializeField] Material monster;
    [SerializeField] CameraController controller;
    [SerializeField] GameObject manager;
    public float objectRadius;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void unlockCamera()
    {
        //cam.tag = "Untagged";
        StartCoroutine(manager.GetComponent<BlackScreen>().BlankScreen());
        FindCameraInRange();
        gameObject.tag = "Untagged";
        Overtake(gameObject.transform.position, objectRadius);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, objectRadius);
    }

    void FindCameraInRange()
    {
        float currentDistance;
        foreach (Camera currentCam in controller.cameras)
        {
            if (currentCam.tag == "Locked")
            {
                currentDistance = Vector3.Distance(currentCam.transform.position, gameObject.transform.position);   
                if (currentDistance <= objectRadius)
                {
                    cam = currentCam;
                    cam.tag = "Untagged";
                }
            }
            
        }
    }

    public void Overtake(Vector3 pivot, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(pivot, radius);
        Debug.Log(colliders.Length);
        foreach (Collider collider in colliders)
        {
            
            if (collider.tag == "Untagged")
            {
                Renderer colliderMat = collider.GetComponentInChildren<Renderer>();
                colliderMat.material = monster;
            }
            
        }
    }

}
