using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{



    //this is an awful way of doing things and should be replaced by 
    //PlayerMovement sending out a started sliding event or something 
    //so that we don't have to link everything up
    //or check bools every tick instead of calling a function once (SUCKS)
    //but it works for getting the build in quickly.



    PlayerMovement pm;
    [SerializeField] Image speedlines;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.isSliding) {
            speedlines.enabled = true;
        } else {
            speedlines.enabled = false;
        }
    }
}
