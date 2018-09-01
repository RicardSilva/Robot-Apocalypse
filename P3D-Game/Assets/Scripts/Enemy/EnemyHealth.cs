using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 1;
    protected int currentHealth;
    protected bool isDead;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    protected virtual void Death()
    {
        isDead = true;
        Destroy(this.gameObject);
    }
}
