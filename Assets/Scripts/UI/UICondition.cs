using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition Hp;
    public Condition Mp;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }

  //e버튼을 누르면 먹어지고  mphp차게 만든다
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        
    }
}
