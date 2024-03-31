using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public List<ItemClass> items = new List<ItemClass>();

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public List<ItemClass> GetInventory()
    {
        return items;
    }

    public void AddToInventory(ItemClass itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveFromInventory(ItemClass itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
    }
}
