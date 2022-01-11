using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
   public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld

    public Sprite S_bow11Sprite;
    public Sprite S_Shadow05Sprite;
    public Sprite S_Sword05Sprite;
    public Sprite S_Water06Sprite;
    public Sprite W_Axe006Sprite;


}

