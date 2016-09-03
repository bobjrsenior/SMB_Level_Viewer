using UnityEngine;
using System.Collections;

public class FreeCameraMovemenr : MonoBehaviour {

    private float movementSpeed = 5.0f;

    private float sprintMultiplier = 3.0f;

    private Vector2 rotationSpeed = new Vector2(50.0f, 30.0f);

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Vertical") * movementSpeed, Input.GetAxis("Tilt") * movementSpeed, Input.GetAxis("Horizontal") * movementSpeed);


	}
}
