using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData")]
public class Item : ScriptableObject
{
    public int itemID; //아이템 ID
    public float itemPrice; //아이템 원가
    public string itemName; //아이템 이름
    public int itemMaxStack; //아이템 최대 수량
    public ItemType itemType; //아이템 타입
    public enum ItemType { Phone, Accessory, Case};  //아이템 타입 enum class
    public string itemDescription; //아이템 설명
    public Sprite itemIcon; //아이템 Icon
    public Texture itemTexture; //아이템 Texture
}