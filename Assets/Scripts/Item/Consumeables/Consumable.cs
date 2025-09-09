using UnityEngine;

public interface Consumable
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public void Use();
}
