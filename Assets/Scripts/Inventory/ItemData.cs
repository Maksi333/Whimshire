using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public GameObject itemPrefab; // Prefab to instantiate when the item is used
    public bool isStackable; // Whether the item can be stacked in the inventory
}
