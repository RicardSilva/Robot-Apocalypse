using UnityEngine;
using UnityEngine.UI;


public class EnemyShooting : MonoBehaviour
{
   // GameObject player;
    public GameObject bulletPrefab;
    public int damagePerShot = 3;                  // The damage inflicted by each bullet.
    public float ttlShot = 3.0f;
    public float timeBetweenBullets = 5f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
	private AudioSource audioSource;


    public static int ammo = 100000;
    float timer;                                    // A timer to determine when to fire.


    void Awake()
    {
		audioSource = GetComponent<AudioSource> ();
       // player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        ammo = 100000;
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;


        // If the Fire1 button is being press and it's time to fire...
        if (timer >= timeBetweenBullets && Time.timeScale != 0 && ammo > 0)
        {
            Shoot();
        }


    }




    void Shoot()
    {
        timer = 0f;
        ammo--;
        
		audioSource.Play ();

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position,
			transform.rotation);
        
		Vector3 dir = new Vector3 (0, 0, 1);
		dir = transform.rotation * dir;
		//bullet.GetComponent<Rigidbody>().velocity = (player.transform.position - transform.position).normalized * 6;
		bullet.GetComponent<Rigidbody>().velocity =  dir.normalized * 6;
  
        Destroy(bullet, ttlShot);
    }

}
