using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{   
    [SerializeField]
    private GameObject player;
    [SerializeField]
    GameObject[] spawners = new GameObject[4];
    
    [SerializeField]
    private int spawnedEnemyCount;
    [SerializeField]
    private int level;
    void Start()
    {
        level=1;
        spawnedEnemyCount=1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void updateLevel(){
        if (player.GetComponent<Gun>())
        {
            
        }
    }
}
