using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Camera cam;
    private List<Item> items;
    private List<Item> slots;
    private List<DateTime> startCountDurations;
    private List<DateTime> startCountCoolDowns;
    private GameObject player;
    public GameObject shopBg;
    public Text gold;
    public Text shopTitle;
    public List<Text> quatities;
    public List<Text> cooldowns;
    public List<Text> durations;
    public List<Sprite> sprites;
    public List<Image> icons;
    public List<GameObject> itemDescriptions;
    public List<GameObject> itemPrefabs;
    public List<Text> shopPrices;
    private Dictionary<string, int> prefabPositions;
    private int openedSlot;
    private List<string> shopItems;
    private List<string> levelNames;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        CreateItemList();
        CreatePrefabPositions();
        level = 0;
        CreateLevelNames();
        //SceneManager.LoadScene(levelNames[level], LoadSceneMode.Additive);
        openedSlot = -1;
        startCountDurations = new List<DateTime>();
        for(int i = 1; i<=5;i++)
            startCountDurations.Add(new DateTime());

        startCountCoolDowns = new List<DateTime>();
        for (int i = 1; i <= 5; i++)
            startCountCoolDowns.Add(new DateTime());

        slots = new List<Item>();
        for (int i = 1; i <= 5; i++)
            slots.Add(null);

        
        slots[0] = (new Item(items[0]));
        icons[0].sprite = sprites[slots[0].iconKey];
        icons[0].enabled = true;
        quatities[0].text = slots[0].quantity.ToString();

        slots[1] = (new Item(items[1]));
        icons[1].sprite = sprites[slots[1].iconKey];
        icons[1].enabled = true;
        quatities[1].text = slots[1].quantity.ToString();

        slots[2] = (new Item(items[2]));
        icons[2].sprite = sprites[slots[2].iconKey];
        icons[2].enabled = true;
        quatities[2].text = slots[2].quantity.ToString();

        slots[3] = (new Item(items[3]));
        icons[3].sprite = sprites[slots[3].iconKey];
        icons[3].enabled = true;
        quatities[3].text = slots[3].quantity.ToString();

        slots[4] = (new Item(items[4]));
        icons[4].sprite = sprites[slots[4].iconKey];
        icons[4].enabled = true;
        quatities[4].text = slots[4].quantity.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        PerformAction();

        PickObject();

        ItemDescription();

        ShiftFunctionalities();

        Shop();

    }
    public string CurrentLevel()
    {
        Debug.Log(levelNames[level]);
        return levelNames[level];
    }

    public string IncreaseLevel()
    {
        level++;
        Debug.Log(levelNames[level]);
        return levelNames[level];
    }
    private void CreateLevelNames()
    {
        levelNames = new List<string>();
        levelNames.Add("puzzle_room_1");
        levelNames.Add("fight_room_2");
        levelNames.Add("fight_room_1");
        levelNames.Add("shop_room_1");
        levelNames.Add("fight_room_2");
        levelNames.Add("fight_room_1");
        levelNames.Add("puzzle_room_2");
        levelNames.Add("shop_room_2");

    }

    private void CreateItemList()
    {
        items = new List<Item>();
        slots = new List<Item>();
        shopItems = new List<string>();
        shopItems.Add("HealthPotion");
        shopItems.Add("BoostSpeed");
        shopItems.Add("Grenade");
        shopItems.Add("Shield");
        Item item1 = new Item
        {
            name = "TestMessage",
            quantity = 2,
            iconKey = 1,
            duration = 3,
            cooldown = 5,
            isCancelable = false
        };
        Item item2 = new Item
        {
            name = "HealthPotion",
            description = "Heal your character for 20 points",
            quantity = 2,
            iconKey = 0,
            duration = 1,
            cooldown = 5,
            isCancelable = false
};

        Item item3 = new Item
        {
            name = "BoostSpeed",
            description = "Increase your movement speed by 100% and your attack speed by 200%",
            quantity = 2,
            iconKey = 3,
            duration = 5,
            cooldown = 5,
            isCancelable = false
    };

        Item item4 = new Item
        {
            name = "Shield",
            description = "Raise your shield to block any attack coming from the direction you are facing",
            quantity = 2,
            iconKey = 2,
            duration = 5,
            cooldown = 5,
            isCancelable = false
    };

        Item item5 = new Item
        {
            name = "Grenade",
            description = "select a place in range, then press middle mouse button to throw a grenade for 40 damage",
            quantity = 2,
            iconKey = 1,
            duration = 1000,
            cooldown = 3,
            isCancelable = true
    };

        //items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
    }

    private void CreatePrefabPositions()
    {
        prefabPositions = new Dictionary<string, int>();
        prefabPositions.Add("HealthPotion", 0);
        prefabPositions.Add("BoostSpeed", 1);
        prefabPositions.Add("Shield", 2);
        prefabPositions.Add("Grenade", 3);
    }

    private void PerformAction()
    {
        for (int i = 0; i < 5; i++)
        {
            if (slots.ElementAtOrDefault(i) != null)
            {
                //Behaviour action = (Behaviour)gameObject.GetComponent(slots[i].name);
                if (slots[i].isCancelable)
                {
                    CancelableItem action = (CancelableItem)gameObject.GetComponent(slots[i].name);
                    if (action.isCanceled)
                    {
                        startCountDurations[i] = DateTime.UtcNow;
                        action.isCanceled = false;
                    }
                    
                    if (action.isUsed)
                    {
                        //Debug.Log("used");
                        action.isUsed = false;
                        startCountDurations[i] = DateTime.UtcNow;
                        slots[i].quantity--;
                        quatities[i].text = slots[i].quantity.ToString();
                        if (slots[i].quantity == 0)
                        {
                            quatities[i].text = "";

                        }
                    }
                }

                double coolDownTimer = (startCountCoolDowns[i] - DateTime.UtcNow).TotalSeconds;
                double durationTimer = (startCountDurations[i] - DateTime.UtcNow).TotalSeconds;
                if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(Key(i)) && durationTimer < 0 && coolDownTimer < 0)
                {
                    Behaviour action = (Behaviour)gameObject.GetComponent(slots[i].name);
                    action.enabled = true;
                    startCountDurations[i] = DateTime.UtcNow;
                    startCountDurations[i] = startCountDurations[i].AddSeconds(slots[i].duration);
                    if (slots[i].quantity != -1 && !slots[i].isCancelable)
                    {
                        slots[i].quantity--;
                        quatities[i].text = slots[i].quantity.ToString();
                        if (slots[i].quantity == 0)
                        {
                            quatities[i].text = "";

                        }
                    }

                }

                durationTimer = (startCountDurations[i] - DateTime.UtcNow).TotalSeconds;
                if (durationTimer < 0 && ((Behaviour)gameObject.GetComponent(slots[i].name)).enabled == true)
                {
                    ((Behaviour)gameObject.GetComponent(slots[i].name)).enabled = false;
                    if(slots[i].quantity == 0)
                    {
                        RemoveItemFromSlot(i);
                        startCountCoolDowns[i] = DateTime.UtcNow;
                    }
                    else
                    {
                        startCountCoolDowns[i] = DateTime.UtcNow;
                        startCountCoolDowns[i] = startCountCoolDowns[i].AddSeconds(slots[i].cooldown);
                    }

                }

            }

            int cooldown = (int)(startCountCoolDowns[i] - DateTime.UtcNow).TotalSeconds;
            int duration = (int)(startCountDurations[i] - DateTime.UtcNow).TotalSeconds;

            if (cooldown > 0)
            {
                cooldowns[i].text = cooldown.ToString();
            }
            else
            {
                cooldowns[i].text = "";
            }

            if (duration > 0 && slots[i].duration < 100)
            {
                durations[i].text = duration.ToString();
            }
            else
            {
                durations[i].text = "";

            }
        }
    }

    private void PickObject()
    {
        if (Input.GetButtonDown("Fire2") && !ClickedOnInventory())
        {
            Tuple<string, int> itemClicked = ClickedOnObject();
      
            if (itemClicked != null)
            {
                PutObjectInInventory(itemClicked);

            }
        }
    }

    private void PutObjectInInventory(Tuple<string, int> itemClicked)
    {
        string itemName = itemClicked.Item1;
        int itemQuantity = itemClicked.Item2;
        Debug.Log(itemName);
        int pos = SearchItemInList(itemName, slots);
        Debug.Log(pos);
        if (pos != -1)
        {
            slots[pos].quantity += itemQuantity;
            quatities[pos].text = slots[pos].quantity.ToString();
        }
        else
        {
            Item item = items[SearchItemInList(itemName, items)];
            item.quantity = itemQuantity;
            Debug.Log(item.quantity);
            int posEmpty = SearchFirstNull();
            if (posEmpty != -1)
            {
                slots[posEmpty] = (new Item(item));
                icons[posEmpty].sprite = sprites[slots[posEmpty].iconKey];
                icons[posEmpty].enabled = true;
                quatities[posEmpty].text = slots[posEmpty].quantity.ToString();
            }

        }
    }

    private void ItemDescription()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            
            if (openedSlot != -1)
            {
                if (!ClickedOnInventoryOrShopSlot("slot" + (openedSlot + 1).ToString()))
                {
                    itemDescriptions[openedSlot].SetActive(false);
                    openedSlot = -1;
                }





            }
            for (int i = 0; i < 5; i++)
            {
                if(slots[i] != null)
                {
                    if (ClickedOnInventoryOrShopSlot("slot" + (i + 1).ToString()))
                    {
                        openedSlot = i;
                        itemDescriptions[openedSlot].SetActive(true);
                        ((Text)(itemDescriptions[openedSlot].transform.GetChild(0).GetComponent<Text>())).text = slots[openedSlot].name;
                        ((Text)(itemDescriptions[openedSlot].transform.GetChild(1).GetComponent<Text>())).text = slots[openedSlot].description;
                    }
                }
                
            }
        }
    }

    private void ShiftFunctionalities()
    {
        if (openedSlot != -1)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("shift");
                for (int i = 0; i < 5; i++)
                {
                    if (Input.GetKeyDown(Key(i)))
                    {
                        Item newItem = slots[openedSlot];
                        slots[openedSlot] = slots[i];
                        slots[i] = newItem;

                        if (quatities[i].text.Equals("-1"))
                        {
                            quatities[i].text = "";
                        }
                        else
                        {
                            quatities[i].text = slots[i].quantity.ToString();
                        }

                        if (slots[openedSlot] == null || quatities[openedSlot].text.Equals("-1"))
                        {
                            quatities[openedSlot].text = "";
                        }
                        else
                        {
                            quatities[openedSlot].text = slots[openedSlot].quantity.ToString();
                        }

                        icons[i].sprite = sprites[slots[i].iconKey];
                        icons[i].enabled = true;
                        if (slots[openedSlot] != null)
                        {
                            icons[openedSlot].sprite = sprites[slots[openedSlot].iconKey];
                        }
                        else
                        {
                            icons[openedSlot].sprite = null;
                            icons[openedSlot].enabled = false;
                        }

                        itemDescriptions[openedSlot].SetActive(false);
                        openedSlot = i;
                        itemDescriptions[openedSlot].SetActive(true);
                        ((Text)(itemDescriptions[openedSlot].transform.GetChild(0).GetComponent<Text>())).text = slots[openedSlot].name;
                        ((Text)(itemDescriptions[openedSlot].transform.GetChild(1).GetComponent<Text>())).text = slots[openedSlot].description;
                    }
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    DropItemFromSlot(openedSlot);
                    itemDescriptions[openedSlot].SetActive(false);
                    openedSlot = -1;
                }
            }
        }
    }

    private void Shop()
    {
        if (Input.GetButtonDown("Fire2") && ClickedOnShop())
        {
            player.GetComponent<Shooting>().shopOpened = true;
            shopBg.SetActive(true);
            
        }
        //Debug.Log(shopBg.activeSelf);
        if (shopBg.activeSelf && Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("shop");
            for(int i = 0; i < 4; i++)
            {
                string tag = "shop_" + shopItems[i];
                if (ClickedOnInventoryOrShopSlot(tag))
                {
                    //Debug.Log(tag);
                    if (int.Parse(gold.text) >= int.Parse(shopPrices[i].text))
                    {
                        PutObjectInInventory(new Tuple<string, int>(shopItems[i], 1));
                        shopTitle.text = "Thank you for purchasing";
                        gold.text = (int.Parse(gold.text) - int.Parse(shopPrices[i].text)).ToString();
                    }
                    else
                    {
                        shopTitle.text = "Not enough money";
                    }
                }
            }
        }
    }

    private int SearchFirstNull()
    {
        for (int i = 0; i < 5; i++)
        {
            if(slots[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    private int SearchItemInList(string itemName, List<Item> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null && list[i].name.Equals(itemName))
            {
                //Debug.Log(list[i].name);
                return i;
            }
        }
        return -1;
    }

    private KeyCode Key(int i)
    {
        if (i == 0)
            return KeyCode.Alpha1;
        else if (i == 1)
            return KeyCode.Alpha2;
        else if (i == 2)
            return KeyCode.Alpha3;
        else if (i == 3)
            return KeyCode.Alpha4;
        else
            return KeyCode.Alpha5;

    }
    private void RemoveItemFromSlot(int i)
    {
        Behaviour action = (Behaviour)gameObject.GetComponent(slots[i].name);
        slots[i] = null;
        icons[i].enabled = false;
        //action.enabled = false;
        quatities[i].text = "";
        //startCountDurations[i] = DateTime.UtcNow;
    }

    private void DropItemFromSlot(int i)
    {
        GameObject itemDropped = Instantiate(itemPrefabs[prefabPositions[slots[i].name]], player.transform.position, player.transform.rotation);
        Debug.Log("quantityDropped"+ slots[i].quantity.ToString());
        itemDropped.GetComponent<ItemQuantity>().quantity = slots[i].quantity;
        RemoveItemFromSlot(i);
    }

    private bool ClickedOnInventoryOrShopSlot(string tag)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for (int i = 0; i < raycastResultList.Count; i++)
        {
            
            if (tag.Contains("slot") && raycastResultList[i].gameObject.CompareTag(tag))
            {
                return true;
            }
            if (tag.Contains("shop") && raycastResultList[i].gameObject.CompareTag(tag))
            {
                return true;
            }

        }

        return false;
    }


    private bool ClickedOnInventory()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        string tag = "slot";
        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for (int i = 0; i < raycastResultList.Count; i++)
        {
            
                if (tag.Equals("slot") && raycastResultList[i].gameObject.tag.Contains(tag))
                {
                    return true;
                }
       
        }

        return false;
    }

    private string ClickedOnObjectUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for (int i = 0; i < raycastResultList.Count; i++)
        {
            GameObject item = raycastResultList[i].gameObject;
            if (item.tag.Contains("item"))
            {
                item.SetActive(false);
                return item.tag.Substring(5);
            }
        }

        return null;
    }

    private Tuple<string,int> ClickedOnObject()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit = Physics2D.Raycast(mousePos, Vector2.up);
        Collider2D collider = raycastHit.collider;
        if (collider != null)
        {

            //Debug.Log(collider.gameObject.name);
            GameObject item = collider.gameObject;
            if (item.tag.Contains("item"))
            {
                int quantity = item.GetComponent<ItemQuantity>().quantity;

                Vector2 objPos = new Vector2(item.transform.position.x, item.transform.position.y);
                Vector3 boxSize = collider.bounds.size;
                float radius = boxSize.x / 2;

                Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
                
                float distancePlayer = Vector2.Distance(objPos, playerPos);
                if (distancePlayer <= radius * 3)
                {
                    //collider.enabled = false;
                    item.SetActive(false);
                    Debug.Log("clicked");
                    return new Tuple<string, int>(item.tag.Substring(5), quantity);
                }
            }
            
        }

        return null;
        
    }

    private bool ClickedOnShop()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit = Physics2D.Raycast(mousePos, Vector2.up);
        Collider2D collider = raycastHit.collider;
        //Debug.Log(collider);
        if (collider != null)
        {

            //Debug.Log(collider.gameObject.name);
            GameObject item = collider.gameObject;
            if (item.tag.Equals("Shop"))
            {
                
                Vector2 objPos = new Vector2(item.transform.position.x, item.transform.position.y);
                Vector3 boxSize = collider.bounds.size;
                float radius = boxSize.x / 2;

                Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
                float distancePlayer = Vector2.Distance(objPos, playerPos);
                if (distancePlayer <= radius * 3)
                {
                    
                    return true;
                    
                }
            }

        }

        return false;
    }

}
