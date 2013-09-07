using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameProperties : MonoBehaviour {

    public string playerName;
    public int playerPoints = 0;
    public float money = 10.00f;
    public int day = 0;
    public float dayTime = 0f;
    public Dictionary<string, float> inventar = new Dictionary<string, float>();

    public int menuChoice = 0;

    // Grafik Variablen
    public Texture2D logoMoney;
    public Texture2D logoDay;
    public Texture2D logoTime;



    void start()
    {

        playerName = PlayerPrefs.GetString("playerName");
    
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
}
