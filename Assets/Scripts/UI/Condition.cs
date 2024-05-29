using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{

    public float curVal; //���簪 
    public float startval; //���۰�
    public float maxval; //�ִ밪
    public float passiveval; //�ֱ� ������ ���ϴ°� 
    public Image uibar;


    // Start is called before the first frame update
    void Start()
    {
        curVal = startval;
       
    }

    // Update is called once per frame
    void Update()
    {
      uibar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curVal/maxval;
    }
    public void Add(float value)
    {
        curVal = Mathf.Min(curVal+value ,maxval);
    }
    public void Subtract(float value)
    {
        curVal = Mathf.Max(curVal - value, 0);
    }
}
