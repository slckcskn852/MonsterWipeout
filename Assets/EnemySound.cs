using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] audios = new AudioClip[8];
    private bool isSoundPlaying=false;
    void Start()
    {
        source=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSoundPlaying)
        {
            StartCoroutine(playSound());
        }

        
    }
    IEnumerator playSound(){
        isSoundPlaying=true;
        System.Random random = new System.Random();
        int randIndex=random.Next(0,8);
        source.clip=audios[randIndex];
        source.Play();
        yield return new WaitForSeconds(source.clip.length+5f);
        isSoundPlaying=false;
    }
}
