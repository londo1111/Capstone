using UnityEngine;

public class ItemPickup : Interactable
{
    void PickUp ()
    {
        Debug.Log("Picking up item.");
        // Add to inventory
        Destroy(gameObject);
    }

}
