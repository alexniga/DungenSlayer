using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAllPannels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Pannels").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Pannels").transform.GetChild(1).gameObject.SetActive(true);
    }

}
