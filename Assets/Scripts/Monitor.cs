using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : Interactable {
    //Canvas에 올라갈 판매 가능 아이템 ID들
    public List<int> saleItemIDs = new List<int>();

    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");

        //TODO: 모니터 UI 보여주기
    }

    public void SetsaleItemIDs(List<int> selectedItemIDs) {
        foreach (int item in selectedItemIDs) {
            if (!saleItemIDs.Contains(item)) {
                saleItemIDs.Add(item);
            }
        }

        //아이템들 정렬
        selectedItemIDs.Sort();
    }

    public void ShowItemPage() {
        //TODO: 보유중인 물품을 보여주고, 판매 가능하게 하기
    }

    public void CanSellButton() {
        //TODO: 판매 가능하게 하기 위한 버튼
    }

    public void ShowOrderPage() {
        //TODO: 주문 확인 page 보이기
    }

    public void ShowSkillPage() {
        //TODO: 스킬 page 보이기
    }

    public void ShowCalcPage() {
        //TODO: 정산 page 보이기
    }

}
