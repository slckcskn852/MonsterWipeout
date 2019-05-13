using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
 
public class PlayerController : MonoBehaviour {
 
    public float movementSpeed;
 
    // Use this for initialization
    public Interactable focus;	// Our current focus: Item, Enemy etc.

	public LayerMask movementMask;	// Filter out everything not walkable

	Camera cam;			// Reference to our camera
	ThirdPersonCharacter player;	// Reference to our motor

	// Get references
	void Start () {
		cam = Camera.main;
		player = GetComponent<ThirdPersonCharacter>();
	}
 
    //Update is called once per frame
    void FixedUpdate () {
        /*
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w")) {
            transform.position -= transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed * 2.5f;
        }   else if (Input.GetKey ("w") && !Input.GetKey (KeyCode.LeftShift)) {
            transform.position -= transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
        }   else if (Input.GetKey ("s")) {
            transform.position += transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
        }
 
        if (Input.GetKey ("a") && !Input.GetKey ("d")) {
                transform.position += transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;
            } else if (Input.GetKey ("d") && !Input.GetKey ("a")) {
                transform.position -= transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;
            }
        
        */
        if (Input.GetKey("p"))
        {
            RemoveFocus();
        }

        // If we press right mouse
		if (Input.GetMouseButtonDown(1))
		{
			// We create a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If the ray hits
			if (Physics.Raycast(ray, out hit, 100))
			{
				Interactable interactable = hit.collider.GetComponent<Interactable>();
				if (interactable != null)
				{
					SetFocus(interactable);
				}
			}
		}
	}

	// Set our focus to a new focus
	void SetFocus (Interactable newFocus)
	{
		// If our focus has changed
		if (newFocus != focus)
		{
			// Defocus the old one
			if (focus != null)
				focus.OnDefocused();
			focus = newFocus;	// Set our new focus
		}
		newFocus.OnFocused(transform);
	}

	// Remove our current focus
	void RemoveFocus ()
	{
		if (focus != null)
			focus.OnDefocused();

		focus = null;
        
	}
}
