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
    private const string oscAddreessDelayTimeValue= "/DelayTimeValue";
    private const string oscAddreessDelayTimeFeedback="/DelayTimeFeedback";
    private const string oscAddreessFilterEnvelope="/FilterEnvelope";
    private const string oscAddreessPitchLfo="/PitchLfo";
    private const string oscAddreessFilterLfo="/FilterLfo";
    private const string oscAddreessPitchLfoFrequency="/PitchLfoFrequency";
    private const string oscAddreessPitchLfoLenght="/PitchLfoLenght";
    private const string oscAddreessFilterLfoFrequency="/FilterLfoFrequency";
    private const string oscAddreessFilterLfoLenght = "/FilterLfoLenght";
    
    //STARTING FLOATS
    private float s_VolumeRatio = 0.0f;
    private float s_PitchRatio = 0.0f;
    private float s_DrumVolume=0.0f;
    private float s_RatioDistortion = 0.0f;
    private float s_SubPitch = 0.0f;
    private float s_FilterFrequency=0.0f;
    private float s_FilterResonance = 0.0f;
    private float s_DalayTimeValue = 0.0f;
    private float s_DelayTimeFeedback = 0.0f;
    private float s_LfoPitchFrequency = 0.0f;
    private float s_LfoPitchLenght = 0.0f;
    private float s_LfoFilterLenght = 0.0f;
    private float s_LfoFilterFrequency = 0.0f;
    
        

    //bools Volume Envelope
    private bool changedVolume=false;
    private bool sendOneTime = false;
    
    //bools Distortion
    private bool changedDistortion=false;
    private bool sendOneTimeDist = false;
   
    //bools Reverb
    private bool changedReverb = false;
    private bool sendOneTimeRev = false;
    
    //bools Filter Envelope
    private bool changedFilterEnv = false;
    private bool sendOneTimeFilterEnve = false;
    
    //bools Pitch Lfo
    private bool changedPitchLfo= false;
    private bool sendOneTimePitchLfo = false;

    //bools Filter Lfo
    private bool changedFilterLfo=false;
    private bool sendOneTimeFilterLfo = false;
    

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
    
     public void LfoPitchFrequency (DialInteractable dial)
     {
         float ratioLfoPitchFrequency = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_LfoPitchFrequency = ratioLfoPitchFrequency ;
         
         var messageLfoPitchFrequency = new OSCMessage(oscAddreessPitchLfoFrequency);
         messageLfoPitchFrequency.AddValue(OSCValue.Float(s_LfoPitchFrequency));
         transmitter.Send(messageLfoPitchFrequency);
       
     }
     public void LfoPitchLenght (DialInteractable dial)
     {
         float ratioLfoPitchLenght = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_LfoPitchLenght = ratioLfoPitchLenght ;
         
         var messageLfoPitchLenght = new OSCMessage(oscAddreessPitchLfoLenght);
         messageLfoPitchLenght.AddValue(OSCValue.Float(s_LfoPitchLenght));
         transmitter.Send(messageLfoPitchLenght);
       
     }
     public void LfoFilterLenght (DialInteractable dial)
     {
         float ratioLfoFilterLenght = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_LfoFilterLenght = ratioLfoFilterLenght ;
         
         var messageLfoFilterLenght = new OSCMessage(oscAddreessFilterLfoLenght);
         messageLfoFilterLenght.AddValue(OSCValue.Float(s_LfoFilterLenght));
         transmitter.Send(messageLfoFilterLenght);
     }
     public void LfoFilterFrequency (DialInteractable dial)
     {
         float ratioLfoFilterFrequency = dial.CurrentAngle / dial.RotationAngleMaximum;
         s_LfoFilterFrequency = ratioLfoFilterFrequency ;
         
         var messageLfoFilterFrequency = new OSCMessage(oscAddreessFilterLfoFrequency);
         messageLfoFilterFrequency.AddValue(OSCValue.Float( s_LfoFilterFrequency));
         transmitter.Send(messageLfoFilterFrequency);
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
     public void DelayTimeValue (DialInteractable dial)
     {
         float ratioDalayTimeValue= dial.CurrentAngle / dial.RotationAngleMaximum;
         s_DalayTimeValue = ratioDalayTimeValue;
         
         var messageDelayTimeValue = new OSCMessage(oscAddreessDelayTimeValue);
         messageDelayTimeValue.AddValue(OSCValue.Float(s_DalayTimeValue));
         transmitter.Send( messageDelayTimeValue);
     }
     public void DelayTimeFeedback (DialInteractable dial)
     {
         float ratioDalayTimeFeedback= dial.CurrentAngle / dial.RotationAngleMaximum;
         s_DelayTimeFeedback = ratioDalayTimeFeedback;
         
         var messageDelayTimeFeedback = new OSCMessage(oscAddreessDelayTimeFeedback);
         messageDelayTimeFeedback.AddValue(OSCValue.Float(s_DelayTimeFeedback));
         transmitter.Send( messageDelayTimeFeedback);
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
     public void FiltrEnv(Single dragFilterEnv)
     {
         if (dragFilterEnv >=0.05f)
         {
             changedFilterEnv= true;
         }
         if (dragFilterEnv <0.05f)
         {
             changedFilterEnv= false;
         }
     }
     public void PitchLfo(Single dragPitchLfo)
     {
         if (dragPitchLfo >=0.05f)
         {
             changedPitchLfo= true;
         }
         if (dragPitchLfo <0.05f)
         {
             changedPitchLfo= false;
         }
     }
     public void FiltrLfo(Single dragFilterLfo)
     {
         if (dragFilterLfo >=0.05f)
         {
             changedFilterLfo= true;
         }
         if (dragFilterLfo <0.05f)
         {
             changedFilterLfo= false;
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
        //Filter Envelope
       if (changedFilterEnv)
       {
           if (!sendOneTimeFilterEnve)
           {
               var messageFilterEnvelope= new OSCMessage(oscAddreessFilterEnvelope);
               messageFilterEnvelope.AddValue(OSCValue.Int(1));
               transmitter.Send(messageFilterEnvelope);
               sendOneTimeFilterEnve = true;
           }
       }
       else if (!changedFilterEnv)
       {
           if (sendOneTimeFilterEnve)
           { 
               var messageFilterEnvelope= new OSCMessage(oscAddreessFilterEnvelope);
               messageFilterEnvelope.AddValue(OSCValue.Int(0));
               transmitter.Send(messageFilterEnvelope);
               sendOneTimeFilterEnve = false;
           }
            
       }
       if (changedPitchLfo)
       {
           if (!sendOneTimePitchLfo)
           {
               var messagePitchLfo= new OSCMessage(oscAddreessPitchLfo);
               messagePitchLfo.AddValue(OSCValue.Int(1));
               transmitter.Send(messagePitchLfo);
               sendOneTimePitchLfo = true;
           }
       }
       else if (!changedPitchLfo)
       {
           if (sendOneTimePitchLfo)
           { 
               var messagePitchLfo= new OSCMessage(oscAddreessFilterLfo);
               messagePitchLfo.AddValue(OSCValue.Int(0));
               transmitter.Send(messagePitchLfo);
               sendOneTimePitchLfo = false;
           }
            
       }
       
       
       
    }
}
