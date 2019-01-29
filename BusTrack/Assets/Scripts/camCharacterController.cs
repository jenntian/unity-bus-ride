using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCharacterController : MonoBehaviour {

    public float speed = 10f;

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape")) {
            Cursor.lockState = CursorLockMode.None;

        }

    }
}
