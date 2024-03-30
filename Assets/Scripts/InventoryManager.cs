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
}
