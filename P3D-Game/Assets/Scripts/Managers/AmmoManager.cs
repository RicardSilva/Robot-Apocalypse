using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour {

    public GameObject ammoBox;
    GameObject lastBox;
    bool spawned;


	// Use this for initialization
	void Start () {
        spawned = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!spawned && PlayerShooting.ammo == 0 && Random.value < 0.05f) {
            lastBox = Instantiate(ammoBox, gameObject.transform.position, gameObject.transform.rotation);
            spawned = true;
        }
        if (lastBox == null)
            spawned = false; 
	}
}
