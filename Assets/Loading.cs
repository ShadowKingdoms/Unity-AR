using UnityEngine;
using System.Collections;
using Vuforia;

public class Loading : MonoBehaviour {

    private DefaultTrackableEventHandler tracker;
    public GameObject[] imagetarget;
    public GameObject loading;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject target in imagetarget)
        {
            tracker = target.GetComponent<DefaultTrackableEventHandler>();
            if (tracker.targettracker)
            {
                loading.SetActive(false);
                break;
            } 
                loading.SetActive(true);
        }
    }

    


}
