using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f,1.5f)]
    private float fireRate=0.1f;

    [SerializeField]
    [Range(1,10)]
    private int damage=1;

    /* 
    [SerializeField]
    private Transform firePoint;
    */

    [SerializeField]
    private ParticleSystem muzzle;
    [SerializeField]
    private AudioSource muzzleSound;

    private float timer;
    void Start()
    {

        muzzleSound=GetComponent<AudioSource>();
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
        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        muzzle.Play();
        muzzleSound.Play();
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one*0.5f);
        Debug.DrawRay(ray.origin, ray.direction*100, Color.red, 2f);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100)){
            var health = hitInfo.collider.GetComponent<Health>();
            if (health!=null)
            {
                //Destroy(hitInfo.collider.gameObject);
                health.TakeDamage(damage);
                //Debug.Log(hitInfo.collider.name+ " destroyed.");
            }
        }
    }
}
