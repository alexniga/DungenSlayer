using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : MonoBehaviour
{
    public Slider slider;
    public Text text;
    private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        maxHealth = 100f;
        slider.value = slider.value + 20;
        if (slider.value > maxHealth)
        {
            slider.value = maxHealth;
        }
        text.text = slider.value.ToString() + " / 100";
    }
}
