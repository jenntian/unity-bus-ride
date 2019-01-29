using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Busstop : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Car"))
        {

          //  GameObject carcar = col.GetComponent<GameObject>();
        }
    }

}
