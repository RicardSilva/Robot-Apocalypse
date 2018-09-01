using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int lastScore;
    public static string currentUser;

    static TupleList<int, string> scoreList = new TupleList<int, string>();

    public static ScoreManager Instance;


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {         
        score = 0;
    }

    public static void GameEnd() {
        scoreList.Add(score, currentUser);
        lastScore = score;
        score = 0;
    }

    public static string GetLeaderboard() {
        scoreList.SortDescending();
        string leaderboard = "";
        int counter = Mathf.Min(10, scoreList.Count);
        for (int i = 0; i < counter ; i++)
        {
            string lusername = scoreList[i].Value;
            string lscore = scoreList[i].Key.ToString();
            leaderboard += lusername;
            for (int j = 0; j < 145 - lusername.Length - lscore.Length; j++)
                leaderboard += ".";
                
            leaderboard += lscore + "\n";
        }
        return leaderboard;
    }

    void Update()
    {
        
    }
}
