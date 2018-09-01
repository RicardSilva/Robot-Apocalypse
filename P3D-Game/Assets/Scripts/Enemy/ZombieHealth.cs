using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : EnemyHealth
{

    public int scoreValue = 1;
    public GameObject ammoBox;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    protected override void Death()
    {
        isDead = true;
        ScoreManager.score += scoreValue;
        
        
        if (Random.value > 0.7f)
            Instantiate(ammoBox, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
