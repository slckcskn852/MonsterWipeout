using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class killcount : MonoBehaviour
{
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // PlayerPrefs.SetInt("killCount", player.GetComponent<PlayerMovement>().killCount);
        txt.GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetInt("killCount").ToString());
    }
}
