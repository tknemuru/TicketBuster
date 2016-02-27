using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UserNameButtonController : MonoBehaviour {

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
    public void Update()
    {
	
	}

    public void OnClick()
    {
        SceneManager.LoadScene("Preview");
    }
}
