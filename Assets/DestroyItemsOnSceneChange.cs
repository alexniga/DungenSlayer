using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemsOnSceneChange : MonoBehaviour
{
    private void OnDestroy()
    {
        GameObject[] grenades = GameObject.FindGameObjectsWithTag("item_Grenade");
        foreach(GameObject grenade in grenades)
        {
            Destroy(grenade);
        }

        GameObject[] health_Potions = GameObject.FindGameObjectsWithTag("item_HealthPotion");
        foreach (GameObject healthPotion in health_Potions)
        {
            Destroy(healthPotion);
        }

        GameObject[] boostSpeeds = GameObject.FindGameObjectsWithTag("item_BoostSpeed");
        foreach(GameObject boostSpeed in boostSpeeds)
        {
            Destroy(boostSpeed);
        }

        GameObject[] shields = GameObject.FindGameObjectsWithTag("item_Shield");
        foreach(GameObject shield in shields)
        {
            Destroy(shield);
        }

        GameObject[] golds = GameObject.FindGameObjectsWithTag("Gold");
        foreach(GameObject gold in golds)
        {
            Destroy(gold);
        }

    }
}
