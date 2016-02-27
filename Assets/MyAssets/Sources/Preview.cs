using UnityEngine;
using System.Collections;

public class Preview : MonoBehaviour {
    /// <summary>
    /// 戦闘機
    /// </summary>
    public GameObject StarFighter;

	// Use this for initialization
	public void Start () {
        var fighter = (GameObject)Instantiate(StarFighter, new Vector3(0.0f, 2.86f, -6.0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	public void Update () {
	
	}
}
