using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public Text scoreText;
	public Text leaderboardText;

	void Start () {
		scoreText.text = "Score: " + ScoreManager.lastScore.ToString ();
		leaderboardText.text = ScoreManager.GetLeaderboard ();
    }
	
	
	void Update () {
		
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("Main");
	}
}
