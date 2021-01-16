using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 movement;
    private Vector2 mousePos;

    private Rigidbody2D rbPlayer;
    private Rigidbody2D rbWeapon;
    private Camera cam;

    private void Start()
    {
        movementSpeed = 5f;
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rbWeapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        float sign = Mathf.Sign(rbPlayer.position.x - mousePos.x);

        float valuePX = Mathf.Abs(rbPlayer.transform.localScale.x);
        float valuePY = rbPlayer.transform.localScale.y;
        float valuePZ = rbPlayer.transform.localScale.z;

        float valueWX = Mathf.Abs(rbWeapon.transform.localScale.x);
        float valueWY = Mathf.Abs(rbWeapon.transform.localScale.y);
        float valueWZ = rbWeapon.transform.localScale.z;
        if (sign > 0)
        {
            rbPlayer.transform.localScale = new Vector3(-valuePX, valuePY, valuePZ);
            rbWeapon.transform.localScale = new Vector3(-valueWX, valueWY, valueWZ);
        }
        else
        {
            rbPlayer.transform.localScale = new Vector3(valuePX, valuePY, valuePZ);
            rbWeapon.transform.localScale = new Vector3(valueWX, valueWY, valueWZ);
        }

        rbPlayer.MovePosition(rbPlayer.position + movement * movementSpeed * Time.fixedDeltaTime);
        rbWeapon.MovePosition(rbPlayer.position);

        Vector2 lookDir = mousePos - rbPlayer.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbWeapon.rotation = angle;
    }
}
