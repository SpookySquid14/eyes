using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    //variables
    Ray lineOfSight;
    LightSwitch lightSwitch;
    GameObject closestSwitch;
    Controls controls;
    [SerializeField] GameObject playerEyes;
    [SerializeField] float interactDistance;
    Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new Controls();
        controls.Game.Enable();
        controls.Game.BreakLight.performed += BreakLight_performed;
        animator = GetComponent<Animator>();
    }
    private void BreakLight_performed(InputAction.CallbackContext obj)
    {
        animator.Play("demo_combat_shoot");
        RaycastHit hit;
        Debug.DrawRay(playerEyes.transform.position, playerEyes.transform.forward, Color.green, 5f, false);
        if (Physics.Raycast(playerEyes.transform.position, playerEyes.transform.forward * interactDistance, out hit, interactDistance))
        {
            Debug.Log(hit.colliderInstanceID);
            if (hit.transform.tag == "LightSwitch")
            {
                
                Debug.DrawRay(playerEyes.transform.position, playerEyes.transform.forward, Color.green, 5f, false);
                closestSwitch = FindClosestSwitch();
                lightSwitch = closestSwitch.GetComponent<LightSwitch>();
                lightSwitch.unlockCamera();
            }
        }
    }

    public GameObject FindClosestSwitch()
    {
        GameObject[] lswitches;
        lswitches = GameObject.FindGameObjectsWithTag("LightSwitch");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach(GameObject lswitch in lswitches)
        {
            Vector3 diff = lswitch.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = lswitch;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
