using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController1 : MonoBehaviour
{
    // Start is called before the first frame update
    //public Interactable focus;	// Our current focus: Item, Enemy etc.

	public LayerMask mask;	// Filter out everything not walkable
	Camera cam;			// Reference to our camera
	PlayerMotor motor;	// Reference to our motor

    

    void Start()
    {
        cam=Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, mask)){
                Debug.Log("We hit "+ hit.collider.name + " " +hit.point);
                motor.MoveTo(hit.point);
            }
        }
        
    }
}
