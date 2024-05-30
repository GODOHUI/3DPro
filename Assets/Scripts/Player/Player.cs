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
    //이벤트를 만들어야한다 이벤트 

    public void Eatting(IEnumerator co) 
    {
                  StartCoroutine(co); //여기서 코르틴이 돌아간다

    }
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PalyerController>();  
        condition = GetComponent<PlayerCondition>();
    }
}
