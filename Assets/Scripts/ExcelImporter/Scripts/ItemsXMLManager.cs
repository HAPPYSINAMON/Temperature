using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

namespace ItemXMLManager
{
    public class ItemsXMLManager : MonoBehaviour
    {
        public static ItemsXMLManager instance;

        public TextAsset itemFileXML;

        /// <summary>
        /// key : id, value : 캐릭터 구조체(CharParams)
        /// </summary>
        Dictionary<string, itemParams> dicCharacters = new Dictionary<string, itemParams>();

        struct itemParams
        {
            public int id;
            public string name;
            public int price;
            public int pricePow;
            public int upgradeAmount;
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
            characterXMLDoc.LoadXml(itemFileXML.text);

            XmlNodeList characterNodeList = characterXMLDoc.GetElementsByTagName("row");

            foreach (XmlNode characterNode in characterNodeList)
            {
                itemParams charactParams = new itemParams();

                foreach (XmlNode childNode in characterNode.ChildNodes)
                {
                    if (childNode.Name == "id")
                        charactParams.id = int.Parse(childNode.InnerText);
                    if (childNode.Name == "name")
                        charactParams.name = childNode.InnerText;
                    if (childNode.Name == "price")
                        charactParams.price = int.Parse(childNode.InnerText);
                    if (childNode.Name == "pricePow")
                        charactParams.pricePow = int.Parse(childNode.InnerText);
                    if (childNode.Name == "upgradeAmount")
                        charactParams.upgradeAmount = int.Parse(childNode.InnerText);
                }

                dicCharacters[charactParams.name] = charactParams;
            }
        }

        public void LoadCharacterParamsFromXML(string name, UpgradeParams charactParams)
        {
            charactParams.Price = dicCharacters[name].price;
            charactParams.pricePow = dicCharacters[name].pricePow;
            charactParams.UpgradeAmount = dicCharacters[name].upgradeAmount;

        }
    }
}