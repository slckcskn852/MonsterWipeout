using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController characterController;
	private Animator animator;

	[SerializeField]
	private float fSpeed = 7.5f;
	[SerializeField]
	private float bSpeed = 3;
	[SerializeField]
	private float turnSpeed = 150f;

	public int killCount;

	private void Awake()
	{
		killCount=0;
		characterController = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
        Cursor.lockState=CursorLockMode.Locked;
	}

	private void Update()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		var movement = new Vector3(h, 0, v);

		animator.SetFloat("Speed", v);

		transform.Rotate(Vector3.up, h * turnSpeed * Time.deltaTime);

		if (v != 0)
		{
			float moveSpeedToUse = (v > 0) ? fSpeed : bSpeed;

			characterController.SimpleMove(transform.forward * moveSpeedToUse * v);
		}
		if (Input.GetKeyDown("p"))
		{
			System.Random random = new System.Random();
			int randNum = random.Next(0,4);
			if(randNum==0){
				animator.Play("samba");
			}
			else if(randNum==1){
				animator.Play("gangnamStyle");
			}
			else if(randNum==2){
				animator.Play("floorCombo");
			}
			else if(randNum==3){
				animator.Play("macarena");				
			}

		}
	}
}