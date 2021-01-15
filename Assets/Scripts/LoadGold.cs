using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();
        //player.LoadPlayer();
        player.Money = 205;
        //player.SavePlayer();
        Text text = gameObject.GetComponent<Text>();
        Debug.Log(player.Money);
        text.text = player.Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
