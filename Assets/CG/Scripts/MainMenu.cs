using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnGUI()
    {

        if (GUI.Button(new Rect(100,100,200,50), "Start"))
        {

            Application.LoadLevel(1);

        }

        if (GUI.Button(new Rect(100, 300, 200, 50), "Exit"))
        {

            Application.Quit();
        
        }


    }





}
