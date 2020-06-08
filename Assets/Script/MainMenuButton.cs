using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void StartButton()
    {
        Application.LoadLevel("Ingame");
        Screen.SetResolution(1920, 1080, true);

    }

    void BackButton()
    {
        Application.LoadLevel("main2");
    }


    void ExitButton()
    {
        Application.Quit();
    }

}
