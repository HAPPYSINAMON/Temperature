using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    bool canBuy = false;
    int price;
    /// <summary>
    /// 플레이어가 보유한 코인 : 임시
    /// </summary>
    int coin;

    private void Start()
    {
        coin = 100;
        price = 10;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (coin < price)
            {
                Debug.Log("You can't buy! Plz get the coin!");
                return;
            }

            Buy();
        }

    }

    public void Buy()
    {
        coin -= price;
        Debug.Log("Buy Item!");
    }
}
