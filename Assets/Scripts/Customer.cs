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
    public List<int> inventoryItemIDs = new List<int>();

    //�ֹ��� ������ID ����Ʈ
    public List<int> selectedItemIDs = new List<int>(); 

    //�����
    public Monitor monitor;

    private void Awake() {
        foreach (var item in inventory.items.Values) {
            //���� ���� ������ �ִ� �����ۿ��� �ֹ��ϱ�
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

    public void SetSelectedItemIDs() {
        //�κ��丮���� �ִ� 3���� ������ ������ ID�� �������� ����
        if (inventoryItemIDs.Count > 2) {
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
    }

    public void Order() {
        SetSelectedItemIDs();

        //�ֹ��� ������ ����Ʈ�� ���� �ֹ��ϱ�
        if (selectedItemIDs.Count > 0) {
            foreach (int itemID in selectedItemIDs) {
                //�ֹ��� ������ ����Ʈ�� ��������ϱ� ����Ϳ� �ֹ� ����Ʈ�� ��½�Ű��
                monitor.SetsaleItemIDs(selectedItemIDs);
                //����Ʈ�� �� �ϼ������ϱ� �˸� �޽����� ȭ�鿡 ����ϱ�
                Debug.Log($"itemID : {itemID}");
            }
        }
        else {
            Debug.Log("selectedItemIDs is zero");
        }
    }

    public void MakeReview() {
        //TODO: �ֹ� ���� ��۱��� �ɸ� �ð�, �ֹ� ��ǰ ��� ���� Ȯ���� �������� ���� �ۼ�
        //TODO: ���信 ���� �������� �ֹ� �� ����
    }
}
