using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 20;
    public int currentHealth;

    bool isDead;

    public Text hpText;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        hpText.text = "Health points: " + currentHealth.ToString();
    }

    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        if (currentHealth <= 0 && !isDead)
        {
            Death(); 
        }
    }
    

    void Death()
    {
        isDead = true;
        ScoreManager.GameEnd();
        SceneManager.LoadScene("EndScreen");
    }
}
