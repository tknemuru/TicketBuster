using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UserNameButtonController : MonoBehaviour {
    /// <summary>
    /// ユーザID
    /// </summary>
    public string UserId { get; set; }

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
    public void Update()
    {
	
	}

    public void OnClick()
    {
        Main.SelectedUserId = this.UserId;
        SceneManager.LoadScene("Preview");
    }
}
