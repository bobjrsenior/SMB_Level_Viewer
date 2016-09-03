using UnityEngine;
using System.Collections;

public class FreeCameraMovemenr : MonoBehaviour {

    private float movementSpeed = 5.0f;

    private float sprintMultiplier = 3.0f;

    private Vector2 rotationSpeed = new Vector2(50.0f, 30.0f);

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameState.gameState.Equals(GameState.GameStates.Play))
        {
            camera.depth = -1;
        }
        else
        {
            
            camera.depth = 1;
            float curSpeed = movementSpeed;
            if (Input.GetButton("Sprint"))
            {
                curSpeed *= sprintMultiplier;
            }

            Vector3 rotation = Vector3.zero;


            transform.Translate(Input.GetAxis("Horizontal") * curSpeed * Time.deltaTime, Input.GetAxis("Pan") * curSpeed * Time.deltaTime, Input.GetAxis("Vertical") * curSpeed * Time.deltaTime);
            transform.Rotate(Input.GetAxis("Mouse Y") * -rotationSpeed.y * Time.deltaTime, 0, 0, Space.Self);
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed.x * Time.deltaTime, 0, Space.World);
        }


	}
}
