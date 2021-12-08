using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType
    {
       Square,
       Circle,
       Triangle,
       Oval,
       Trapezoid,
    }

    public ItemType itemtype;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemtype)
        {
            default:
            case ItemType.Square:       return ItemAssets.Instance.squareSprite;
            case ItemType.Circle:       return ItemAssets.Instance.circleSprite;
            case ItemType.Triangle:     return ItemAssets.Instance.triangleSprite;
            case ItemType.Oval:         return ItemAssets.Instance.ovalSprite;
            case ItemType.Trapezoid:    return ItemAssets.Instance.trapezoidSprite;
        }
    }
}
