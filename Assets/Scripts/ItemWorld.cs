using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    [SerializeField]private Item item;
    [SerializeField]private bool AutoRotate = true;

    public static ItemWorld SpawnItem(Item item, Vector3 pos)
    {
        GameObject newItem;
        switch (item.itemType)
        {
            case Item.ItemType.Apple:
                newItem = Instantiate(ItemAssets.Instance.ApplePrefab, pos, Quaternion.identity);
                break;
            case Item.ItemType.Bomb:
                newItem = Instantiate(ItemAssets.Instance.BombPrefab, pos, Quaternion.identity);
                break;
            case Item.ItemType.Pistol:
                newItem = Instantiate(ItemAssets.Instance.GunPrefab, pos, Quaternion.identity);
                break;
            case Item.ItemType.Rifle:
                newItem = Instantiate(ItemAssets.Instance.RiflePrefab, pos, Quaternion.identity);
                break;
            default:
                newItem = null;
                break;
        }
        ItemWorld itemWorld = newItem.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
    public void SetItem(Item item)
    {
        this.item = item;
    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        var euler = transform.rotation;
        if (AutoRotate)
        {
            transform.Rotate(new Vector3(euler.x, euler.y + Time.deltaTime*100, euler.z));
        }
    }
    internal static void DropItem(Item item, Vector3 position)
    {
        float varX = UnityEngine.Random.Range(1, 3);
        float varZ = UnityEngine.Random.Range(1, 3);
        var dropPos = new Vector3(position.x + varX, position.y, position.z + varZ);
        ItemWorld itemWorld = SpawnItem(item, dropPos);

    }
}
