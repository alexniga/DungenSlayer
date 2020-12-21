using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public List<GameObject> shields;
    // Start is called before the first frame update
    private void OnEnable()
    {
        for (int i = 0; i < shields.Count; i++)
        {
            shields[i].SetActive(true);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < shields.Count; i++)
        {
            shields[i].SetActive(false);
        }
    }
}
