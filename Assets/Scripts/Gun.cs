using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
	[SerializeField]
	[Range(0.1f, 1.5f)]
	private float fireRate = 0.3f;

	[SerializeField]
	[Range(1, 10)]
	private int damage = 1;

    /*
	[SerializeField]
	private Transform firePoint;
    */

	[SerializeField]
    private ParticleSystem muzzle;
    [SerializeField]
    private AudioSource muzzleSound;

	private float timer;

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= fireRate)
		{
			if (Input.GetButton("Fire1"))
			{
				timer = 0f;
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
        //Debug.Log("1");
        if(Physics.Raycast(ray, out hitInfo, 100)){
            //Debug.Log("2");
            var health = hitInfo.collider.gameObject.GetComponentInParent<Health>();
            //Debug.Log(Physics.Raycast(ray, out hitInfo, 100));
            //Debug.Log(hitInfo.collider.gameObject.name);
            GameObject gameObject = hitInfo.collider.gameObject;
            //Debug.Log(gameObject.GetComponentInParent<Health>());
            if (health!=null)
            {
                //Destroy(hitInfo.collider.gameObject);
                health.TakeDamage(damage);
                //Debug.Log(hitInfo.collider.name+ " destroyed.");
            }
        }
    }
}