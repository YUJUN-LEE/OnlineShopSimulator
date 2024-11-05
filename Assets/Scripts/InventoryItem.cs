using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Item itemData; //scriptableobject ����
    public int itemAmount; //�κ��丮�� �� ������ ����
    public int itemUID; //�κ��丮 UID

    public InventoryItem(Item itemData, int itemAmount, int itemUID) {
        this.itemData = itemData;
        this.itemAmount = itemAmount;
        this.itemUID = itemUID;
    }
}
