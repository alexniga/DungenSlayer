using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public string description;
    public int quantity;
    public int iconKey;
    public double duration;
    public double cooldown;
    public bool isCancelable;

    public Item()
    {

    }

    public Item(Item item)
    {
        this.name = item.name;
        this.description = item.description;
        this.quantity = item.quantity;
        this.iconKey = item.iconKey;
        this.duration = item.duration;
        this.cooldown = item.cooldown;
        this.isCancelable = item.isCancelable;
    }
    
}
