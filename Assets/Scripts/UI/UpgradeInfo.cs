using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : MonoBehaviour
{
    [SerializeField] Text upgradeResistHotLevelText;
    [SerializeField] Text upgradeResitColdLevelText;
    [SerializeField] Text upgradeATKLevelText;
    [SerializeField] Text upgradeDefLevelText;

    [SerializeField] UpgradeResistHot upgradeResistHot;
    [SerializeField] UpgradeResistCold upgradeResistCold;
    [SerializeField] UpgradeATK upgradeATK;
    [SerializeField] UpgradeDef upgradeDef;

    private void Start()
    {
        if (upgradeResistHot == null)
            upgradeResistHotLevelText.text = "1";
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
        upgradeResistHotLevelText.text = upgradeResistHot.level.ToString();
        upgradeResitColdLevelText.text = upgradeResistCold.level.ToString();
        upgradeATKLevelText.text = upgradeATK.level.ToString();
        upgradeDefLevelText.text = upgradeDef.level.ToString();
    }
}
