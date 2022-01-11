using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quarternion.identity);

       ItemWorld itemworld = transform.GetComponent<ItemWorld>();
        itemworld.SetItem(item);

        return ItemWorld;
    }
       
   
    private Item item;
    private SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item
        SpriteRenderer.sprite = item.GetSprite();
    }



}
