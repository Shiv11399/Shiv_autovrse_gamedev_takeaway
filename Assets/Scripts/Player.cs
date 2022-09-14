using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] InventoryPanel _inventoryPanel;

    private void Awake()
    {
        inventory = new Inventory();
        _inventoryPanel.SetInventory(inventory);
        _inventoryPanel.SetPlayer(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            Item item = itemWorld.GetItem();
            if (item.IsUniquePickUp())
            {
                foreach(Item I in inventory.GetItemList()) // if there is a unique item then dont pick another !!!
                {
                    if (I.IsUniquePickUp())
                    {
                        return;
                    }
                }
            }
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    public void OpenInventory()
    {
        _inventoryPanel.gameObject.SetActive(!_inventoryPanel.gameObject.activeSelf);
    }
}
