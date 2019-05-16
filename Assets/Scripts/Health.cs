using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int initialHealth;
    [SerializeField]
    private int currentHealth;
    
    public GameObject player;

    [SerializeField]
    public Animator anim;

    private void OnEnable() {
        
        currentHealth=initialHealth;
    }

    public void TakeDamage(int damage){
        currentHealth-=damage;
        if (currentHealth<=0)
        {
            StartCoroutine(Die());
        }
        
    }

    private IEnumerator Die()
    {
        var navMesh = GetComponent<NavMeshAgent>();        
        if (navMesh!=null)
        {
            navMesh.Stop();
            player.GetComponent<PlayerMovement>().killCount+=1;
        }
        //void <-> IEnumerator
        anim.Play("dying");
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0));
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(gameObject);
        gameObject.SetActive(false);
        }

}
