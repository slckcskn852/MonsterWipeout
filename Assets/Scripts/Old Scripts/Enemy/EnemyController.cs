using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update() {
        float dist = Vector3.Distance(transform.position, target.position);
        agent.SetDestination(target.position);
        if(dist<=agent.stoppingDistance){
            Vector3 direction = (target.position-transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
        }
    }
}