using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();
        //player.LoadPlayer();
        player.AttackDamage = 31;
        //player.SavePlayer();
        Debug.Log(player.AttackDamage);
        
        Text text = gameObject.GetComponent<Text>();
        
        text.text = player.AttackDamage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
