using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    private readonly List<string> items = new List<string>();

    public void AddItem(string item)
    {
        if (!string.IsNullOrEmpty(item))
        {
            items.Add(item);
            Debug.Log("Item añadido: " + item);
        }
    }

    public bool RemoveItem(string item)
    {
        return items.Remove(item);
    }

    public bool Contains(string item)
    {
        return items.Contains(item);
    }

    public List<string> GetItems()
    {
        return new List<string>(items);
    }
}
