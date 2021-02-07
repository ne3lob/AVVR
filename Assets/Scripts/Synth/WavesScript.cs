using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using extOSC;


public class WavesScript : MonoBehaviour
{
    [Header("OSC Settings")] public OSCReceiver receiver;
    public OSCTransmitter transmitter;
    public XRExclusiveSocketInteractor socketInteractor;
    
    private const string oscAddressSynthWaveVCO = "/vcoWave";
    
    // Start is called before the first frame update
    void Start()
    {
  
    }
    // Update is called once per frame
    void Update()
    {
    }
    //OFF
    public void SocketOFF(XRBaseInteractable interactable)
    {
        var messageOff= new OSCMessage(oscAddressSynthWaveVCO);
        messageOff.AddValue(OSCValue.Int(0));
        transmitter.Send(messageOff);
        
        Debug.Log(messageOff);
        
        //Debug.Log("OFF");
    }
    //SAW
    public void SocketSaw(XRBaseInteractable interactable)
    {
        var messageSaw= new OSCMessage(oscAddressSynthWaveVCO);
        messageSaw.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSaw);
        
        Debug.Log(messageSaw);
        
        //Debug.Log("SawIn");
    }
    //RECT
    public void SocketRect(XRBaseInteractable interactable)
    {
        var messageRect= new OSCMessage(oscAddressSynthWaveVCO);
        messageRect.AddValue(OSCValue.Int(2));
        transmitter.Send(messageRect);
        
        //Debug.Log("RectOut");
    }
    //TRI
    public void SocketTri(XRBaseInteractable interactable)
    {
        var messageTri= new OSCMessage(oscAddressSynthWaveVCO);
        messageTri.AddValue(OSCValue.Int(3));
        transmitter.Send(messageTri);
        
        Debug.Log(messageTri);
        
        //Debug.Log("TriOut");
    }
    //SIN
    public void SocketSin(XRBaseInteractable interactable)
    {
        var messageSin= new OSCMessage(oscAddressSynthWaveVCO);
        messageSin.AddValue(OSCValue.Int(4));
        transmitter.Send(messageSin);
        
        Debug.Log(messageSin);
        //Debug.Log("SinOut");
    }
    //NOISE
    public void SocketNoise(XRBaseInteractable interactable)
    {
        var messageNoise= new OSCMessage(oscAddressSynthWaveVCO);
        messageNoise.AddValue(OSCValue.Int(5));
        transmitter.Send(messageNoise);
        
        Debug.Log(messageNoise);
        //Debug.Log("NoiseOut");
    }
    
}
