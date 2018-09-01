using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHealth : EnemyHealth
{
    Animator animator;
    MeshRenderer rend;
    public float explosionRadius;
    ParticleSystem flames;
    ParticleSystem.EmissionModule emmision;
    Light spotLight;
    int flamesIntensity;
    int layerMask =  1 << 10;
	private AudioSource audioSource;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<MeshRenderer>();
        flames = GetComponentInChildren<ParticleSystem>();
        emmision = flames.emission;
        spotLight = GetComponentInChildren<Light>();
		audioSource = GetComponent<AudioSource> ();

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
            PlayAnimation();
            
            //Death();
            
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
        spotLight.intensity = flamesIntensity;
        emmision.rateOverTime = 0;
        isDead = false;
        rend.enabled = true;
        this.gameObject.SetActive(true);
    }

    void Explode()
    {
        gameObject.layer = 2;
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, explosionRadius, layerMask);
        gameObject.layer = 10;
        int i = 0;
        
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("TakeDamage", 5);
            i++;
            
        }
       
        isDead = true;
        rend.enabled = false;
		audioSource.Play();
    }

    void PlayAnimation() {
        animator.SetTrigger("play");
        Invoke("Death",0.8f);
    }

    protected override void Death()
    {
        this.gameObject.SetActive(false);
        Invoke("Respawn", 30);
    }
}