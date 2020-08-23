using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UpgradeResistHot : UpgradeParams
{
    /// <summary>
    /// 아이템 정보
    /// </summary>
    public string Name { get; set; }
    public int level { get; set; }
    public int Price { get; set; }
    public int PricePow { get; set; }
    public int UpgradeAmount { get; set; }

    [SerializeField] Text text;
    [SerializeField] Character player;
    private void Awake()
    {
        Name = "더위 저항 강화";
        level = 0;
        Price = 30;
        PricePow = 2;
        UpgradeAmount = 10;

        UpdateUI();
    }

    private void Update()
    {
        StartCoroutine(CheckCankBuy());
    }

    IEnumerator CheckCankBuy()
    {
        yield return new WaitForSeconds(1f);
        oil = OilManager.InstanceOil.GetOil();
        CanBuy();
    }

    public bool CanBuy()
    {
        if (oil >= Price)
            return true;
        else
            return false;
    }

    public void BuyUpgrade()
    {
        if (CanBuy() == false)
        {
            Debug.Log("돈부족" + oil);
            return;
        }
        else
        {
            Debug.Log("업그레이드 완료.");
            player.SetResistHot(UpgradeAmount);
            OilManager.InstanceOil.SubOil(Price);
            level++;
            Price *= PricePow;

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        text.text = "이름 : " + Name + "\n" +
            "레벨 : " + level + "\n" +
            "가격 : " + Price + "\n" +
            "더위저항 : " + UpgradeAmount + "\n";
    }
}
