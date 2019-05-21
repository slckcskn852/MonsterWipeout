using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using TMPro;

public class SpawningScript : MonoBehaviour
{   
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject lvltxt;
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    GameObject[] spawners = new GameObject[4];
    
    [SerializeField]
    private int spawnedEnemyCount;
    [SerializeField]
    private int level;
    private float timer;
    private float timerConst=1.05f;
    private int lastSpawn=0;
    void Start()
    {
        timer=0;
        level=0;
        spawnedEnemyCount=0;
        StartCoroutine(spawnEnemy());
        updateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer+=Time.deltaTime;
        int levelUp=level*(level+1)/2;
        //        if (levelUp>=spawnedEnemyCount && timer>=4)
        if (timer>=4)
        {
            //Debug.Log("levelUp>=spawnedEnemyCount && timer>=4");
            StartCoroutine(spawnEnemy());
            //timerConst*=1.05f;
            updateLevel();
            timer=0;
        }
        
        /* 
        int levelUp=level*(level+1)/2;
        if (spawnedEnemyCount<=levelUp && !isEnemySpawning)
        {
            for(int i=0;i<levelUp-spawnedEnemyCount;i++){
                StartCoroutine(spawnEnemy());
                updateLevel();
            }
            
        }
        */
        
        
    }
    private void updateLevel(){
        
           lvltxt.GetComponentInParent<TextMeshProUGUI>().SetText("Kills: "+ player.GetComponent<PlayerMovement>().killCount);
            lvltxt.GetComponent<TextMeshProUGUI>().SetText("Kills: " + player.GetComponent<PlayerMovement>().killCount);
            lvltxt.GetComponentInChildren<TextMeshProUGUI>().SetText("Kills: " + player.GetComponent<PlayerMovement>().killCount);
        
    }
    private IEnumerator spawnEnemy(){
        System.Random random = new System.Random();
        int randIndex=random.Next(0,3);
        while(lastSpawn==randIndex){
            randIndex=random.Next(0,3);
        }
        lastSpawn=randIndex;
        GameObject spawnedEnemy=Instantiate(enemy,spawners[randIndex].transform.position,Quaternion.identity);
        spawnedEnemy.SetActive(true);
        Animator anim = spawnedEnemy.GetComponentInChildren<Animator>();
        anim.Play("spawn");
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        spawnedEnemyCount+=1;
        spawnedEnemy.GetComponent<NavMeshAgent>().speed=2f;
        anim.Play("spawn");

    }
}
