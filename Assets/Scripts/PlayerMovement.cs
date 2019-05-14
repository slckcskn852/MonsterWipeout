using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController characterController;
	private Animator anim;

	[SerializeField]
	private float moveSpeed = 100;
	[SerializeField]
	private float turnSpeed = 5f;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
		anim = GetComponentInChildren<Animator>();
	}
	private void Update()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		characterController.SimpleMove(new Vector3(h, 0, v) * Time.deltaTime * moveSpeed);

		anim.SetFloat("Speed", new Vector3(h, 0, v).magnitude);

		if (new Vector3(h, 0, v).magnitude > 0)
		{
			Quaternion newDir = Quaternion.LookRotation(new Vector3(h, 0, v));

			transform.rotation = Quaternion.Slerp(transform.rotation, newDir, Time.deltaTime * turnSpeed);
		}
	}
}