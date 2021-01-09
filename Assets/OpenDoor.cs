using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(count == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
