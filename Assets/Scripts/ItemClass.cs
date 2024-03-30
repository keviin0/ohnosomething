using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item Class", menuName = "Item")]
public class ItemClass : ScriptableObject 
{
    public string itemName;
    public Sprite sprite;

    public ItemClass GetItem() { return this; }
}
