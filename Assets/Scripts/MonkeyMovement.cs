using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        GameState.instructionsText = GameObject.FindGameObjectWithTag("Spectator");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameState.gameState.Equals(GameState.GameStates.Play))
        {
            Vector3 force = Input.GetAxis("Vertical") * movementForce * transform.forward;
            rigidbody.AddForce(force);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetButtonDown("Quit"))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetButtonDown("ToggleSpectate"))
        {
            GameState.toggleSpectate();
        }
        else if (transform.position.y < falloutPlane || transform.position.y < -50)
        {
            SceneManager.LoadScene(1);
        }
        if (GameState.gameState.Equals(GameState.GameStates.Play))
        {
            rigidbody.isKinematic = false;
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
        }
        else
        {
            rigidbody.isKinematic = true;
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
