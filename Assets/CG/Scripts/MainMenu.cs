using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string playerNameTextField = "Please enter your name";
    public int choice = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnGUI()
    {

        
        switch(choice)
        {
            case 0:
               if (GUI.Button(new Rect(100,100,200,50), "Start"))
               {
                      choice = 1;
               }
               if (GUI.Button(new Rect(100, 300, 200, 50), "Exit"))
               {
                      choice = 3;
                }
                break;
            case 1:

                
                
                playerNameTextField = GUI.TextArea(new Rect(100, 100, 175, 30), playerNameTextField, 23);
                if (GUI.Button(new Rect(100, 150, 50, 50), "Start") && playerNameTextField != "Please enter your name")
                {
                    choice = 2;
                }
               
                if (GUI.Button(new Rect(100, 220, 50, 50), "Back"))
                {
                    choice = 0;
                }
                break;
            case 2:

                Application.LoadLevel(1);

                break;
            case 3:

                Application.Quit();
                break;
        }

        
        



    }





}
