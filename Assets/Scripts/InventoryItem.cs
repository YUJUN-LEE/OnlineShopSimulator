using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Item itemData; //scriptableobject 참조
    public int itemAmount; //인벤토리에 들어갈 아이템 수량
    public int itemUID; //인벤토리 UID

    public InventoryItem(Item itemData, int itemAmount, int itemUID) {
        this.itemData = itemData;
        this.itemAmount = itemAmount;
        this.itemUID = itemUID;
    }
}
