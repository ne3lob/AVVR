using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class SynthScript : MonoBehaviour
{
    [Header("OSC Settings")] public OSCReceiver receiver;
    public OSCTransmitter transmitter;

    private const string oscAddressVolume = "/volume";
    float s_VolumeRatio = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //VOLUME Transmitter
       // var messageVol = new OSCMessage(oscAddressVolume);
      //  messageVol.AddValue(OSCValue.Float(s_VolumeRatio));
       // transmitter.Send(messageVol);
       // Debug.Log(messageVol);
        
    }
    public void SynthVolumeChanged(DialInteractable dial)
    {
        var messageVol = new OSCMessage(oscAddressVolume);
        messageVol.AddValue(OSCValue.Float(s_VolumeRatio));
        float ratio = dial.CurrentAngle / dial.RotationAngleMaximum;
        s_VolumeRatio = ratio;
        transmitter.Send(messageVol);
        Debug.Log(s_VolumeRatio);
        Debug.Log(messageVol);
        ;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

}
