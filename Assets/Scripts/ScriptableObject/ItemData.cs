using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resource,   //����
    Equipable,  //����
    Consumable  //�ڿ�
}
public enum ConsumableType
{
    Hunger,
    Health
}
[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;  //Ÿ��
    public float value;    // �Ծ������� ��
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{

    public string displayName;//������ �̸�
    public string description; //������ ����
    public ItemType type;  // Ÿ��
    public Sprite icon;  //�̹���
    public GameObject dropPrefab;  //������

    public bool canStack;  //������ �������ִ� 
    public int maxStackAmount; //�󸶳� ������ �������ִ°�

    public ItemDataConsumable[] consumables;

    public GameObject equipPrefab;
}
