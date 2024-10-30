using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverButton : Interactable 
{
    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");
    }
}
