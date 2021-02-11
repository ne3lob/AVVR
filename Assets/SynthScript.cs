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
    private const string oscAddressDrumVolume = "/drumVolume";
    
    //STARTING FLOATS
    private float s_VolumeRatio = 0.0f;
    private float s_PitchRatio = 0.0f;
    private float s_DrumVolume=0.0f;
    
    private int OVSWaves = 6;
    

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
     
     // Update is called once per frame
    void Update()
    {
        var messageVol = new OSCMessage(oscAddressVolume);
        messageVol.AddValue(OSCValue.Float(s_VolumeRatio));
        transmitter.Send(messageVol);
        
        var messagePitch = new OSCMessage(oscAddressPitch);
        messagePitch.AddValue(OSCValue.Float(s_PitchRatio));
        transmitter.Send(messagePitch);
        
        var messageVolumeDrumVolume = new OSCMessage(oscAddressPitch);
        messagePitch.AddValue(OSCValue.Float(s_DrumVolume));
        transmitter.Send(messagePitch);
    }
    
    

}
