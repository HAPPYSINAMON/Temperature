using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    Player player;
    Player testPlayer;

    [SerializeField] Text CharacterStatText;

    private void Start()
    {
        player = new Player();
        player.Name = "A";
        player.HP = 100;
        player.MP = 100;
        player.Atk = 10;
        player.Def = 10;
        player.Intelligence = 10;
        player.Resist_Hot = 10;
        player.Resist_Cold = 10;
    }

    private void Update()
    {
        ShowCharacterStat();
    }

    void ShowCharacterStat()
    {

        CharacterStatText.text = "이름 : " + player.Name + "\n" +
                                 "HP : " + player.HP + "\n" +
                                 "MP : " + player.MP + "\n" +
                                 "ATK : " + player.Atk + "\n" +
                                 "Def : " + player.Def + "\n" +
                                 "Intelligence : " + player.Intelligence + "\n" +
                                 "ResistHot : " + player.Resist_Hot + "\n" +
                                 "ResistColde : " + player.Resist_Cold + "\n";
    }
}
