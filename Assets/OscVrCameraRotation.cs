using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OscVrCameraRotation : MonoBehaviour
{
    private readonly string cameraRorAddress = "/VrRotationOne";

    [Header("OSC Settings")] public OSCTransmitter Transmitter;
    [SerializeField] private GameObject cam;

    // Update is called once per frame
    void Update()
    {
        SendingVrRot();
    }


    public void SendingVrRot()
    {
        var message = new OSCMessage(cameraRorAddress);
        message.AddValue(OSCValue.Float(cam.transform.localEulerAngles.y));
        Transmitter.Send(message);
    }
}