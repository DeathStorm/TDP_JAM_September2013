using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameProperties : MonoBehaviour
{

    public string playerName;
    public int playerPoints = 0;
    public float money = 10.00f;
    public float dayTime = 90f;
    public int menuChoice = 0;

    // Items
    public Dictionary<string, Item> items = new Dictionary<string, Item>();
    //

    // Grafik Variablen
    public Texture2D logoMoney;
    public Texture2D logoTime;
    //
    public Texture2D wachs1;
    public Texture2D wachs2;
    public Texture2D wachs3;
    public Texture2D wachs4;
    public Texture2D wachs5;

    public Texture2D docht1;
    public Texture2D docht2;
    public Texture2D docht3;
    public Texture2D docht4;
    public Texture2D docht5;

    public ENUMS.WACHS gewaehlterWachs = ENUMS.WACHS.Anfängerwachs;
    public ENUMS.DOCHTE gewaehlterDocht = ENUMS.DOCHTE.Anfängerdocht;

    public MiniGame miniGame;

    // Methoden
    void Start()
    {

        playerName = PlayerPrefs.GetString("playerName");


        items.Add(ENUMS.WACHS.Anfängerwachs.ToString(), new Item(Item.ItemTypes.Wachs, 2f, 2.20f, 1f, 1f));
        items.Add(ENUMS.WACHS.Standardwachs.ToString(), new Item(Item.ItemTypes.Wachs, 4f, 4.40f, 2f, 2f));
        items.Add(ENUMS.WACHS.Guter_Wachs.ToString(), new Item(Item.ItemTypes.Wachs, 6f, 6.60f, 4f, 4f));
        items.Add(ENUMS.WACHS.Qualitätswachs.ToString(), new Item(Item.ItemTypes.Wachs, 8f, 8.80f, 6f, 6f));
        items.Add(ENUMS.WACHS.Premiumwachs.ToString(), new Item(Item.ItemTypes.Wachs, 10f, 11.0f, 8f, 8f));


        items.Add(ENUMS.DOCHTE.Anfängerdocht.ToString(), new Item(Item.ItemTypes.Docht, 2f, 2.20f, 1f, 1f));
        items.Add(ENUMS.DOCHTE.Standarddocht.ToString(), new Item(Item.ItemTypes.Docht, 4f, 4.40f, 2f, 2f));
        items.Add(ENUMS.DOCHTE.Guter_docht.ToString(), new Item(Item.ItemTypes.Docht, 6f, 6.60f, 4f, 4f));
        items.Add(ENUMS.DOCHTE.Qualitätsdocht.ToString(), new Item(Item.ItemTypes.Docht, 8f, 8.80f, 6f, 6f));
        items.Add(ENUMS.DOCHTE.Premiumdocht.ToString(), new Item(Item.ItemTypes.Docht, 10f, 11.0f, 8f, 8f));
    }

    void Update()
    {

       // miniGame.isGameActive = true;
        if (menuChoice < 2)
        {
            dayTime = Mathf.Clamp(dayTime - (1f * Time.deltaTime), 0, dayTime);


            if (dayTime <= 0)
            {
                menuChoice = 2;
                miniGame.isGameActive = false;
            }
        }

    }



    void OnGUI()
    {

        //
        HudInfo(10, 10, logoMoney,  money);
        HudInfo(10, 50, logoTime, dayTime);


        if (!miniGame.isGameActive)
        {
            GUI.Label(new Rect(100, 30, 200, 20), "Wachs = " + gewaehlterWachs.ToString());
            GUI.Label(new Rect(100, 50, 200, 20), "Docht = " + gewaehlterDocht.ToString());

            switch (menuChoice)
            {
                case 0:

                    if (GUI.Button(new Rect(100, 100, 32, 32), wachs1))
                    {
                        if (money >= items[ENUMS.WACHS.Anfängerwachs.ToString()].einkaufsPreis)
                        {
                            gewaehlterWachs = ENUMS.WACHS.Anfängerwachs;
                            
                        }
                    }
                    if (GUI.Button(new Rect(150, 100, 32, 32), wachs2))
                    {
                        if (money >= items[ENUMS.WACHS.Anfängerwachs.ToString()].einkaufsPreis)
                        {
                            gewaehlterWachs = ENUMS.WACHS.Standardwachs;

                        }
                    }

                    if (GUI.Button(new Rect(200, 100, 32, 32), wachs3))
                    {
                        if (money >= items[ENUMS.WACHS.Anfängerwachs.ToString()].einkaufsPreis)
                        {
                            gewaehlterWachs = ENUMS.WACHS.Guter_Wachs;

                        }
                    }

                    if (GUI.Button(new Rect(250, 100, 32, 32), wachs4))
                    {
                        if (money >= items[ENUMS.WACHS.Anfängerwachs.ToString()].einkaufsPreis)
                        {
                            gewaehlterWachs = ENUMS.WACHS.Qualitätswachs;

                        }
                    }

                    if (GUI.Button(new Rect(300, 100, 32, 32), wachs5))
                    {
                        if (money >= items[ENUMS.WACHS.Anfängerwachs.ToString()].einkaufsPreis)
                        {
                            gewaehlterWachs = ENUMS.WACHS.Premiumwachs;
                        }
                    }



                    if (GUI.Button(new Rect(100, 180, 32, 32), docht1))
                    {
                        if (money >= items[ENUMS.DOCHTE.Anfängerdocht.ToString()].einkaufsPreis)
                        {
                            gewaehlterDocht = ENUMS.DOCHTE.Anfängerdocht;

                        }
                    }
                    if (GUI.Button(new Rect(150, 180, 32, 32), docht2))
                    {
                        if (money >= items[ENUMS.DOCHTE.Standarddocht.ToString()].einkaufsPreis)
                        {
                            gewaehlterDocht = ENUMS.DOCHTE.Standarddocht;

                        }
                    }
                    if (GUI.Button(new Rect(200, 180, 32, 32), docht3))
                    {
                        if (money >= items[ENUMS.DOCHTE.Guter_docht.ToString()].einkaufsPreis)
                        {
                            gewaehlterDocht = ENUMS.DOCHTE.Guter_docht;

                        }
                    }
                    if (GUI.Button(new Rect(250, 180, 32, 32), docht4))
                    {
                        if (money >= items[ENUMS.DOCHTE.Qualitätsdocht.ToString()].einkaufsPreis)
                        {
                            gewaehlterDocht = ENUMS.DOCHTE.Qualitätsdocht;

                        }
                    }
                    if (GUI.Button(new Rect(300, 180, 32, 32), docht5))
                    {
                        if (money >= items[ENUMS.DOCHTE.Premiumdocht.ToString()].einkaufsPreis)
                        {
                            gewaehlterDocht = ENUMS.DOCHTE.Premiumdocht;
                        }
                    }

                    if (GUI.Button(new Rect(100, 250, 150, 30), "Start"))
                    {  
                        float gesamtPreis = (items[gewaehlterDocht.ToString()].einkaufsPreis +items[gewaehlterWachs.ToString()].einkaufsPreis);
                        if (money >= gesamtPreis)
                        {
                            money -= gesamtPreis;
                            menuChoice = 1;
                        }   
                    }
                    if (GUI.Button(new Rect(Screen.width - 30, Screen.height - 30, 30, 30), "X"))
                    {
                        menuChoice = 3;
                    }
                    break;
                case 1:
                    menuChoice = 0;
                    miniGame.isGameActive = true;

                    break;
                case 2:


                    GUI.Label(new Rect(100, 100, 50, 30), playerName);
                    GUI.Label(new Rect(100, 130, 50, 30), money.ToString());

                    if (GUI.Button(new Rect(100, 170, 100,30), "MainMenu"))
                    {
                        Application.LoadLevel(0);
                    }

                    break;
                case 3:

                    Application.Quit();
                    break;
            }
        }

    }


    // Methode zum schnellen erzeugen eines Icons mit Inhalt hinter
    public void HudInfo(int coorX, int coorY, Texture2D tex2D, string methString)
    {

        GUI.Box(new Rect(coorX, coorY, 32, 32), tex2D);
        GUI.Label(new Rect(coorX + 32, coorY + 2, 32, 32), methString);

    }

    public void HudInfo(int coorX, int coorY, Texture2D tex2D, int methInt)
    {

        GUI.Box(new Rect(coorX, coorY, 32, 32), tex2D);
        GUI.Label(new Rect(coorX + 32, coorY + 2, 32, 32), methInt.ToString());


    }

    public void HudInfo(int coorX, int coorY, Texture2D tex2D, float methFloat)
    {


        GUI.Box(new Rect(coorX, coorY, 32, 32), tex2D);
        GUI.Label(new Rect(coorX + 32, coorY + 2, 45, 32), string.Format("{0:f}",methFloat));//.ToString());

    }

}
