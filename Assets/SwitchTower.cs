using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTower : MonoBehaviour
{
    public GameObject target;
    private GameObject player;
    private bool canClick;
    public bool isNotTower = false;
    // Start is called before the first frame update
    void Start()
    {
        canClick = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire2") && canClick)
        {
            Vector2 objPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector3 boxSize = gameObject.GetComponent<Collider2D>().bounds.size;
            float radius = boxSize.x / 2;

            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            float distancePlayer = Vector2.Distance(objPos, playerPos);
            if (distancePlayer <= radius * 4)
            {
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                canClick = false;
                if (!isNotTower)
                {
                    target.GetComponent<TowerShooting>().enabled = false;
                }
                else
                {
                    target.SetActive(false);
                }
            }
        }
    }
}
