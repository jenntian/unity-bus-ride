using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CarNavigation : MonoBehaviour {



    // Waypoint sysytem for bus driver
    List<Transform> points = new List<Transform>();
    private int destPoint = 0;
    private NavMeshAgent agent;
    public WaypointSystem path;

    public float myOriginalCarSpeed;

    // Stop the bus!
    bool stopping = false;
    bool atBusStop = false;
    float busStoppedTimer = 0f;
    float busStoppedTimeDelay = 10f;

    PersonOnCar playerOnCarStatus; // this is the script that keeps the person on the car.


    void Start()
    {

        points = path.waypoints;

        agent = GetComponent<NavMeshAgent>();

        myOriginalCarSpeed = agent.speed;
        
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Count;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();


        // I wanna get off the bus now!
        if (Input.GetKey(KeyCode.S))  {
            stopping = true;

        }

        // If the car is at the bus stop:
        if (atBusStop)
        {
            if (stopping)
            {

                //thank god this works
                // stop the bus!
                this.GetComponent<NavMeshAgent>().speed = 0;

                // ( but do some easing...
                // ... we want to slow the bus before we come to a complete halt. )

                // let the person off the bus
                // go get the other script attached to the car
                playerOnCarStatus = GetComponent<PersonOnCar>();
                playerOnCarStatus.allowedToGetOff = true;

                // count how much time the bus has spent in stopped position
                busStoppedTimer += Time.deltaTime;
                
                // start the bus!
                if (busStoppedTimer > busStoppedTimeDelay)
                {
                    this.GetComponent<NavMeshAgent>().speed = myOriginalCarSpeed;
                    busStoppedTimer = 0f;
                    stopping = false;
                    if (!playerOnCarStatus.actuallyDecidedToGetOff)
                    {
                        playerOnCarStatus.allowedToGetOff = false;
                    }

                }
            }

        }

    }


    void OnTriggerEnter(Collider otherCol)
    {
        if (otherCol.tag == "Busstop")
        {
            atBusStop = true;
      
        }
    }

    void OnTriggerExit(Collider otherCol)
    {
        if (otherCol.tag == "Busstop")
        {
            atBusStop = false;

        }
    }

}
