using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameProperties : MonoBehaviour {

    public string playerName;
    public int playerPoints = 0;
    public float money = 10.00f;
    public int day = 0;
    public float dayTime = 0f;
    public int menuChoice = 0;

    // Items
    Dictionary<string, Item> items = new Dictionary<string, Item>();
    public enum WACHS { Anfängerwachs, Standardwachs, Guter_Wachs, Qualitätswachs, Premiumwachs };
    public enum DOCHTE { Anfängerdocht, Standarddocht, Guter_docht, Qualitätsdocht, Premiumdocht };
    
    //
    public double buySumme = 0;


    // Grafik Variablen
    public Texture2D logoMoney;
    public Texture2D logoDay;
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

    // Methoden
    void Start()
    {

        playerName = PlayerPrefs.GetString("playerName");


        items.Add(WACHS.Anfängerwachs.ToString(), new Item(Item.ItemTypes.Wachs, 2f, 2.20f, 1f, 1f));
        items.Add(WACHS.Standardwachs.ToString(), new Item(Item.ItemTypes.Wachs, 4f, 4.40f, 2f, 2f));
        items.Add(WACHS.Guter_Wachs.ToString(), new Item(Item.ItemTypes.Wachs, 6f, 6.60f, 4f, 4f));
        items.Add(WACHS.Qualitätswachs.ToString(), new Item(Item.ItemTypes.Wachs, 8f, 8.80f, 6f, 6f));
        items.Add(WACHS.Premiumwachs.ToString(), new Item(Item.ItemTypes.Wachs, 10f, 11.0f, 8f, 8f));


        items.Add(DOCHTE.Anfängerdocht.ToString(), new Item(Item.ItemTypes.Docht, 2f, 2.20f, 1f, 1f));
        items.Add(DOCHTE.Standarddocht.ToString(), new Item(Item.ItemTypes.Docht, 4f, 4.40f, 2f, 2f));
        items.Add(DOCHTE.Guter_docht.ToString(), new Item(Item.ItemTypes.Docht, 6f, 6.60f, 4f, 4f));
        items.Add(DOCHTE.Qualitätsdocht.ToString(), new Item(Item.ItemTypes.Docht, 8f, 8.80f, 6f, 6f));
        items.Add(DOCHTE.Premiumdocht.ToString(), new Item(Item.ItemTypes.Docht, 10f, 11.0f, 8f, 8f));
    }

    void Update()
    {

        

    }



    void OnGUI()
    {
        HudInfo(10, 10, logoMoney, money);
        HudInfo(10, 50, logoDay, day);
        HudInfo(10, 90, logoTime, dayTime);

        //
    switch(menuChoice)
    {
        case 0:
            if(GUI.Button(new Rect(100,100,150,30), "Buy"))
            {
                buySumme = 0;
                menuChoice = 1;
            }
            if (GUI.Button(new Rect(100, 200, 150, 30), "Build"))
            {
                menuChoice = 2;
            }

            if (GUI.Button(new Rect(Screen.width-30, Screen.height-30, 30, 30), "X"))
            {
                menuChoice = 3;
            }
        break;
        case 1:


        BuyGrid(100, 100, wachs1, items[WACHS.Anfängerwachs.ToString()].einkaufsPreis);
        BuyGrid(100, 200, wachs2, items[WACHS.Standardwachs.ToString()].einkaufsPreis);
        //GUI.Box(new Rect(100, 100, 48, 48), wachs1);
       // GUI.Label(new Rect(160,100,80,30), items[WACHS.Anfängerwachs.ToString()].einkaufsPreis.ToString());
            
            
            
            
            
            if (GUI.Button(new Rect(Screen.width-150, 30, 100, 30), "Back"))
            {
                menuChoice = 0;
            }
        break;
        case 2:
        Application.LoadLevel(2);

        break;
        case 3:

            Application.Quit();
        break;
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
        GUI.Label(new Rect(coorX + 32, coorY + 2, 32, 32), methFloat.ToString()); 

    }


    public string thisAnzahl = "0";



    public void BuyGrid(int coorX, int coorY, Texture2D tex2D, float methFloat)
    {
        
        GUI.Box(new Rect(coorX, coorY, 48, 48), tex2D);
        GUI.Label(new Rect(coorX + 60, coorY + 6, 48, 48), methFloat.ToString());
        thisAnzahl = GUI.TextField(new Rect(coorX+100, coorY, 80, 48), thisAnzahl);

        double summe = Convert.ToDouble(thisAnzahl) * Convert.ToDouble(methFloat);
        buySumme += summe;
    }

}
