using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    public GameObject player;
    PlayerMovement movement;
    Shooting shooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        movement = player.GetComponent<PlayerMovement>();
        shooting = player.GetComponent<Shooting>();
        //Debug.Log(shooting.attackTimer); 
        movement.movementSpeed *= 2;
        shooting.attackTimer /= 3;
        Debug.Log(shooting.attackTimer);
    }

    private void OnDisable()
    {
        movement.movementSpeed /= 2;
        shooting.attackTimer *= 3;
    }
}
