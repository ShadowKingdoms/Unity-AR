using UnityEngine;
using System.Collections;
using Vuforia;

public class Planet_Control : MonoBehaviour {

    float x = 0.0f;
    float y = 0.0f;

    float scaleFactor = 0.05f;
  //  float minScale = 0.6f;
  //  float maxScale = 2.0f;

    private Vector3 localscale_vec;
    Quaternion eulerRotation;
    public bool activite_rotation;
    public GameObject tracker;
    
    // Use this for initialization
    void Start () {
        activite_rotation = true;
        eulerRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        localscale_vec = transform.localScale;
    }

    



    // Update is called once per frame
    void Update () {

       
    
        if (Input.touchCount == 1)  // Drag

        {

            if (Input.GetTouch(0).phase == TouchPhase.Moved)

            {

                activite_rotation = false;

                x = Input.GetTouch(0).position.x - Input.GetTouch(0).deltaPosition.x;

                y = Input.GetTouch(0).position.y - Input.GetTouch(0).deltaPosition.y;

                eulerRotation = Quaternion.Euler(new Vector3(y, 0f, x));

                transform.rotation = eulerRotation;

            }

        }


        else if (Input.touchCount > 1 && Input.touchCount <= 2) // Zoom
        {

            activite_rotation = false;
            
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = (touchDeltaMag - prevTouchDeltaMag) * Time.deltaTime;

            gameObject.transform.localScale += new Vector3(deltaMagnitudeDiff * scaleFactor, deltaMagnitudeDiff * scaleFactor, deltaMagnitudeDiff * scaleFactor) * Time.deltaTime;
              /*  float parentX, parentY, parentZ;

               parentX = Mathf.Clamp(gameObject.transform.localScale.x, maxScale, minScale);
                parentY = Mathf.Clamp(gameObject.transform.localScale.y, maxScale, minScale);
                parentZ = Mathf.Clamp(gameObject.transform.localScale.x, maxScale, minScale);

                gameObject.transform.localScale = new Vector3(parentX, parentY, parentZ);*/
       }
       

       else
       {
            activite_rotation = true;
            if (tracker.GetComponent<DefaultTrackableEventHandler>().targettracker == false)
            {          
                transform.localScale = localscale_vec;
            }
        }



    }

}
