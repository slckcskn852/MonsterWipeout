using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth {get;private set;}
    public Stat damage;

    void Awake() {
        currentHealth=maxHealth;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage){
        currentHealth-=damage;
        Debug.Log(transform.name + " "+ damage);
        if (currentHealth<=0)
        {
            KIA();
        }
    }
    //Killed In Action
    public virtual void KIA(){
        PlayerController pc=GetComponent<PlayerController>();
        pc.incKillCount();
        Debug.Log("Died");
        Destroy(gameObject);
    }
}
