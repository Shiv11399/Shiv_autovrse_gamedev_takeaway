using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    [SerializeField] Item item;
    private void Start()
    {
        ItemWorld.SpawnItem(item, transform.position);
        Destroy(gameObject);
    }
}
