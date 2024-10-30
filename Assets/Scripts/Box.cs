using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Interactable 
{
    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");
    }
}
