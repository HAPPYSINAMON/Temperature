using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] Character player;
    [SerializeField] GameObject infoPanel;
    [SerializeField] Text CharacterStatText;

    int hp;
    int mp;
    int atk;
    int def;

    private void Start()
    {
        infoPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            infoPanel.SetActive(false);

        hp = player.CurrentHP;
        mp = player.CurrentMP;
        atk = player.Atk;
        def = player.Def;

        CharacterStatText.text = "HP : " + hp + "\n" +
                         "MP : " + mp + "\n" +
                         "ATK : " + atk + "\n" +
                         "Def : " + def + "\n";
    }

    public void Show()
    {
        infoPanel.SetActive(true);
    }
}
