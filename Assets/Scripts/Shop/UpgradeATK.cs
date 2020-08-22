using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeATK : UpgradeParams
{
    [SerializeField] Text text;

    private void Start()
    {
        Name = "atk";
        Price = 10;
        pricePow = 2;
        UpgradeAmount = 10;

        UpdateUI();
    }

    /// <summary>
    /// 에러나서 던짐
    /// </summary>
    /*
    public override void InitParams()
    {
        ItemsXMLManager.instance.LoadCharacterParamsFromXML(Name, this);
    }
    */

    public void Upgrade()
    {
        if (CanBuy() == true)
        {
            Debug.Log("업그레이드 완료.");
            Character.player.SetATK(UpgradeAmount);
            OilManager.Instance.SubOil(Price);
            level++;
            Price *= pricePow;

            UpdateUI();
        }
        else
        {
            Debug.Log("자원이 부족합니다!");
            return;
        }
    }

    void UpdateUI()
    {
        text.text = "이름 : " + Name + "\n" +
            "레벨 : " + level + "\n" +
            "가격 : " + Price + "\n" +
            "공격강화 : " + UpgradeAmount + "\n";
    }
}
