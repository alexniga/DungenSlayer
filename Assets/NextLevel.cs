using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private string nextLevelName;
    private string currentLevelName;
    private void Start()
    {
        currentLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().CurrentLevel();
        nextLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().IncreaseLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(currentLevelName);
        }
    }
    
}
