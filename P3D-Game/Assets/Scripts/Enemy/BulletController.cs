using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public int attackDamage = 3;
    

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 )
        {
            other.SendMessage("TakeDamage", attackDamage);
            Destroy(gameObject);
        }
        else if(other.gameObject.layer == 11) {
            Destroy(gameObject);
        }
    }
    

   
}
