using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadArmor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();
        player.LoadPlayer();
        //player.DamageReduction = 31;
        //player.SavePlayer();
        Text text = gameObject.GetComponent<Text>();
        text.text = player.DamageReduction.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
