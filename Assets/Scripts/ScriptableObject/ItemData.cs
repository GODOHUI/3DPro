using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resource,   //장착
    Equipable,  //섭취
    Consumable  //자원
}
public enum ConsumableType
{
    Hunger,
    Health
}
[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;  //타입
    public float value;    // 먹었을때의 값
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{

    public string displayName;//아이템 이름
    public string description; //아이템 설명
    public ItemType type;  // 타입
    public Sprite icon;  //이미지
    public GameObject dropPrefab;  //프리펩

    public bool canStack;  //여러개 가질수있는 
    public int maxStackAmount; //얼마나 가지고 있을수있는가

    public ItemDataConsumable[] consumables;

    public GameObject equipPrefab;
}
