using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAmmo : Interactable
{
    public override void Interact(){
        PickUp();
    }
    void PickUp(){
        Debug.Log("Picked the item.");
        Destroy(gameObject);
    }
}
