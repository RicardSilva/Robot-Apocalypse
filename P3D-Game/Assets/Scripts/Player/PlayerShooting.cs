using UnityEngine;
using UnityEngine.UI;


public class PlayerShooting : MonoBehaviour
{
    public Text ammoText;

    public int damagePerShot = 1;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
	private AudioSource audioSource;

    public static int ammo = 30;
    float timer;                                    // A timer to determine when to fire.
    Ray shootRay = new Ray();                       // A ray from the gun end forwards.
    RaycastHit shootHit;                          
    LineRenderer gunLine;                           // Reference to the line renderer.
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        // Set up the references.
		audioSource = GetComponent<AudioSource> ();
        gunLine = GetComponent<LineRenderer>();
    }

    void Start()
    {
        ammo = 30;
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;


        // If the Fire1 button is being press and it's time to fire...
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && ammo > 0)
        {
            // ... shoot the gun.
            Shoot();
        }
// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }

        ammoText.text = "Ammo: " + ammo.ToString();
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
    }


    void Shoot()
    {
        // Reset the timer.
        timer = 0f;
        ammo--;

		audioSource.Play ();
     
        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerShot);
            }

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition(1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
