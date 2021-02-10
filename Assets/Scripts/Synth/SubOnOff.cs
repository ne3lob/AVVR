using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using extOSC;

public class SubOnOff : MonoBehaviour
{
    public OSCTransmitter transmitter;
    
    private const string oscAddressSubOnOff = "/vcoSecondOnOff";
    private OSCMessage messageSubOnOff;

    public AxisDragInteractable interactable;
    private Single one;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
      
    }
   
}
