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
    private const string oscAddressDistOnOff = "/DistortionOnOff";
    private const string oscAddressDistValue = "/DistortionValue";
    private const string oscAddressSubPitch= "/SubPitch";
    private const string oscAddressReverbOnOff= "/ReverbOnOff";
    private const string oscAddressFilterFrequency= "/FilterFrequency";
    private const string oscAddressFilterResonance= "/FilterResonance";
    private const string oscAdreessDelayTimeOnOff= "/DelayTimeOnOff";
    
    
    
    //STARTING FLOATS
    private float s_VolumeRatio = 0.0f;
    private float s_PitchRatio = 0.0f;
    private float s_DrumVolume=0.0f;
    private float s_RatioDistortion = 0.0f;
    private float s_SubPitch = 0.0f;
    private float s_FilterFrequency=0.0f;
    private float s_FilterResonance = 0.0f;

    //bools Envelope
    private bool changedVolume=false;
    private bool sendOneTime = false;
    
    //bools Distortion
    private bool changedDistortion=false;
    private bool sendOneTimeDist = false;
   
    //bools Reverb
    private bool changedReverb = false;
    private bool sendOneTimeRev = false;
    

    // Start is called before the first frame update
    void Start()
    {
    }
     public void SynthVolumeChanged(DialInteractable dial)
    {
        float ratioVolume = dial.CurrentAngle / dial.RotationAngleMaximum;
        s_VolumeRatio = ratioVolume;
        
        var messageVol = new OSCMessage(oscAddressVolume);
        messageVol.AddValue(OSCValue.Float(s_VolumeRatio));
        transmitter.Send(messageVol);
       
      
    }
     public void SynthPitchChanged(DialInteractable dial)
        {
            float ratioPitch = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_PitchRatio = ratioPitch;
            
            var messagePitch = new OSCMessage(oscAddressPitch);
            messagePitch.AddValue(OSCValue.Float(s_PitchRatio));
            transmitter.Send(messagePitch);
            
        }
     public void SynthDrumVolumeChanged(DialInteractable dial)
     {
         float ratioDrumVolume = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_DrumVolume = ratioDrumVolume;
         
         var messageVolumeDrumVolume = new OSCMessage(oscAddressDrumVolume);
         messageVolumeDrumVolume.AddValue(OSCValue.Float(s_DrumVolume));
         transmitter.Send(messageVolumeDrumVolume);
     }

     public void DistortionVolume(DialInteractable dial)
     {
         float ratioDistortionValue = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_RatioDistortion = ratioDistortionValue ;
         
         var messageDistortionVolume = new OSCMessage(oscAddressDistValue);
         messageDistortionVolume.AddValue(OSCValue.Float(s_RatioDistortion));
         transmitter.Send(messageDistortionVolume);
       
     }
     
     public void SubPitch (DialInteractable dial)
     {
         float ratioSubPitch = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_SubPitch = ratioSubPitch;
         
         var messageSubPitch = new OSCMessage(oscAddressSubPitch);
         messageSubPitch.AddValue(OSCValue.Float(s_SubPitch));
         transmitter.Send(messageSubPitch);
         
     }
     public void FilterFrequency (DialInteractable dial)
     {
         float ratioFilterFrequency = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_FilterFrequency = ratioFilterFrequency;
         
         var messageFilterFrequency = new OSCMessage(oscAddressFilterFrequency);
         messageFilterFrequency.AddValue(OSCValue.Float(s_FilterFrequency));
         transmitter.Send(messageFilterFrequency);
         
     }
     public void FilterResonance (DialInteractable dial)
     {
         float ratioFilterResonance = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_FilterResonance = ratioFilterResonance;
         
         var messageFilterResonance = new OSCMessage(oscAddressFilterResonance);
         messageFilterResonance.AddValue(OSCValue.Float(s_FilterResonance));
         transmitter.Send(messageFilterResonance);
         
     }
     
     
     public void VolumeEnv(Single dragEnv)
     {
         if (dragEnv >=0.05f)
         {
             changedVolume= true;
         }
         if (dragEnv <0.05f)
         {
             changedVolume = false;
         }
         
     }
     public void DistortionOnOff (Single dragDist)
     {
         if (dragDist >=0.05f)
         {
             changedDistortion = true;
         }
         if (dragDist <0.05f)
         {
             changedDistortion = false;
         }
     }
     
     public void ReverbDrag (Single dragRev)
     {
         if (dragRev >=0.05f)
         {
             changedReverb= true;
         }
         if (dragRev <0.05f)
         {
             changedReverb = false;
         }
         
     }
     
     // Update is called once per frame
    void Update()
    {
        //TODO bools that will checked when the Value is ==0
        
        //Envelope Volume ONOFF
        if (changedVolume)
        {
            if (!sendOneTime)
            {
                var messageDragEnvOn= new OSCMessage(oscAddressVolumeEnv);
                messageDragEnvOn.AddValue(OSCValue.Int(1));
                transmitter.Send(messageDragEnvOn);
                sendOneTime = true;
            }
        }
        else if (!changedVolume)
        {
            if (sendOneTime)
            {
                var messageDragEnvOn= new OSCMessage(oscAddressVolumeEnv);
                messageDragEnvOn.AddValue(OSCValue.Int(0));
                transmitter.Send(messageDragEnvOn);
                sendOneTime = false;
            } 
        }
        
        //Distortion ONOFF
        if (changedDistortion)
        { 
            if (!sendOneTimeDist)
            {
                var messageDistDrag= new OSCMessage(oscAddressDistOnOff);
                messageDistDrag.AddValue(OSCValue.Int(1));
                transmitter.Send(messageDistDrag);
                sendOneTimeDist = true;
            }
        }
        else if (!changedDistortion)
        {
            if (sendOneTimeDist) 
            {
                var messageDistDrag= new OSCMessage(oscAddressDistOnOff);
                messageDistDrag.AddValue(OSCValue.Int(0));
                transmitter.Send(messageDistDrag);
                sendOneTimeDist = false;
            }
        
        }
        
        //Reverb ONOFF
        if (changedReverb)
        {
            if (!sendOneTimeRev)
            {
                var messageRevDrag= new OSCMessage(oscAddressReverbOnOff);
                messageRevDrag.AddValue(OSCValue.Int(1));
                transmitter.Send(messageRevDrag);
                sendOneTimeRev = true;
            }
        }
        else if (!sendOneTimeRev)
        {
            if (sendOneTimeRev)
            { 
                var messageRevDrag= new OSCMessage(oscAddressReverbOnOff);
                messageRevDrag.AddValue(OSCValue.Int(0));
                transmitter.Send(messageRevDrag);
                sendOneTimeRev = false;
            }
            
        }
        
        
    }
    
}
