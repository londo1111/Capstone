using System;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Items item;
    private object gameObject;

    public override void Interact()
    {
        base.Interact();

        ItemPickup();
    }

    private void ItemPickup()
    {
        throw new NotImplementedException();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }

    private void Destroy(object gameObject)
    {
        throw new NotImplementedException();
    }
}
