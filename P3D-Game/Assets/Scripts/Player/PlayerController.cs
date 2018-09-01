using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
    public Text scoreText;
	Animator anim;                      // Reference to the animator component.

    private Rigidbody playerRigidbody;
    private Vector3 movement;
    int floorMask;
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
 


	void Start ()
	{
        floorMask = LayerMask.GetMask("Floor");
		Transform m = transform.Find("CyberSoldier");
		playerRigidbody = GetComponent<Rigidbody>();
		anim = m.GetComponent <Animator> ();

	}

	
	void FixedUpdate ()
	{
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move(h, v);

        // Turn the player to face the mouse cursor.
        Turning();

		Animating (h, v);
    }

    void Update()
    {
        scoreText.text = "Score: " + ScoreManager.score.ToString();
    }
    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
			transform.Find("CyberSoldier").GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
   
    void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Ammo Box"))
		{
            PlayerShooting.ammo += 15;
			Destroy(other.gameObject);
            
        }
	}

	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;

		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsMoving", walking);
	}
    
}