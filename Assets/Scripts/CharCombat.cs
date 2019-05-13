using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCombat : MonoBehaviour
{
    CharacterStats mystat;
    
    private void Start() {
        mystat = GetComponent<CharacterStats>();
    }
    public void Attack(CharacterStats target){
        target.TakeDamage(mystat.damage.getBaseValue());
    }
}
