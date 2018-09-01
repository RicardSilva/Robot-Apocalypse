using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHealthOld : EnemyHealth
{
    public float explosionRadius;
    ParticleSystem flames;
    ParticleSystem.EmissionModule emmision;
	Animator anim;
	Transform cylinder;
    Light spotLight;
    int flamesIntensity;
	int layerMask = 1 << 10;
	private AudioSource audioSource;
    void Start()
    {
        flames = GetComponentInChildren<ParticleSystem>();
        emmision = flames.emission;
        spotLight = GetComponentInChildren<Light>();
		audioSource = GetComponent<AudioSource> ();
		anim = transform.Find("Explosion").GetComponent<Animator>();
		cylinder = transform.Find ("Cylinder");

        currentHealth = startingHealth;
        flamesIntensity = 0;
        emmision.rateOverTime = 0;       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;
        flamesIntensity = startingHealth - currentHealth;
        Flames();
        if (currentHealth <= 0)
        {
            Explode();
			Death();
        }
    }

    void Flames()
    { 
        emmision.rateOverTime = Mathf.Pow(10, flamesIntensity) * 2;
        spotLight.intensity = flamesIntensity;
    }
    void Respawn()
    {
        currentHealth = startingHealth;
        flamesIntensity = 0;
        spotLight.intensity = 0;
        emmision.rateOverTime = 0;
        isDead = false;
		cylinder.gameObject.SetActive(true);
    }

    void Explode()
    {
		gameObject.layer = 2;
		Collider[] hitColliders = Physics.OverlapSphere (this.gameObject.transform.position, explosionRadius, layerMask);
		gameObject.layer = 10;
		int i = 0;
		spotLight.intensity = 0;
		emmision.rateOverTime = 0;       
        while (i < hitColliders.Length)
        {
           hitColliders[i].SendMessage("TakeDamage", 5);
           i++;
        }
		anim.SetTrigger ("play");
		audioSource.Play();
    }

    protected override void Death()
    {
        isDead = true;
        cylinder.gameObject.SetActive(false);
        Invoke("Respawn", 20);
    }
}
