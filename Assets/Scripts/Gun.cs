using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f,1.5f)]
    private float fireRate=1f;

    [SerializeField]
    [Range(1,10)]
    private int damage=1;

    [SerializeField]
    private Transform firePoint;

    private float timer;
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if (timer>=fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer=0f;
                Attack();
            }
        }
    }
    private void Attack(){
        Debug.DrawRay(firePoint.position, firePoint.forward*100, Color.red, 2f);
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100)){
            var health = hitInfo.collider.GetComponent<Health>();
            if (health!=null)
            {
                //Destroy(hitInfo.collider.gameObject);
                health.TakeDamage(damage);
                Debug.Log(hitInfo.collider.name+ " destroyed.");
            }
        }
    }
}
