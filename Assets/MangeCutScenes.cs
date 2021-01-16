using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MangeCutScenes : MonoBehaviour
{
    private string nextLevelName;
    private string currentLevelName;
    public int delay;
    float timer;
    private void Start()
    {
        currentLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().CurrentLevel();
        nextLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().IncreaseLevel();
        //StartCoroutine("ChangeTheScene");
        timer = delay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(currentLevelName);
        }

        if (Input.GetMouseButtonDown(0))
        {
            timer = 0f;
        }

    }
    IEnumerator ChangeTheScene()
    {
        print(delay);
        for (int i = 1; i <= delay; i++)
        {
            yield return new WaitForSeconds(1f);
            if (Input.GetMouseButtonDown(0))
            {
                break;
            }
        }
        
        print(nextLevelName);
        print(currentLevelName);
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(currentLevelName);
    }
}

