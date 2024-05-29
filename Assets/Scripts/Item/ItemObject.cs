using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IInteractable
{
    public string GetInteractPrompt();   // ȭ�鿡 ����� �Լ�
    public void OnInteract();     // �ȿ���� �߻����ٲ���
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        string dataName = $"{data.displayName}\n{data.description}";   //�̸��� ���� ��ȯ
        return dataName;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }

    
}
