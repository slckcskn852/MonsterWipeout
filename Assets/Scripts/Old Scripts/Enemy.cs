using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    CharacterStats mystats;
    private void Start() {
        mystats=GetComponent<CharacterStats>();
    }
    public override void Interact(){
        base.Interact();

    }
}
