using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Player : MonoBehaviour
{
    public PalyerController controller;
   public PlayerCondition condition;
    public ItemData itemData;
    public Action addItem;
    //�̺�Ʈ�� �������Ѵ� �̺�Ʈ 

    public void Eatting(IEnumerator co) 
    {
                  StartCoroutine(co); //���⼭ �ڸ�ƾ�� ���ư���

    }
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PalyerController>();  
        condition = GetComponent<PlayerCondition>();
    }
}
