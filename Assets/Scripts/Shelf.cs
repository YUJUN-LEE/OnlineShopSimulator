using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : Interactable 
{
    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");
    }
}
