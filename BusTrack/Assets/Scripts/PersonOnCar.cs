using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonOnCar : MonoBehaviour {

    //this script ^^ is attached to the car


   //  THis is the person on the car:
    public GameObject personObject;
    public Vector3 pos;

     Transform personPos;
    float personHeight;

    public bool allowedToGetOff = false;
    public bool actuallyDecidedToGetOff = false;


    void Start()
    {

        personHeight = personObject.GetComponent<MeshFilter>().mesh.bounds.extents.y * 2; // convoluted as fuck
        pos = new Vector3(0, personHeight, 0);

        personPos = personObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!allowedToGetOff)
        {
            // person stuck on car
            personObject.transform.position = transform.TransformPoint(pos);
        }
        else
        {
            //check if player is still on car

            //if (personObject.GetComponent<MeshFilter>().mesh.bounds.Intersects(GetComponent<MeshFilter>().mesh.bounds))
            float dist = Vector3.Distance(personPos.position, transform.position);
            Debug.Log("DIST " + dist);
            if (dist > 4f)
            {
                Debug.Log("I am getting off");
                actuallyDecidedToGetOff = true;
            }
            else
            {
                Debug.Log("I am staying");
                actuallyDecidedToGetOff = false;
            }
          

        }

    }

}
