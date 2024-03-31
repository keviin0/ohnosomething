using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemClass> items = new List<ItemClass>();

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public List<ItemClass> GetInventory()
    {
        return items;
    }

    public void AddBalloon()
    {
        Debug.Log("Adding Balloon");
        ItemClass item = ScriptableObject.CreateInstance<ItemClass>();
        item.itemName = "Balloons";
        item.sprite = Resources.Load<Sprite>("Assets/Art/SurgeryArt/balloons");
        items.Add(item);
    }

    public void AddFlags()
    {
        Debug.Log("Adding Flags");
        ItemClass item = ScriptableObject.CreateInstance<ItemClass>();
        item.itemName = "Flags";
        item.sprite = Resources.Load<Sprite>("Assets/Art/SurgeryArt/flags");
        items.Add(item);
    }

    public void AddBalls()
    {
        Debug.Log("Adding Balls");
        ItemClass item = ScriptableObject.CreateInstance<ItemClass>();
        item.itemName = "Balls";
        item.sprite = Resources.Load<Sprite>("Assets/Art/SurgeryArt/balls");
        items.Add(item);
    }
}
