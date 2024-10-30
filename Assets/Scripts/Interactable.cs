using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactableName; //사물 이름
    public abstract void Interact(); //상호작용 함수
}
