using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    public GameObject StarFighter;
    public Canvas canvas;
    public GameObject UserNameButton;

	// Use this for initialization
	void Start () {
        GameObject fighter = Instantiate(StarFighter);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(fighter.transform.position);
        GameObject button = (GameObject)Instantiate(UserNameButton, new Vector3(fighter.transform.position.x + 120, screenPos.y, fighter.transform.position.z), Quaternion.identity);
        button.transform.SetParent(canvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
