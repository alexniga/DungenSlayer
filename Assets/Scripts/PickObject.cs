using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public Camera cam;
    public GameObject inventory;
    public GameObject player;
    private Collider2D collider;

    private Vector2 mousePos;
    private Vector2 playerPos;
    private Vector2 objPos;
    private float radius;
    private float distanceMouse;
    private float distancePlayer;

    private void Start()
    {
        objPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        collider = GetComponent<Collider2D>();
        Vector3 boxSize = collider.bounds.size;
        radius = boxSize.x / 2;
    }
    void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            distanceMouse = Vector2.Distance(objPos, mousePos);  
            distancePlayer = Vector2.Distance(objPos, playerPos);
            if (distanceMouse <= radius && distancePlayer <= radius*3)
            {
                collider.enabled = false;
                gameObject.transform.position = inventory.transform.position;
                Debug.Log("clicked");
            }
        }
    }
}
