using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageBox : Interactable 
{
    // 배송할 상품 리스트 (ID, 가격)

    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");

        //TODO: 패키지 박스를 들고 내리기
    }
}
