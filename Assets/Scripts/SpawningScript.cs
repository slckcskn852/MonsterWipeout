using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
    }
    private void updateLevel(){
        int levelUp=level*(level+1)/2;
        if (player.GetComponent<PlayerMovement>().killCount>=levelUp)
        {
            //Debug.Log("player.GetComponent<PlayerMovement>().killCount>=levelUp");
            level+=1;
            lvltxt.GetComponentInParent<TextMeshProUGUI>().SetText("Level "+level);
            lvltxt.GetComponent<TextMeshProUGUI>().SetText("Level "+level);
            lvltxt.GetComponentInChildren<TextMeshProUGUI>().SetText("Level "+level);
        }
    }
    private IEnumerator spawnEnemy(){
        System.Random random = new System.Random();
        int randIndex=random.Next(0,3);
        GameObject spawnedEnemy=Instantiate(enemy,spawners[randIndex].transform.position,Quaternion.identity);
        spawnedEnemy.SetActive(true);
        Animator anim = spawnedEnemy.GetComponentInChildren<Animator>();
        spawnedEnemyCount+=1;

        anim.Play("spawn");
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        anim.Play("spawn");

    }
}
