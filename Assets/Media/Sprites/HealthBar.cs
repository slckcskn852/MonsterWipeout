using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private GameObject bar;
    private Image barSprite;
    public GameObject healthText;
    void Start()
    {
        barSprite=bar.GetComponentInChildren<Image>();
    }
    public void SetSize(float sizeNorm){
        Debug.Log(sizeNorm);
        barSprite.fillAmount=sizeNorm;
        healthText.GetComponent<TextMeshProUGUI>().SetText("Health: "+ sizeNorm*100);
    }

    
}
