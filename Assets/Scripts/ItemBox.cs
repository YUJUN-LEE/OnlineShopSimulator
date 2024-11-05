using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Interactable 
{
    // 아이템 시각화용

    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");

        //TODO: 아이템 박스를 들고 내리기
    }
}
