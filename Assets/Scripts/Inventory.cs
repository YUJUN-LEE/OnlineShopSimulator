using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, InventoryItem> items; //¾ÆÀÌµð¶û item
    public int UIDCounter = 1;

    public Inventory() {
        items = new Dictionary<int, InventoryItem>();
    }

    public void TryAddItem(Item itemData, int itemAmount = 0) {
        if (itemData == null) {
            Debug.Log("itemData is null");
            return;
        }

        if (items.ContainsKey(itemData.itemID) && items[itemData.itemID].itemAmount < 64) {
            StackItem(itemData.itemID, itemAmount);
            Debug.Log($"itemData.itemID : {itemData.itemID} is Stacked, now itemAmount is : {items[itemData.itemID].itemAmount}");
        }
        else {
            AddedItem(itemData, itemAmount);
            Debug.Log($"new item added - itemID : {itemData.itemID}, itemAmount : {itemAmount}");
        }
    }

    public void StackItem(int itemID, int itemAmount = 0) {
        items[itemID].itemAmount += itemAmount;
    }

    public void AddedItem(Item itemData, int itemAmount = 0, int itemUID = 0) {
        items.Add(itemData.itemID, new InventoryItem(itemData, itemAmount, MakeUID()));
    }

    public int MakeUID() {
        return UIDCounter++;
    }

    public void ShowInventoryItems() {
        foreach (var eachItem in items) {
            Debug.Log($"itemID: {eachItem.Value.itemData.itemID}, itemAmount: {eachItem.Value.itemAmount}");
        }
    }
}
