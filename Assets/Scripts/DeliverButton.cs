using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverButton : Interactable 
{
    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");

        //TODO: 패키징 된 상품이 1개 이상 있으면 물품이 사라지고 배송 완료 판정
    }
}
