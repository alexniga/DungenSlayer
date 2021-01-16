using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    private GameObject player;
    private Text text;
    private int buffValue;
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        buffValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (name.Equals("DamageBuff"))
        {
            text = GameObject.FindGameObjectWithTag("DamageValue").GetComponent<Text>();

        }
        else if(name.Equals("ArmorBuff"))
        {

            text = GameObject.FindGameObjectWithTag("ArmorValue").GetComponent<Text>();
            
        }

        
        if (Input.GetButtonDown("Fire2"))
        {
            Vector2 objPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector3 boxSize = gameObject.GetComponent<Collider2D>().bounds.size;
            float radius = boxSize.x / 2;

            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            float distancePlayer = Vector2.Distance(objPos, playerPos);
            if (distancePlayer <= radius * 3)
            {
                text.text = (int.Parse(text.text) + buffValue).ToString();
                gameObject.SetActive(false);
                //Debug.Log("clicked");

            }
        }
    }


}
