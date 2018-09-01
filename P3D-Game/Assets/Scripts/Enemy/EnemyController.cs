using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
	private Rigidbody enemyRigidbody;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        agent.SetDestination(target.position);

		//Vector3 look = target.position - transform.position;

		//look.y = 0f;

		//Quaternion newRotation = Quaternion.LookRotation(look);

//		newRotation *= Quaternion.Euler (Vector3.up * 90);

		// Set the player's rotation to this new rotation.
//		transform.MoveRotation(newRotation);
	}
    
}
