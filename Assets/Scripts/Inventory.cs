using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, InventoryItem> items; //���̵�� item

    public Inventory() {
        items = new Dictionary<int, InventoryItem>();
    }

    //TODO: ���߿� json���Ϸ� ���� ������ �����ϸ� �ϴ� �ʱ�ȭ�� ���⼭ �ϴ°ɷ�
    //private void Awake() {
    //    items = new Dictionary<int, InventoryItem>();
    //}

    public void TryAddItem(Item itemData, int itemAmount = 0) {
        if (itemData != null) {
            if (items.ContainsKey(itemData.itemID)) {
                StackItem(itemData.itemID, itemAmount);
                Debug.Log($"itemData.itemID : {itemData.itemID} is Stacked");
                Debug.Log($"now itemAmount is : {itemAmount}");
            }
            else {
                AddedItem(itemData, itemAmount);
                Debug.Log($"new item is itemData.itemID : {itemData.itemID}, itemAmount is : {itemAmount}");
            }
        }
        else {
            Debug.Log("itemData is null");
        }
    }

    public void StackItem(int itemID, int itemAmount = 0) {
        items[itemID].itemAmount += itemAmount;
    }

    public void AddedItem(Item itemData, int itemAmount = 0) {
        items.Add(itemData.itemID, new InventoryItem(itemData, itemAmount));
    }

    public void ShowInventoryItems() {
        foreach (var eachItem in items) {
            Debug.Log($"itemID: {eachItem.Value.itemData.itemID}, itemAmount: {eachItem.Value.itemAmount}");
        }
    }
}
