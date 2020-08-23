using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : MonoBehaviour
{
    [SerializeField] Text upgradeATKLevelText;
    [SerializeField] Text upgradeDefLevelText;

    [SerializeField] UpgradeATK upgradeATK;
    [SerializeField] UpgradeDef upgradeDef;

    private void Start()
    {
        StartCoroutine(UpdateUI());
    }

    IEnumerator UpdateUI()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            Init();
        }
    }

    void Init()
    {
        upgradeATKLevelText.text = upgradeATK.level.ToString();
        upgradeDefLevelText.text = upgradeDef.level.ToString();
    }
}
