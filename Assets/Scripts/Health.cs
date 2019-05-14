using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int initialHealth;
    private int currentHealth;

    private void OnEnable() {
        initialHealth=5;
        currentHealth=initialHealth;
    }

    public void TakeDamage(int damage){
        currentHealth-=damage;
        if (currentHealth<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        gameObject.SetActive(false);
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
