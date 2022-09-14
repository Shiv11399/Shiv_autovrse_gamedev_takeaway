using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{

    public static ItemAssets instance;
    public static ItemAssets Instance { get => instance; private set => instance = value; }

    private void Awake()
    {
        Instance = this;
    }

    public GameObject BombPrefab;
    public GameObject ApplePrefab;
    public GameObject GunPrefab;
    public GameObject RiflePrefab;


    public Sprite GunSprite;
    public Sprite RifleSprite;
    public Sprite BombSprite;
    public Sprite AppleSprite;

}
