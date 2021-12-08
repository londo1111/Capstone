using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType
    {
       S_bow11,
       S_Shadow05,
       S_Sword05,
       S_Water06,
       W_Axe006,
    }

    public ItemType itemtype;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemtype)
        {
            default:
            case ItemType.S_bow11:      return ItemAssets.Instance.S_bow11Sprite;
            case ItemType.S_Shadow05:   return ItemAssets.Instance.S_Shadow05Sprite;
            case ItemType.S_Sword05:    return ItemAssets.Instance.S_Sword05Sprite;
            case ItemType.S_Water06:    return ItemAssets.Instance.S_Water06Sprite; 
            case ItemType.W_Axe006:     return ItemAssets.Instance.W_Axe006Sprite;
        }
    }
}
