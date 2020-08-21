using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    /// <summary>
    /// 아이템 정보
    /// </summary>
    string upgradeName = "a";
    int level = 1;
    int price = 10;
    int pricePerLevel = 2;

    int oil;

    [SerializeField] Text text;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        oil = OilManager.Instance.GetOil();
        CanUpgrade();
    }

    public void BuyUpgrade()
    {
        if(CanUpgrade() == true)
        {
            Debug.Log("업그레이드 완료.");
            OilManager.Instance.SubOil(price);
            level++;
            price *= pricePerLevel;
            UpdateUI();
        } else
        {
            Debug.Log("자원이 부족합니다!" + oil);
            return;
        }
    }

    bool CanUpgrade()
    {
        if (oil >= price)
            return true;
        else
            return false;
    }

    void UpdateUI()
    {
        text.text = "아이템명 : " + upgradeName + "\n" +
            "레벨 : " + level + "\n" +
            "가격 : " + price;
    }
}
