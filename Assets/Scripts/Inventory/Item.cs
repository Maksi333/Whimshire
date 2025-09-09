using UnityEngine;

public class Item
{
    public ItemData itemData; // Reference to the item data
    public int quantity; // Quantity of the item in the inventory

    public Item(ItemData data, int qty)
    {
        itemData = data; // Assign the item data
        quantity = qty; // Assign the quantity
    }
}
