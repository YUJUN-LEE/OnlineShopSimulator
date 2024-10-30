using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData")]
public class Item : ScriptableObject
{
    public int itemID; //������ ID
    public float itemPrice; //������ ����
    public string itemName; //������ �̸�
    public int itemMaxStack; //������ �ִ� ����
    public ItemType itemType; //������ Ÿ��
    public enum ItemType { Phone, Accessory, Case};  //������ Ÿ�� enum class
    public string itemDescription; //������ ����
    public Sprite itemIcon; //������ Icon
    public Texture itemTexture; //������ Texture
}