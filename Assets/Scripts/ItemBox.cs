using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData")]
public class Item : ScriptableObject
{
    public int itemID;
    public float itemPrice;
    public string itemName;
    public int itemMaxStack;
    public ItemType itemType;
    public enum ItemType { Phone, Accessory, Case};
    public string itemDescription;
    public Sprite itemIcon;
    public Texture itemTexture;
}