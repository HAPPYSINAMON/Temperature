using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class CharacterXMLManager : MonoBehaviour
{
    public static CharacterXMLManager instance;

    public TextAsset characterFileXML;

    /// <summary>
    /// key : id, value : 캐릭터 구조체(CharParams)
    /// </summary>
    Dictionary<string, CharParams> dicCharacters = new Dictionary<string, CharParams>();

    struct CharParams
    {
        public int id;
        public string name;
        public int hp;
        public int mp;
        public int atk;
        public int def;
        public int intelligence;
        public int dex;
        public int resist_Hot;
        public int resis_Cold;
        public int attack_Range;
        public int attack_Speed;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        MakeMonsterXML();
    }

    void MakeMonsterXML()
    {
        XmlDocument characterXMLDoc = new XmlDocument();
        characterXMLDoc.LoadXml(characterFileXML.text);

        XmlNodeList characterNodeList = characterXMLDoc.GetElementsByTagName("row");

        foreach(XmlNode characterNode in characterNodeList)
        {
            CharParams charactParams = new CharParams();

            foreach(XmlNode childNode in characterNode.ChildNodes)
            {
                if (childNode.Name == "id")
                    charactParams.id = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "name")
                    charactParams.name = childNode.InnerText;
                if (childNode.Name == "hp")
                    charactParams.hp = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "mp")
                    charactParams.mp = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "atk")
                    charactParams.atk = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "def")
                    charactParams.def = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "intelligence")
                    charactParams.intelligence = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "dex")
                    charactParams.dex = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "resist_Hot")
                    charactParams.resist_Hot = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "resist_Cold")
                    charactParams.resis_Cold = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "attack_Range")
                    charactParams.attack_Range = Int32.Parse(childNode.InnerText);
                if (childNode.Name == "attack_Speed")
                    charactParams.attack_Speed = Int32.Parse(childNode.InnerText);
            }

            dicCharacters[charactParams.name] = charactParams;
        }
    }

    public void LoadCharacterParamsFromXML(string name, HeroA charactParams)
    {
        Debug.Log(dicCharacters.Keys);
        Debug.Log("hello");

        charactParams.MaxHP = dicCharacters[name].hp;
        charactParams.MaxMP = dicCharacters[name].mp;
        charactParams.Atk = dicCharacters[name].atk;
        charactParams.Def = dicCharacters[name].def;
        charactParams.Intelligence = dicCharacters[name].intelligence;
        charactParams.Dex = dicCharacters[name].dex;
        charactParams.Resist_Hot = dicCharacters[name].resist_Hot;
        charactParams.Resist_Cold = dicCharacters[name].resis_Cold;
        charactParams.Attack_Range = dicCharacters[name].attack_Range;
        charactParams.Attack_Speed = dicCharacters[name].attack_Speed;
    }    
}
