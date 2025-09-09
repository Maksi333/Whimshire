using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> items; // List to hold the player's inventory items
    public InteractItem interact; // Reference to the Interact script to handle interactions
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        items = new List<Item>(); // Initialize the items list
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) // Check if the player presses the 'I' key
        {
            Debug.Log("itemCount" + items.Count); // Log the number of items in the inventory
            foreach (var item in items)
            {
                Debug.Log(item.itemData.itemName);
            }
        }

        if (interact != null && interact.WithInInterActionDistance && Input.GetKeyDown(KeyCode.E))
        {
            Item item = new Item(interact.GetComponent<ItemPickup>().itemData, 1); // Create a new item from the ItemPickup component
            AddItem(item.itemData, item.quantity); // Add the item to the inventory
            Destroy(interact.gameObject);
            Destroy(interact.interactableObjectCopy.gameObject); // Destroy the interactable object copy
        }

        if(Input.GetKeyDown(KeyCode.P)) // Check if the player presses the 'P' key
        {
            DropItem(); // Call the DropItem method to drop an item
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        interact = other.GetComponent<InteractItem>(); // Get the Interact component from the collided object
    }
    public void OnTriggerExit(Collider other)
    {
        interact = null;
    }

    public void AddItem(ItemData itemData, int quantity)
    {
        if (itemData.isStackable)
        {
            Item existing = items.Find(item => item.itemData == itemData);
            if(existing != null)
            {
                existing.quantity += quantity; // Increase the quantity if the item is stackable
                return;
            }
        }
        items.Add(new Item(itemData, quantity)); // Add a new item to the inventory
    }

    public void DropItem()
    {
        if(items.Count == 0) // Check if there are no items to drop
        {
            Debug.Log("No items to drop!"); // Log a message if the inventory is empty
            return;
        }
        else
        {
            ItemData itemtoDrop = items[0].itemData; // Get the first item in the inventory to drop
            GameObject itemPrefab = itemtoDrop.itemPrefab; // Get the prefab associated with the item
            Instantiate(itemPrefab, transform.position, Quaternion.identity); // Instantiate the item prefab at the player's position

            items.RemoveAt(0); // Remove the first item from the inventory
        }
    }
}
