﻿using UnityEngine;
using Invector.CharacterController;
public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;

    public GameObject inventoryUI;
    [SerializeField]
    Inventory inventory;


    InventorySlot[] slots;
    public vThirdPersonController player;

    public Item firstItem;

    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;
        inventoryUI.SetActive(false);
        Debug.Log("Hello 2");

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventory.Add(firstItem);
        UpdateUI();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            player.enabled = !player.enabled;
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
	}


    public void UpdateUI()
    {
        
        
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
                //Debug.Log("Updating UI");
            }
        }
    }
}