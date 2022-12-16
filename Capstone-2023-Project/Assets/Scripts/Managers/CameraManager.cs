using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    //TODO like in the ui class, the stuff going on w slide should be replaced with events 


    Vector3 origPos;
    [SerializeField] float lowerAmount = 3f;
    Vector3 lowPos;
    PlayerMovement pm;


    void Start()
    {
        //Screen.SetResolution(1920, 1080, true);


        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        origPos = transform.localPosition;
        lowPos = new Vector3(origPos.x, origPos.y - lowerAmount, origPos.z);
        Debug.Log(lowPos.y);
    }

    // Update is called once per frame
    void Update()
    {

        if(pm.isSliding) {
            transform.localPosition = lowPos;
        } else {
            transform.localPosition = origPos;
        }
    }


}
