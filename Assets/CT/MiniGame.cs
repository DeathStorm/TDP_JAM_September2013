using UnityEngine;
using System.Collections;

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

    public ERGEBNISSE ergebnis = ERGEBNISSE.KeinErgebnis;

    public enum ERGEBNISSE { KeinErgebnis, Schlecht, Normal, Super };

    enum MovingDirection { Left, Right };

    MovingDirection curDirection = MovingDirection.Right;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float maxBarWidth = barWidth - curWidth;

        if (Input.GetKeyDown(KeyCode.R)) { ergebnis = ERGEBNISSE.KeinErgebnis; }

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
        GUILayout.BeginArea(new Rect(Screen.width / 2 - barWidth / 2, Screen.height - barHeight * 2 - ueberstand, barWidth, barHeight + ueberstand * 2));
        GUI.DrawTexture(new Rect(0, ueberstand, barWidth, barHeight), rahmen, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(zielVon, ueberstand, zielBis-zielVon, barHeight), ziel, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(superVon, ueberstand, superBis-superVon, barHeight), super, ScaleMode.StretchToFill);

        GUI.DrawTexture(new Rect(curPos, 0, curWidth, barHeight + ueberstand * 2), balken, ScaleMode.StretchToFill);
        //GUI.Box(new Rect(0,ueberstand,barWidth,barHeight), "TEST");

        //GUI.Box(new Rect(curPos, 0, curWidth, barHeight + ueberstand * 2), "");

        GUILayout.EndArea();

    }
}