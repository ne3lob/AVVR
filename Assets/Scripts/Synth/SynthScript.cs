using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using extOSC;
using UnityEngine.XR.Interaction.Toolkit;

public class SynthScript : MonoBehaviour
{
    [Header("OSC Settings")] public OSCReceiver receiver;
    public OSCTransmitter transmitter;
    
    //ADRESS
    private const string oscAddressVolume = "/volume";
    private const string oscAddressPitch = "/pitch";
    private const string oscAddressDrumVolume = "/drumVolume";
    private const string oscAddressVolumeEnv = "/VolumeEnvelope";
    
    //STARTING FLOATS
    private float s_VolumeRatio = 0.0f;
    private float s_PitchRatio = 0.0f;
    private float s_DrumVolume=0.0f;

    private bool changedEnvVolume=false;
    private bool sendOneTime = false;

    
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
     public void SynthDrumVolumeChanged(DialInteractable dial)
     {
         float ratioDrumVolume = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_DrumVolume = ratioDrumVolume;
         Debug.Log(s_PitchRatio);
     }

     public void VolumeEnv(Single dragEnv)
     {
         if (dragEnv >=0.05f)
         {
             changedEnvVolume = true;
            // print(changedEnvVolume);
         }
         if (dragEnv <0.05f)
         {
             changedEnvVolume = false;
           //  print(changedEnvVolume);
         }
         
     }
     
     // Update is called once per frame
    void Update()
    {
        var messageVol = new OSCMessage(oscAddressVolume);
        messageVol.AddValue(OSCValue.Float(s_VolumeRatio));
        transmitter.Send(messageVol);
        
        var messagePitch = new OSCMessage(oscAddressPitch);
        messagePitch.AddValue(OSCValue.Float(s_PitchRatio));
        transmitter.Send(messagePitch);
        
        var messageVolumeDrumVolume = new OSCMessage(oscAddressDrumVolume);
        messageVolumeDrumVolume.AddValue(OSCValue.Float(s_DrumVolume));
        transmitter.Send(messageVolumeDrumVolume);

        if (changedEnvVolume)
        {
            if (!sendOneTime)
            {
                var messageDragEnvOn= new OSCMessage(oscAddressVolumeEnv);
                messageDragEnvOn.AddValue(OSCValue.Int(1));
                transmitter.Send(messageDragEnvOn);
                sendOneTime = true;
            }
        }

       else if (!changedEnvVolume)
        {
            if (sendOneTime)
            {
                var messageDragEnvOn= new OSCMessage(oscAddressVolumeEnv);
                messageDragEnvOn.AddValue(OSCValue.Int(0));
                transmitter.Send(messageDragEnvOn);
                sendOneTime = false;
                
            }
           
        }
        
    }
    
}
