using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Item itemData; //scriptableobject ����
    public int itemAmount; //�κ��丮�� �� ������ ����

    public InventoryItem(Item itemData, int itemAmount) {
        this.itemData = itemData;
        this.itemAmount = itemAmount;
    }
}
