using ItemXMLManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeParams : MonoBehaviour
{
    /// <summary>
    /// 아이템 정보
    /// </summary>
    public string Name { get; set; }
    public int level = 1;
    public int Price { get; set; }
    public int pricePow { get; set; }
    public int UpgradeAmount { get; set; }

    int oil;

    private void Awake()
    {
        //InitParams();
    }

    private void Update()
    {
        oil = OilManager.Instance.GetOil();
        CanBuy();
    }

    //public abstract void InitParams();

    public bool CanBuy()
    {
        if (oil >= Price)
            return true;
        else
            return false;
    }
}
