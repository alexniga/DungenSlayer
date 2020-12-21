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
            Debug.Log("Boom");
            //gameObject.GetComponent<Grenade>().enabled = false;
            isUsed = true;
        }
    }

    // Update is called once per frame
    private void OnEnable()
    {
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
}
