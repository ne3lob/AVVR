using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using extOSC;

public class TabblesScript : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>(8);

    public Material notSelected;
    [Header("OSC Settings")] public OSCTransmitter transmitter;

    private bool isPressed;

    private const string octaveInput = "/InputOctave";

    private void TransmitterXandY(string addressType, int x, int y)
    {
        var message = new OSCMessage(addressType);
        message.AddValue(OSCValue.Int(x));
        message.AddValue(OSCValue.Int(y));
        transmitter.Send(message);
    }

    public void ChangeTheColor(Material change)
    {
        foreach (var cubesMaterial in cubes)
        {
            cubesMaterial.GetComponent<MeshRenderer>().material = notSelected;
        }

        this.gameObject.GetComponent<MeshRenderer>().material = change;
    }

    public void SendXandYOctave0(int y)
    {
        TransmitterXandY(octaveInput, 0, y);
    }
}