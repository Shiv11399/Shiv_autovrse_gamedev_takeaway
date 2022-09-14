using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
    private Inventory _Inventory;
   [SerializeField]private Transform Container;
    [SerializeField]private GameObject InventoryItem;
    private Player player;

    private void OnEnable()
    {
        ItemIcon.dropItem += DropBtn;
    }
    private void OnDisable()
    {
        ItemIcon.dropItem -= DropBtn;
    }
    public void SetInventory(Inventory inventory)
    {
        _Inventory = inventory;
        inventory.OnItemListChanged += OnListChanged;
        Refresh();
    }
    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    private void OnListChanged(object sender, EventArgs e)
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach(Transform child in Container)
        {
            Destroy(child.gameObject);
        }
        foreach(Item item in _Inventory.GetItemList())
        {
            GameObject I = Instantiate(InventoryItem, Container);
            Image image = I.GetComponent<Image>();
            ItemIcon itemIcon = I.GetComponent<ItemIcon>();
            TextMeshProUGUI text = I.GetComponentInChildren<TextMeshProUGUI>();
            itemIcon.SetItem(item);
            if(item.amount > 1)
            {
            text.text = item.amount.ToString();
            }
            else
            {
                text.text = "";
            }
            image.sprite = item.GetSprite();
        }
    }
    public void DropBtn(Item item)
    {
        _Inventory.RemoveItem(item);
        ItemWorld.DropItem(item,player.transform.position);
    }
}
