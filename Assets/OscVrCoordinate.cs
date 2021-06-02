using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OscVrCoordinate : MonoBehaviour
{
    private readonly string VrPosAddress = "/VrPositionX";

    [Header("OSC Settings")] public OSCTransmitter Transmitter;
    [SerializeField] private GameObject XrPositionX;

    void Update()
    {
        SendingVrPos();
    }

    public void SendingVrPos()
    {
        var message = new OSCMessage(VrPosAddress);
        message.AddValue(OSCValue.Float(XrPositionX.transform.position.x));
        Transmitter.Send(message);
        Debug.Log(message);
    }
}