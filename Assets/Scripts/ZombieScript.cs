using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieScript : MonoBehaviour
{
    private NavMeshAgent enemyNav;

    [SerializeField]
    public int damage=1;
    public float fireRate=1f;

    private Animator anim;

    [SerializeField]
    private GameObject player;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer=0f;
        anim = GetComponentInChildren<Animator>();
        enemyNav=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        timer+=Time.deltaTime;
        
        if (Vector3.Distance(player.transform.position, gameObject.transform.position)<=enemyNav.stoppingDistance)
        {
            Debug.Log("In the circle");
            enemyNav.ResetPath();
            //anim.SetFloat("Blend", 0);
            anim.Play("attack");
            /*
            if (!enemy.isStopped)
            {
                enemy.Stop();
            }
            */
            if (timer>=fireRate)
            {
                
                timer=0f;
                Attack();
            }
        }
        else
        {
            Debug.Log("Out of the circle");
            anim.Play("idle");
            anim.SetFloat("selection", enemyNav.velocity.magnitude);
            enemyNav.SetDestination(player.transform.position); 
        }
        
    }
    void Attack(){
        
        player.GetComponent<Health>().TakeDamage(damage);
    }
}
