using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Item itemData;
    bool isCheck;
    float playerMoney;
    float playerExp;
    int skillPoint;

    //public static GameManager Instance {
    //    get; private set;
    //}
    public static int inventoryItemMaxStack = 64;

    //public void Awake() {
    //    if (Instance == null) {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else {
    //        Destroy(gameObject);
    //    }
    //}

    public bool CheckInventory()
    {
        //TODO: 나중에 함수 이름 직관적으로 변경하기

        return isCheck;
    }
}
