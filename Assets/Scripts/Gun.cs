using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class Gun : MonoBehaviour
{
	[SerializeField]
	[Range(0.1f, 1.5f)]
	private float fireRate = 0.3f;

	[SerializeField]
	[Range(1, 10)]
	private int damage = 1;

    private int maxAmmo=30;
    private int currentAmmo=30;
    public GameObject ammoText;
    private bool isReloading=false;

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
        ammoText.GetComponent<TextMeshProUGUI>().SetText(currentAmmo+"/30");
        if(isReloading){
            return;
        }
        if (currentAmmo<=0 || Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            return;
        }

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
        currentAmmo--;
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
    private IEnumerator Reload(){
        isReloading=true;
        Animator anim = GetComponentInChildren<Animator>();
        anim.Play("Motion1");
        yield return new WaitForSeconds(3.1f);
        currentAmmo=maxAmmo;
        isReloading=false;
    }
}