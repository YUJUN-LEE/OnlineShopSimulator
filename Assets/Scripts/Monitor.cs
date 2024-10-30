using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : Interactable {
    //Canvas�� �ö� �Ǹ� ���� ������ ID��
    public List<int> saleItemIDs = new List<int>();

    public override void Interact() {
        Debug.Log($"{interactableName} is interacted");

        //TODO: ����� UI �����ֱ�
    }

    public void SetsaleItemIDs(List<int> selectedItemIDs) {
        foreach (int item in selectedItemIDs) {
            if (!saleItemIDs.Contains(item)) {
                saleItemIDs.Add(item);
            }
        }

        //�����۵� ����
        selectedItemIDs.Sort();
    }

    public void ShowItemPage() {
        //TODO: �������� ��ǰ�� �����ְ�, �Ǹ� �����ϰ� �ϱ�
    }

    public void CanSellButton() {
        //TODO: �Ǹ� �����ϰ� �ϱ� ���� ��ư
    }

    public void ShowOrderPage() {
        //TODO: �ֹ� Ȯ�� page ���̱�
    }

    public void ShowSkillPage() {
        //TODO: ��ų page ���̱�
    }

    public void ShowCalcPage() {
        //TODO: ���� page ���̱�
    }

}
