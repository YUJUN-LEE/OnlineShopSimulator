using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactableName; //�繰 �̸�
    public abstract void Interact(); //��ȣ�ۿ� �Լ�
}
