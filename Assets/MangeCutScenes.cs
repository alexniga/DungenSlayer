using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MangeCutScenes : MonoBehaviour
{
    private string nextLevelName;
    private string currentLevelName;
    public int delay;
    private void Start()
    {
        currentLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().CurrentLevel();
        nextLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().IncreaseLevel();
        StartCoroutine("ChangeTheScene");
    }

    IEnumerator ChangeTheScene()
    {
        print(delay);
        yield return new WaitForSeconds(delay);
        print(nextLevelName);
        print(currentLevelName);
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(currentLevelName);
    }
}

