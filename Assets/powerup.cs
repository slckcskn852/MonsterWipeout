using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public GameObject pickupeffect;
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupeffect, transform.position, transform.rotation);

        Health hp = player.GetComponent<Health>();

        hp.currentHealth = 20;

        Destroy(gameObject);
    }
}
