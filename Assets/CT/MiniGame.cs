using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MiniGame : MonoBehaviour
{

    public Texture2D rahmen;
    public Texture2D balken;
    public Texture2D ziel;
    public Texture2D super;

    float curPos = 0;
    float curWidth = 10;

    public float movingSpeed = 100.0f;

    float barWidth = 500;
    float barHeight = 100;
    float ueberstand = 10;

    float zielVon = 100.0f;
    float zielBis = 350.0f;

    float superVon = 150.0f;
    float superBis = 200.0f;

    public enum WACHS {Anfängerwachs, Standardwachs,Guter_Wachs, Qualitätswachs, Premiumwachs};
    public enum DOCHTE { Anfängerdocht, Standarddocht, Guter_docht, Qualitätsdocht, Premiumdocht};

    public WACHS gewaehlterWachs = WACHS.Anfängerwachs;
    public DOCHTE gewaehlterDocht = DOCHTE.Anfängerdocht;



    public ERGEBNISSE ergebnis = ERGEBNISSE.KeinErgebnis;

    public enum ERGEBNISSE { KeinErgebnis, Schlecht, Normal, Super };

    enum MovingDirection { Left, Right };

    MovingDirection curDirection = MovingDirection.Right;

    Dictionary<string, Item> items = new Dictionary<string, Item>();

    float einkommen = 0;

    // Use this for initialization
    void Start()
    {

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

        movingSpeed = 200.0f * (items[gewaehlterDocht.ToString()].schwierigkeit + items[gewaehlterWachs.ToString()].schwierigkeit);


    }

    // Update is called once per frame
    void Update()
    {

        float maxBarWidth = barWidth - curWidth;

        if (Input.GetKeyDown(KeyCode.R)) { ergebnis = ERGEBNISSE.KeinErgebnis; einkommen = 0; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (curPos >= superVon && curPos <= superBis)
            {
                ergebnis = ERGEBNISSE.Super; 
            }
            else if (curPos >= zielVon && curPos <= zielBis)
            {
                ergebnis = ERGEBNISSE.Normal;
            }
            else
            {
                ergebnis = ERGEBNISSE.Schlecht;
            }
            CalcErgebnis();
        }
        else if (ergebnis == ERGEBNISSE.KeinErgebnis)
        {

            if (curDirection == MovingDirection.Right)
            {
                curPos = Mathf.Clamp(curPos + Time.deltaTime * movingSpeed, curPos, maxBarWidth);
            }
            else if (curDirection == MovingDirection.Left)
            {
                curPos = Mathf.Clamp(curPos - Time.deltaTime * movingSpeed, 0, curPos);
            }

            if (curPos == maxBarWidth) curDirection = MovingDirection.Left;
            else if (curPos == 0) curDirection = MovingDirection.Right;
        }
    }



    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 200, 20), "Wachs = " +gewaehlterDocht.ToString());
        GUI.Label(new Rect(100, 150, 200, 20), "Docht = " + gewaehlterWachs.ToString());


        GUILayout.BeginArea(new Rect(Screen.width / 2 - barWidth / 2, Screen.height - barHeight * 2 - ueberstand, barWidth, barHeight + ueberstand * 2));
        GUI.DrawTexture(new Rect(0, ueberstand, barWidth, barHeight), rahmen, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(zielVon, ueberstand, zielBis-zielVon, barHeight), ziel, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(superVon, ueberstand, superBis-superVon, barHeight), super, ScaleMode.StretchToFill);

        GUI.DrawTexture(new Rect(curPos, 0, curWidth, barHeight + ueberstand * 2), balken, ScaleMode.StretchToFill);
        //GUI.Box(new Rect(0,ueberstand,barWidth,barHeight), "TEST");

        //GUI.Box(new Rect(curPos, 0, curWidth, barHeight + ueberstand * 2), "");

        GUILayout.EndArea();

        if (ergebnis != ERGEBNISSE.KeinErgebnis)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 2 - 100 / 2, 200, 100));
                
            GUI.Label(new Rect(0,0,200,25),"Kerze fertig");
            GUI.Label(new Rect(0,25,200,25),ergebnis.ToString()+" Ergebnis");
            GUI.Label(new Rect(0,50,200,25),"Kerze fertig");
            GUI.Label(new Rect(0,75,200,25),einkommen+" €");

                GUILayout.EndArea();
        }

    }

    void CalcErgebnis()
    {
        einkommen = items[gewaehlterWachs.ToString()].verkaufsPreis + items[gewaehlterDocht.ToString()].verkaufsPreis;
        if (ergebnis == ERGEBNISSE.Schlecht)
        {
            einkommen *= 0.75f;
        }
        else if (ergebnis == ERGEBNISSE.Super)
        {
            einkommen *= 1.25f;
        }


    }
}
