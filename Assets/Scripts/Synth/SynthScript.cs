using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using extOSC;
using extOSC.Core.Packers;
using extOSC.Core;
using UnityEngine.XR.Interaction.Toolkit;


public class SynthScript : MonoBehaviour
{
    [Header("OSC Settings")] public OSCReceiver receiver;
    public OSCTransmitter transmitter;
    
    //ADRESS
    private const string oscAddressVolume = "/volume";
    private const string oscAddressPitch = "/pitch";
    private const string oscAddressVSO = "/VSO";
    
    //STARTING FLOATS
    private float s_VolumeRatio = 0.0f;
    private float s_PitchRatio = 0.0f;
    
    private const string oscAddressSubOnOff = "/vcoSecondOnOff";
  

    public AxisDragInteractable interactable;
    
    
    // Start is called before the first frame update
    void Start()
    {
      
       
    }
    public void SynthVolumeChanged(DialInteractable dial)
    {
       
        float ratioVolume = dial.CurrentAngle / dial.RotationAngleMaximum;
        s_VolumeRatio = ratioVolume;
        Debug.Log(s_VolumeRatio);
       
    }
     public void SynthPitchChanged(DialInteractable dial)
        {
            
            float ratioPitch = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_PitchRatio = ratioPitch;
            
            Debug.Log(s_PitchRatio);
          
        }
     public void OnOff(XRBaseInteractor onOvs)
     {
        var len= interactable.AxisLength;
         if (len>=0.5f )
         {
             var messageSubOnOff= new OSCMessage(oscAddressSubOnOff);
             messageSubOnOff.AddValue(OSCValue.Int(1));
             transmitter.Send(messageSubOnOff);
             Debug.Log("0");
             
         }
         else
         {
             var messageSubOnOff= new OSCMessage(oscAddressSubOnOff);
             var countOne = 1;
             messageSubOnOff.AddValue(OSCValue.Int(0));
             transmitter.Send(messageSubOnOff);
             Debug.Log("1");
             
         }
     }
    
     // Update is called once per frame
    void Update()
    {
        var messagePitch = new OSCMessage(oscAddressPitch);
        messagePitch.AddValue(OSCValue.Float(s_PitchRatio));
        transmitter.Send(messagePitch);
        
        
        var messageVol = new OSCMessage(oscAddressVolume);
        messageVol.AddValue(OSCValue.Float(s_VolumeRatio));
        transmitter.Send(messageVol);
        
        
        
    }

}
