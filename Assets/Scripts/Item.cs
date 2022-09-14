using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    public enum ItemType
    {
        Pistol = 0,
        Apple = 1,
        Bomb = 2,
        Rifle = 3,
    }
    public ItemType itemType;
    public int amount;


    public Item(ItemType type, int amount)
    {
        itemType = type;
        this.amount = amount;
    }
    public Sprite GetSprite()
    {
        Debug.Log(itemType);
        switch (itemType)
        {
            default:
            case ItemType.Apple: return ItemAssets.Instance.AppleSprite;
            case ItemType.Bomb: return ItemAssets.Instance.BombSprite;
            case ItemType.Pistol: return ItemAssets.Instance.GunSprite;
            case ItemType.Rifle: return ItemAssets.Instance.RifleSprite;

        }
    }
    public bool IsStackable()// check if the item is stackable...
    {
        switch (itemType)
        {
            default:
            case ItemType.Apple:
            case ItemType.Bomb:
                return true;
            case ItemType.Pistol:
            case ItemType.Rifle:
                return false;

        }
    }
    public bool IsUniquePickUp()// check if the item is unique pickup...
    {
        switch (itemType)
        {
            default:
            case ItemType.Apple:
            case ItemType.Bomb:
                return false;
            case ItemType.Pistol:
            case ItemType.Rifle:
                return true;

        }
    }
}
