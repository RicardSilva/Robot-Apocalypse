using System.Collections;
using UnityEngine;

public class BoxController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
            other.GetComponent<Rigidbody>().AddForce(Vector3.right * 2);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if (other.GetComponent<Rigidbody>())
            other.GetComponent<Rigidbody>().velocity = -1 * other.GetComponent<Rigidbody>().velocity;
    }
}
