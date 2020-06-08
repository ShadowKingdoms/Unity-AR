using UnityEngine;
using System.Collections;
using Vuforia;


public class Planet : MonoBehaviour {


    public GameObject planet;
    public GameObject tracker;
    public Texture2D planet_button;
    public Texture2D pic1;
    public Texture2D pic2;
    public GUIStyle info;
    public GUIStyle pic_info;
    public GUIContent text;


    private int t_width=86;
    private int t_height=45;
    private int t_x = 725;
    private int t_y = 200;
    private Vector3 vec = new Vector3(0f, 0f, 0f);
    private bool gui;
    private bool showPlanetInfo;
    private bool bpic1;
    private bool bpic2;


    // Use this for initialization
    void Start () {
       
    }

    void OnGUI()
    {
        if (gui == true)
        {
            showPlanetInfo = GUI.Toggle(new Rect(1700, 50, 150, 150), showPlanetInfo, planet_button);
           
            if (showPlanetInfo == true)
            {
                GUI.Box(new Rect(70, 70, 410, 590), text, info);

                GUI.DrawTexture(new Rect(120, 810, 210, 200), pic1);
                bpic1 = GUI.Toggle(new Rect(100, 804, 250, 220), bpic1, "", pic_info);

                GUI.DrawTexture(new Rect(480, 810, 210, 200), pic2);
                bpic2 = GUI.Toggle(new Rect(460, 804, 250, 220), bpic2, "", pic_info);

                if (bpic2 == true)
                {
                    bpic1 = false;
                    GUI.DrawTexture(new Rect(768, 220, pic2.width / 2, pic2.width / 2), pic2);
                    bpic2 = GUI.Toggle(new Rect(t_x, t_y, pic2.width / 2 + t_width, pic2.height / 2 + t_height), bpic2, "", pic_info);
                }
                if (bpic1 == true)
                {
                    bpic2 = false;
                    GUI.DrawTexture(new Rect(768, 220, pic1.width / 2, pic1.height / 2), pic1);
                    bpic1 = GUI.Toggle(new Rect(t_x, t_y, pic1.width / 2 + t_width, pic1.height / 2 + t_height), bpic1, "", pic_info);
                }
            }
            else
            {
                bpic1 = false; bpic2 = false;
            }
        }
    }

    
    // Update is called once per frame
    void Update () {
        if (planet.GetComponent<Planet_Control>().activite_rotation == true && tracker.GetComponent<DefaultTrackableEventHandler>().targettracker == true)
        {
            transform.Rotate(0, 1, 0);
            gui = true; 
        }
        else if (tracker.GetComponent<DefaultTrackableEventHandler>().targettracker == false)
        {
            transform.eulerAngles = vec;
            gui = false;
            showPlanetInfo = false;
            bpic1 = false;
            bpic2 = false;
        }
       
      
	}
}
