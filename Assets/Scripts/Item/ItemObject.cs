using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
public interface IInteractable
{
    public string GetInteractPrompt();   // 화면에 띄워줄 함수
    public void OnInteract();     // 어떤효과를 발생해줄껀지
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;


    public string GetInteractPrompt()
    {
        string dataName = $"{data.displayName}\n{data.description}";   //이름과 설명 반환
        return dataName;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();

        //EatHP();
        EatHeal();
        Destroy(gameObject);
    }
    IEnumerator coEat(float amount)
    {
        float time = 0;
        while (time <= 3)
        {
            time += Time.deltaTime;
            CharacterManager.Instance.Player.condition.Heal(amount * Time.deltaTime *1/3);
            yield return null;

        }
    }
    //consumables 배열에있는걸 다 적용시켜야한다
    public void EatHeal()
    {
        for (int i = 0; i < data.consumables.Length; i++)
        {
            Debug.Log("for");
            switch (data.consumables[i].type)
            {
                case ConsumableType.HP:
                    Debug.Log("Hp");
                  //  CharacterManager.Instance.Player.condition.Heal(data.consumables[i].value);
                    CharacterManager.Instance.Player.Eatting(coEat(data.consumables[i].value));
                    break;
                case ConsumableType.MP:
                    Debug.Log("Mp");
                    //CharacterManager.Instance.Player.condition.Eat(data.consumables[i].value);
                    CharacterManager.Instance.Player.Eatting(coEat(data.consumables[i].value));
                    break;

                default:
                    break;
            }
        }
    }


}
