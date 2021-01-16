using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    private GameObject player;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector2 objPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector3 boxSize = gameObject.GetComponent<Collider2D>().bounds.size;
            float radius = boxSize.x / 2;

            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            float distancePlayer = Vector2.Distance(objPos, playerPos);
            if (distancePlayer <= radius * 4)
            {

                gameObject.SetActive(false);
                door.SetActive(false);
                //Debug.Log("clicked");

            }
        }
    }
}
