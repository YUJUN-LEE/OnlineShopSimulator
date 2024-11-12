using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, InventoryItem> items; //���̵�� item
    public int UIDCounter = 0;
    
    int inventoryItemMaxStack = GameManager.inventoryItemMaxStack;

    public Inventory() {
        items = new Dictionary<int, InventoryItem>();
    }

    public void TryAddItem(Item itemData, int itemAmount = 0) {
        if (itemData == null) {
            Debug.Log("itemData is null");
            return;
        }

        if (items.ContainsKey(itemData.itemID)) { //�ش��ϴ� �������� �̹� �����ϰ� ����
            if (items[itemData.itemID].itemAmount + itemAmount <= inventoryItemMaxStack) { //�������� �߰��� �� 64���� �ȵ�
                StackItem(itemData.itemID, itemAmount);
                Debug.Log($"itemData.itemID : {itemData.itemID} is Stacked, now itemAmount is : {items[itemData.itemID].itemAmount}");
            }
            else {
                int batchAmount = items[itemData.itemID].itemAmount + itemAmount;
                AddItemInBatch(itemData, batchAmount);
            }
        }
        else {
            if (itemAmount <= inventoryItemMaxStack) { //�߰��Ϸ��� �������� ���� 64���� �ȵ�
                AddedItem(itemData, itemAmount);
                Debug.Log($"new item added - itemID : {itemData.itemID}, itemAmount : {itemAmount}");
            }
            else {
                int batchAmount = items[itemData.itemID].itemAmount + itemAmount;
                AddItemInBatch(itemData, batchAmount);
            }
        }
    }

    public void StackItem(int itemID, int itemAmount = 0) {
        items[itemID].itemAmount += itemAmount;
    }

    public void AddedItem(Item itemData, int itemAmount = 0, int itemUID = 0) {
        items.Add(itemData.itemID, new InventoryItem(itemData, itemAmount, MakeUID()));
    }

    public void AddItemInBatch(Item itemData, int batchAmount) {
        while (batchAmount > 0) {
            int amountToAdd = Mathf.Min(batchAmount, inventoryItemMaxStack);

            if (items.ContainsKey(itemData.itemID) && items[itemData.itemID].itemAmount <= inventoryItemMaxStack) {
                StackItem(itemData.itemID, amountToAdd);
            }
            else {
                AddedItem(itemData, amountToAdd);
            }

            batchAmount -= inventoryItemMaxStack;
            Debug.Log($"itemData.itemID : {itemData.itemID} is Stacked, remain itemAmount is : {batchAmount}");
        }
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
