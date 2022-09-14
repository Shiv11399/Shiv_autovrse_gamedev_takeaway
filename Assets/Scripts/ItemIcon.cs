using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemIcon : MonoBehaviour
{
    public static UnityAction<Item> dropItem;
    private Item item;
    


    public void SetItem(Item item)
    {
        this.item = item;
    }
    public void IconPressed()
    {
        dropItem?.Invoke(item);
    }
}
