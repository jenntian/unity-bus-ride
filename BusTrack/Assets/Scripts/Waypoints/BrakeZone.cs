using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class BrakeZone : MonoBehaviour
{


    public float targetSpeed = 2f;
    private float originalSpeed;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Car"))
        {
            originalSpeed = col.GetComponent<NavMeshAgent>().speed;
            col.GetComponent<NavMeshAgent>().speed = targetSpeed;
        }
    }

    void OnTriggerExit(Collider col)
    {
        col.GetComponent<NavMeshAgent>().speed = originalSpeed;
    }

}
