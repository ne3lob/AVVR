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
    #region Octave Methoden
    
    public void SendXandYOctave0(int y)
    {
        TransmitterXandY(octaveInput, 0, y);
    }
    public void SendXandYOctave1(int y)
    {
        TransmitterXandY(octaveInput, 1, y);
    }
    public void SendXandYOctave2(int y)
    {
        TransmitterXandY(octaveInput, 2, y);
    }
    public void SendXandYOctave3(int y)
    {
        TransmitterXandY(octaveInput, 3, y);
    }
    public void SendXandYOctave4(int y)
    {
        TransmitterXandY(octaveInput, 4, y);
    }
    public void SendXandYOctave5(int y)
    {
        TransmitterXandY(octaveInput, 5, y);
    }
    public void SendXandYOctave6(int y)
    {
        TransmitterXandY(octaveInput, 6, y);
    }
    public void SendXandYOctave7(int y)
    {
        TransmitterXandY(octaveInput, 7, y);
    }
    public void SendXandYOctave8(int y)
    {
        TransmitterXandY(octaveInput, 8, y);
    }
    public void SendXandYOctave9(int y)
    {
        TransmitterXandY(octaveInput, 9, y);
    }
    public void SendXandYOctave10(int y)
    {
        TransmitterXandY(octaveInput, 10, y);
    }
    public void SendXandYOctave11(int y)
    {
        TransmitterXandY(octaveInput, 11, y);
    }
    public void SendXandYOctave12(int y)
    {
        TransmitterXandY(octaveInput, 12, y);
    }
    public void SendXandYOctave13(int y)
    {
        TransmitterXandY(octaveInput, 13, y);
    }
    public void SendXandYOctave14(int y)
    {
        TransmitterXandY(octaveInput, 14, y);
    }
    public void SendXandYOctave15(int y)
    {
        TransmitterXandY(octaveInput, 15, y);
    }
    #endregion
}