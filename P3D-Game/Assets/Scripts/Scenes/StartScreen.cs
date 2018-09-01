using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

	public InputField usernameInput; 

    public void StartGame()
    {
		string username = usernameInput.text;
		if (username.Equals (""))
			username = "Anonymous";
		ScoreManager.currentUser = username;
        SceneManager.LoadScene("Main");
    }


}
