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
    public List<int> inventoryItemIDs = new List<int>();

    //주문할 아이템ID 리스트
    public List<int> selectedItemIDs = new List<int>(); 

    //모니터
    public Monitor monitor;

    private void Awake() {
        foreach (var item in inventory.items.Values) {
            //현재 내가 가지고 있는 아이템에서 주문하기
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

    public void SetSelectedItemIDs() {
        //인벤토리에서 최대 3개의 고유한 아이템 ID를 무작위로 선택
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

        //주문할 아이템 리스트를 보고 주문하기
        if (selectedItemIDs.Count > 0) {
            foreach (int itemID in selectedItemIDs) {
                //주문할 아이템 리스트는 만들었으니까 모니터에 주문 리스트를 출력시키기
                monitor.SetsaleItemIDs(selectedItemIDs);
                //리스트가 다 완성됬으니까 알림 메시지를 화면에 출력하기
                Debug.Log($"itemID : {itemID}");
            }
        }
        else {
            Debug.Log("selectedItemIDs is zero");
        }
    }

    public void MakeReview() {
        //TODO: 주문 이후 배송까지 걸린 시간, 주문 물품 배송 상태 확인을 기준으로 리뷰 작성
        //TODO: 리뷰에 따라 다음날의 주문 수 증감
    }
}
