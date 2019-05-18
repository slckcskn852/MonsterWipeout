
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;



public class Enemy : MonoBehaviour {

    private AggroDetection aggroDetection;
    private Health healthTarget;
    private GameObject player;

    private Animator anim;

    [SerializeField]
    private float attackRefreshRate = 1.5f;
    private float attackTimer;

    private void Start() {
        anim = GetComponentInChildren<Animator>();
    }
    private void Awake() {
        //anim=gameObject.GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target){
        PlayerMovement isPlayer=target.GetComponentInParent<PlayerMovement>();
        //Debug.Log(isPlayer);
        if (isPlayer)
        {
            healthTarget = target.GetComponentInParent<Health>();
            //Debug.Log(healthTarget);
            player=target.gameObject;
        }
    }
    private void Update() {
        if (healthTarget != null)
        {
            //Debug.Log("health target not null");
            attackTimer += Time.deltaTime;
            if(CanAttack()){
                //Debug.Log("attack called");
                StartCoroutine(Attack());
            }
        }
        else
        {
        //Debug.Log("health target is null");            
        }
    }
    private bool CanAttack(){
        //Debug.Log(Vector3.Distance(gameObject.transform.position, player.transform.position));
        if (Vector3.Distance(gameObject.transform.position, player.transform.position)<=gameObject.GetComponent<NavMeshAgent>().stoppingDistance && attackTimer >= attackRefreshRate)
        {
            if (gameObject.GetComponent<Health>().isDead)
            {
                return false;
            }
            return true;
        }
        else
        {
            return false;
        }
        //return attackTimer >= attackRefreshRate;
    }
    private IEnumerator Attack(){
        
        
        anim.Play("attack");
        attackTimer = 0;
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        healthTarget.TakeDamage(1);
    }
    
    
}