using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : CancelableItem
{
    public GameObject grenadeRange;
    public GameObject grenadeArea;
    public Camera cam;

    private Vector2 mousePos;
    private Vector2 playerPos;
    private float distancePlayer;
    private float range = 4.1f;
    private DateTime timer;
    private int state = 0;
    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector2(grenadeRange.transform.position.x, grenadeRange.transform.position.y);
        distancePlayer = Vector2.Distance(mousePos, playerPos);
        grenadeArea.transform.position = new Vector3(mousePos.x, mousePos.y, grenadeArea.transform.position.z);
        if (distancePlayer >= range)
        {
            Debug.Log("Out of range");
            //gameObject.GetComponent<Grenade>().enabled = false;
            isCanceled = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            //Debug.Log("Boom");
            //gameObject.GetComponent<Grenade>().enabled = false;
            //isUsed = true;
            AreaDamageEnemies();
            timer = DateTime.UtcNow.AddSeconds(0);
            state = 1;
        }
        if (state == 1 && (DateTime.UtcNow - timer).TotalSeconds >= 0)
        {
            Debug.Log("Boom");
            isUsed = true;
            state = 0;
        }
    }

    // Update is called once per frame
    private void OnEnable()
    {
        Vector3 boxSize = grenadeArea.GetComponent<SpriteRenderer>().bounds.size;
        radius = boxSize.x / 2;
        grenadeRange.SetActive(true);
        grenadeArea.SetActive(true);
        isCanceled = false;
        isUsed = false;
    }

    private void OnDisable()
    {
        grenadeRange.SetActive(false);
        grenadeArea.SetActive(false);

    }

    void AreaDamageEnemies()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(mousePos, radius);
        foreach (Collider2D col in objectsInRange)
        {
            String enemy = col.gameObject.name;
            Debug.Log(enemy);

        }
    }
}
