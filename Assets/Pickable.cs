using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public bool isInInventory = false;
    public float maxRayLength = 10.0f;
    private InventoryManager inventoryManager;
    public ItemClass itemInstance; // Reference to the ItemClass ScriptableObject instance

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>(); // Find the InventoryManager in the scene
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform raycast and check length of ray
            if (Physics.Raycast(ray, out hit) && hit.distance <= maxRayLength)
            {
                isInInventory = true;
                if (inventoryManager != null && itemInstance != null)
                {
                    inventoryManager.AddToInventory(itemInstance);
                }
                else
                {
                    Debug.LogWarning("InventoryManager or itemInstance is null.");
                }
            }
        }
    }
}
