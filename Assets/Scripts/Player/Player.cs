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

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PalyerController>();  
        condition = GetComponent<PlayerCondition>();
    }
}
