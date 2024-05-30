using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{

    public UICondition uiCondition;
    Condition Hp { get { return uiCondition.Hp; } }
    Condition Mp { get { return uiCondition.Mp; } }
   

    // Update is called once per frame
    void Update()
    {
        Hp.Subtract(Hp.passiveval * Time.deltaTime);
        Mp.Add(Mp.passiveval * Time.deltaTime);

        if (Hp.curVal== 0f)
        {
            die();
        }
    }

    public void Heal(float amout)
    {
        Hp.Add(amout);
    }
    public void Eat(float amout)
    {
        Mp.Add(amout);
    }
    public void die()
    {
        Debug.Log("ав╬З╢ы");
    }
}
