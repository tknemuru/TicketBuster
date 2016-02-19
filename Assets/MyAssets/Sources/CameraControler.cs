using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour {
    private Vector3 Difference { get; set; }

    // Use this for initialization
	void Start () {
        this.Difference = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("SciFi_Fighter_AK5"))
        {
            Vector3 startVec = GameObject.Find("SciFi_Fighter_AK5").transform.localPosition;
            transform.localPosition = new Vector3(this.Difference.x, startVec.y + this.Difference.y, startVec.z + this.Difference.z);
        }
    }
}
