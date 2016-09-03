using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MonkeyMovement : MonoBehaviour {

    private Rigidbody rigidbody;

    private float movementForce = 10;

    private float rotationSpeed = 5.0f;

    private float falloutPlane = -10.0f;

    private Vector3 resetPosition;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        resetPosition = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 force = Input.GetAxis("Vertical") * movementForce * transform.forward;
        rigidbody.AddForce(force);
    }

    void Update()
    {

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        if (Input.GetButton("Start"))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetButton("Quit"))
        {
            SceneManager.LoadScene(0);
        }
        else if(transform.position.y < falloutPlane || transform.position.y < -50)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void setFalloutPlane(float height)
    {
        falloutPlane = height;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bumper"))
        {
            rigidbody.velocity = -rigidbody.velocity;
        }
    }
}
