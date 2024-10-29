using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Customer : MonoBehaviour
{
    [Header("Order")]
    public Inventory inventory; //���� ���� �������ִ� �ǸŹ�ǰ��
    public int minOrderAmount; //�ּ� �ֹ� ���� ����
    public int orderProbability; //�ֹ� Ȯ��
    public int randomOrderNum; //�ֹ��� ������ ����

    //�ֹ� ������ ������ID ����Ʈ
    private List<int> inventoryItemIDs = new List<int>();

    private void Awake() {
        foreach (var item in inventory.items.Values) {
            if (!inventoryItemIDs.Contains(item.itemData.itemID)) {
                inventoryItemIDs.Add(item.itemData.itemID);
            }
        }
    }

    private void Start() {
        StartCoroutine(OrderCoroutine());
    }

    public IEnumerator OrderCoroutine() {
        while (true) {
            //20�ʸ��� Ÿ�̸� ������
            yield return new WaitForSeconds(20f);

            //Ÿ�̸Ӵ� 1�� �ֹ� Ȯ���� ����ϸ� �ֹ�
            if (Random.Range(0, 100) < orderProbability) {
                Debug.Log("Order Success");
                Order();
            }
            else {
                Debug.Log("Order Fail");
            }
        }
    }

    public void Order() {
        List<int> selectedItemIDs = new List<int>(); //�ֹ��� ������ID ����Ʈ

        //�κ��丮���� �ִ� 3���� ������ ������ ID�� �������� ����
        if (inventoryItemIDs.Count > 0) {
            for (int i = 0 ; i < 3 ; i++) {
                int randomIndex = Random.Range(0, inventoryItemIDs.Count);
                int selectedID = inventoryItemIDs[randomIndex];
                if (!selectedItemIDs.Contains(selectedID)) {
                    selectedItemIDs.Add(selectedID);
                }
            }
        }
        else {
            selectedItemIDs.AddRange(inventoryItemIDs);
        }

        //������ ���缭 �ֹ��ϱ�
        if (selectedItemIDs.Count > 0) {
            foreach (int itemID in selectedItemIDs) {
                //InventoryItem item = inventory.items[itemID];
                //int orderAmount = Mathf.Clamp(
                //    Random.Range(minOrderAmount, item.itemData.itemMaxStack + 1),
                //    minOrderAmount,
                //    item.itemData.itemMaxStack
                //);
            }
        }
        else {
            Debug.Log("selectedItemIDs is zero");
        }
    }
}
