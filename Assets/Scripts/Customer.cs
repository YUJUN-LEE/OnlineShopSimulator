using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Customer : MonoBehaviour
{
    [Header("Order")]
    public Inventory inventory; //내가 현재 가지고있는 판매물품들
    public int minOrderAmount; //최소 주문 가능 수량
    public int orderProbability; //주문 확률
    public int randomOrderNum; //주문할 아이템 수량

    //주문 가능한 아이템ID 리스트
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
            //20초마다 타이머 돌리기
            yield return new WaitForSeconds(20f);

            //타이머당 1번 주문 확률을 통과하면 주문
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
        List<int> selectedItemIDs = new List<int>(); //주문할 아이템ID 리스트

        //인벤토리에서 최대 3개의 고유한 아이템 ID를 무작위로 선택
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

        //수량에 맞춰서 주문하기
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
