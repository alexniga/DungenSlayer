using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitShop : MonoBehaviour
{
    public GameObject player;
    public GameObject shop;
    public Text shopTitle;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ClickFunction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ClickFunction()
    {
        //Debug.Log("exit");
        player.GetComponent<Shooting>().shopOpened = false;
        shop.SetActive(false);
        shopTitle.text = "Welcome to the shop";
    }
}
