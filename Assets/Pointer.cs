using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject fingerTip;
    public GameObject fingerBase;

    public GameObject pointerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fingerTipPos = fingerTip.transform.position;
        Vector3 fingerBasePos = fingerBase.transform.position;

        Vector3 offset = (fingerTip.transform.position + new Vector3(0,0,1f));
        

        pointerObject.transform.position = offset;
    }
}
