using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApearAfterScond : MonoBehaviour
{
    public GameObject button;

    float timer = 13f;

    public void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            button.SetActive(true);
    }
}
