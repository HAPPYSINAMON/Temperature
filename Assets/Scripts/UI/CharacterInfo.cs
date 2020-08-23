using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] Character player;
    [SerializeField] GameObject infoPanel;
    [SerializeField] Text CharacterStatText;

    private void Start()
    {
        StartCoroutine(ShowCharacterInfo());
        infoPanel.SetActive(false);

        if (player == null)
            player = GameObject.Find("Player").GetComponent<Character>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            infoPanel.SetActive(false);
    }

    IEnumerator ShowCharacterInfo()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            CharacterStatText.text = "HP : " + player.CurrentHP + "\n" +
                     "MP : " + player.CurrentMP + "\n" +
                     "ATK : " + player.Atk + "\n" +
                     "Def : " + player.Def + "\n" +
                     "Intelligence : " + player.Intelligence + "\n" +
                     "ResistHot : " + player.Resist_Hot + "\n" +
                     "ResistColde : " + player.Resist_Cold + "\n";
        }
    }

    public void ShowInfo()
    {
        infoPanel.SetActive(true);
    }
}
