using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    Character player;

    [SerializeField] Text CharacterStatText;

    private void Start()
    {
        player = Character.player;
    }

    private void Update()
    {
        ShowCharacterStat();
    }

    void ShowCharacterStat()
    {

        CharacterStatText.text = "HP : " + player.CurrentHP + "\n" +
                                 "MP : " + player.CurrentMP + "\n" +
                                 "ATK : " + player.Atk + "\n" +
                                 "Def : " + player.Def + "\n" +
                                 "Intelligence : " + player.Intelligence + "\n" +
                                 "ResistHot : " + player.Resist_Hot + "\n" +
                                 "ResistColde : " + player.Resist_Cold + "\n";
    }
}
