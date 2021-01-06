using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private GameObject shield;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        shield = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        shield.SetActive(true);
    }

    private void OnDisable()
    {
        shield.SetActive(false);
    }
}
