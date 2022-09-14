using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Inventory
{
    private List<Item> itemList;
    public EventHandler OnItemListChanged;

    public Inventory()
    {
        itemList = new List<Item>();
    }
    public void AddItem(Item item)
    {
        CheckForStackable(item);
        //CheckForUniquePick(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    

    private void CheckForUniquePick(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount++;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
    }

    private void CheckForStackable(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount++;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount--;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                item.amount = 1;
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            item.amount = 1;
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
