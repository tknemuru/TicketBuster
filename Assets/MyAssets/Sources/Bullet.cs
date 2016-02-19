using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private const float Speed = 2;

	// Use this for initialization
	public void Start () {
        Destroy(this.gameObject, 5);
	}
	
	// Update is called once per frame
	public void Update () {
        transform.Translate(0, 0, Speed);
	}
}
