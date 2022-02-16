using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    private GameObject slotStuff;

    private void Awake()
    {
        slotStuff = transform.Find("SlotStuff").gameObject;
        slotStuff.SetActive(false);
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            slotStuff.SetActive(!slotStuff.activeInHierarchy);
        }
    }
}
