using UnityEngine;
using System.Collections;

public class StarfighterControler : MonoBehaviour {
    private const float SpeedX = 1;
    private const float SpeedZ = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey("up"))
        {
            transform.Translate(0, 0, vertical * SpeedZ);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0, 0, vertical * SpeedZ);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(horizontal * SpeedX, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(horizontal * SpeedX, 0, 0);
        }
	}
}
