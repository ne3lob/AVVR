using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

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
    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void SynthVolumeChanged(DialInteractable dial)
    {
      //  var messageVol = new OSCMessage(oscAddressVolume);
      //  messageVol.AddValue(OSCValue.Float(s_VolumeRatio));
        float ratioVolume = dial.CurrentAngle / dial.RotationAngleMaximum;
        s_VolumeRatio = ratioVolume;
       // transmitter.Send(messageVol);
        
        Debug.Log(s_VolumeRatio);
       // Debug.Log(messageVol);
    }
     public void SynthPitchChanged(DialInteractable dial)
        {
          //  var messagePitch = new OSCMessage(oscAddressPitch);
           // messagePitch.AddValue(OSCValue.Float(s_PitchRatio));
            float ratioPitch = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_PitchRatio = ratioPitch;
            //transmitter.Send(messagePitch);
            
            Debug.Log(s_PitchRatio);
          //  Debug.Log(messagePitch);
        }
     public void SynthVSOWavesOOFF(AxisDragInteractable axis)
     {
         var messageVSO = new OSCMessage(oscAddressVSO);
         //if 
         messageVSO.AddValue(OSCValue.Int(1));
         
         
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
    }
    
    

}
