using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : Interactable 
{
    
    public Vector3 Place1;
    public Vector3 Place2;
    public Vector3 Place3;
    public Vector3 Place4;
    public Vector3 Place5;
    public Vector3 Place6;
    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");
    }
    public void ShelfUpdate()
    {
        
    }
}
