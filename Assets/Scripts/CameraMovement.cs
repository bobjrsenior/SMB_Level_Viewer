using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {


    private float normalDistance = 3;

    private float normalHeight = 3;

    private Rigidbody monkey;

    private Vector3 lastDirection = new Vector3(1, 0, 1);

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
	    /*if(monkey != null)
        {
            Vector3 direction = (new Vector3(monkey.velocity.x, 0, monkey.velocity.z)).normalized;
            if (direction.sqrMagnitude < 0.1)
            {
                direction = lastDirection;
            }
            else
            {
                lastDirection = direction;
            }
            direction *= -normalDistance;
            direction.y = normalHeight;
            transform.position = monkey.transform.position + direction;
            
            transform.rotation = Quaternion.LookRotation((monkey.transform.position - transform.position).normalized);
        }
        */
	}

    public void setMonkey(GameObject monkey)
    {
        this.monkey = monkey.GetComponent<Rigidbody>();
    }
}
