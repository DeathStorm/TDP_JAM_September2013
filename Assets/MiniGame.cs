using UnityEngine;
using System.Collections;

public class MiniGame : MonoBehaviour {

    public Texture2D rahmen;
    public Texture2D balken;

    float curPos = 0;
    float curWidth = 10;

    public float movingSpeed = 15.0f;

    float barWidth = 500;
    float barHeight = 100;
    float ueberstand = 10;

    enum MovingDirection { Left, Right };

    MovingDirection curDirection = MovingDirection.Right;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        float maxBarWidth = barWidth - curWidth;

        if (curDirection == MovingDirection.Right)
        {
            curPos = Mathf.Clamp(curPos+ Time.deltaTime * movingSpeed,curPos,maxBarWidth);
        }
        else if (curDirection == MovingDirection.Left)
        {
            curPos = Mathf.Clamp(curPos - Time.deltaTime * movingSpeed, 0, curPos);
        }

        if (curPos == maxBarWidth) curDirection = MovingDirection.Left;
        else if (curPos == 0) curDirection = MovingDirection.Right;
	
	}



    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - barWidth / 2, Screen.height - barHeight * 2 - ueberstand, barWidth, barHeight + ueberstand * 2));
        GUI.DrawTexture(new Rect(0,ueberstand,barWidth,barHeight),rahmen,ScaleMode.StretchToFill);

        //GUI.Box(new Rect(0,ueberstand,barWidth,barHeight), "TEST");

        GUI.Box(new Rect(curPos, 0, curWidth, barHeight + ueberstand * 2), "");

           GUILayout.EndArea();

    }
}
