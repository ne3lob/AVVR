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
    private const string pitchInput = "/InputPitchTabble";
    private const string triggerInput = "/InputTriggerTabble";
    private const string InputDrumSeq = "/InputDrumSeq";
    private const string InputSecondSeqOn = "/InputSecondSeqOn";
    private const string InputDrumKlang = "/InputDrumKlang";
    private const string InputDrumKick = "/InputDrumKick";
    private const string InputDrumKickTwo = "/InputDrumKickTwo";


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


    #region Pitch Methoden

    public void SendXandYPitch0(int y)
    {
        TransmitterXandY(pitchInput, 0, y);
    }

    public void SendXandYPitch1(int y)
    {
        TransmitterXandY(pitchInput, 1, y);
    }

    public void SendXandYPitch2(int y)
    {
        TransmitterXandY(pitchInput, 2, y);
    }

    public void SendXandYPitch3(int y)
    {
        TransmitterXandY(pitchInput, 3, y);
    }

    public void SendXandYPitch4(int y)
    {
        TransmitterXandY(pitchInput, 4, y);
    }

    public void SendXandYPitch5(int y)
    {
        TransmitterXandY(pitchInput, 5, y);
    }

    public void SendXandYPitch6(int y)
    {
        TransmitterXandY(pitchInput, 6, y);
    }

    public void SendXandYPitch7(int y)
    {
        TransmitterXandY(pitchInput, 7, y);
    }

    public void SendXandYPitch8(int y)
    {
        TransmitterXandY(pitchInput, 8, y);
    }

    public void SendXandYPitch9(int y)
    {
        TransmitterXandY(pitchInput, 9, y);
    }

    public void SendXandYPitch10(int y)
    {
        TransmitterXandY(pitchInput, 10, y);
    }

    public void SendXandYPitch11(int y)
    {
        TransmitterXandY(pitchInput, 11, y);
    }

    public void SendXandYPitch12(int y)
    {
        TransmitterXandY(pitchInput, 12, y);
    }

    public void SendXandYPitch13(int y)
    {
        TransmitterXandY(pitchInput, 13, y);
    }

    public void SendXandYPitch14(int y)
    {
        TransmitterXandY(pitchInput, 14, y);
    }

    public void SendXandYPitch15(int y)
    {
        TransmitterXandY(pitchInput, 15, y);
    }

    #endregion

    #region Pitch Methoden

    public void SendXandYTrigger0(int y)
    {
        TransmitterXandY(triggerInput, 0, y);
    }

    public void SendXandYTrigger1(int y)
    {
        TransmitterXandY(triggerInput, 1, y);
    }

    public void SendXandYTrigger2(int y)
    {
        TransmitterXandY(triggerInput, 2, y);
    }

    public void SendXandYTrigger3(int y)
    {
        TransmitterXandY(triggerInput, 3, y);
    }

    public void SendXandYTrigger4(int y)
    {
        TransmitterXandY(triggerInput, 4, y);
    }

    public void SendXandYTrigger5(int y)
    {
        TransmitterXandY(triggerInput, 5, y);
    }

    public void SendXandYTrigger6(int y)
    {
        TransmitterXandY(triggerInput, 6, y);
    }

    public void SendXandYTrigger7(int y)
    {
        TransmitterXandY(triggerInput, 7, y);
    }

    public void SendXandYTrigger8(int y)
    {
        TransmitterXandY(triggerInput, 8, y);
    }

    public void SendXandYTrigger9(int y)
    {
        TransmitterXandY(triggerInput, 9, y);
    }

    public void SendXandYTrigger10(int y)
    {
        TransmitterXandY(triggerInput, 10, y);
    }

    public void SendXandYTrigger11(int y)
    {
        TransmitterXandY(triggerInput, 11, y);
    }

    public void SendXandYTrigger12(int y)
    {
        TransmitterXandY(triggerInput, 12, y);
    }

    public void SendXandYTrigger13(int y)
    {
        TransmitterXandY(triggerInput, 13, y);
    }

    public void SendXandYTrigger14(int y)
    {
        TransmitterXandY(triggerInput, 14, y);
    }

    public void SendXandYTrigger15(int y)
    {
        TransmitterXandY(triggerInput, 15, y);
    }

    #endregion

    #region InputDrumSeq

    public void SendXandYInputDrumSeq0(int y)
    {
        TransmitterXandY(InputDrumSeq, 1, y);
    }

    public void SendXandYInputDrumSeq1(int y)
    {
        TransmitterXandY(InputDrumSeq, 2, y);
    }

    public void SendXandYInputDrumSeq2(int y)
    {
        TransmitterXandY(InputDrumSeq, 3, y);
    }

    public void SendXandYInputDrumSeq3(int y)
    {
        TransmitterXandY(InputDrumSeq, 4, y);
    }

    public void SendXandYInputDrumSeq4(int y)
    {
        TransmitterXandY(InputDrumSeq, 5, y);
    }

    public void SendXandYInputDrumSeq5(int y)
    {
        TransmitterXandY(InputDrumSeq, 6, y);
    }

    public void SendXandYInputDrumSeq6(int y)
    {
        TransmitterXandY(InputDrumSeq, 7, y);
    }

    public void SendXandYInputDrumSeq7(int y)
    {
        TransmitterXandY(InputDrumSeq, 8, y);
    }

    public void SendXandYInputDrumSeq8(int y)
    {
        TransmitterXandY(InputDrumSeq, 9, y);
    }

    public void SendXandYInputDrumSeq9(int y)
    {
        TransmitterXandY(InputDrumSeq, 10, y);
    }

    public void SendXandYInputDrumSeq10(int y)
    {
        TransmitterXandY(InputDrumSeq, 11, y);
    }

    public void SendXandYInputDrumSeq11(int y)
    {
        TransmitterXandY(InputDrumSeq, 12, y);
    }

    public void SendXandYInputDrumSeq12(int y)
    {
        TransmitterXandY(InputDrumSeq, 13, y);
    }

    public void SendXandYInputDrumSeq13(int y)
    {
        TransmitterXandY(InputDrumSeq, 14, y);
    }

    public void SendXandYInputDrumSeq14(int y)
    {
        TransmitterXandY(InputDrumSeq, 15, y);
    }

    public void SendXandYInputDrumSeq15(int y)
    {
        TransmitterXandY(InputDrumSeq, 16, y);
    }

    #endregion

    #region InputSecondSeq

    public void SendXandYInputSecondSeqOn0(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 1, y);
    }

    public void SendXandYInputSecondSeqOn1(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 2, y);
    }

    public void SendXandYInputSecondSeqOn2(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 3, y);
    }

    public void SendXandYInputSecondSeqOn3(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 4, y);
    }

    public void SendXandYInputSecondSeqOn4(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 5, y);
    }

    public void SendXandYInputSecondSeqOn5(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 6, y);
    }

    public void SendXandYInputSecondSeqOn6(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 7, y);
    }

    public void SendXandYInputSecondSeqOn7(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 8, y);
    }

    public void SendXandYInputSecondSeqOn8(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 9, y);
    }

    public void SendXandYInputSecondSeqOn9(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 10, y);
    }

    public void SendXandYInputSecondSeqOn10(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 11, y);
    }

    public void SendXandYInputSecondSeqOn11(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 12, y);
    }

    public void SendXandYInputSecondSeqOn12(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 13, y);
    }

    public void SendXandYInputSecondSeqOn13(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 14, y);
    }

    public void SendXandYInputSecondSeqOn14(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 15, y);
    }

    public void SendXandYInputSecondSeqOn15(int y)
    {
        TransmitterXandY(InputSecondSeqOn, 16, y);
    }

    #endregion

    #region InputDrumKlang

    public void SendXandYInputDrumKlang0(int y)
    {
        TransmitterXandY(InputDrumKlang, 1, y);
    }

    public void SendXandYInputDrumKlang1(int y)
    {
        TransmitterXandY(InputDrumKlang, 2, y);
    }

    public void SendXandYInputDrumKlang2(int y)
    {
        TransmitterXandY(InputDrumKlang, 3, y);
    }

    public void SendXandYInputDrumKlang3(int y)
    {
        TransmitterXandY(InputDrumKlang, 4, y);
    }

    public void SendXandYInputDrumKlang4(int y)
    {
        TransmitterXandY(InputDrumKlang, 5, y);
    }

    public void SendXandYInputDrumKlang5(int y)
    {
        TransmitterXandY(InputDrumKlang, 6, y);
    }

    public void SendXandYInputDrumKlang6(int y)
    {
        TransmitterXandY(InputDrumKlang, 7, y);
    }

    public void SendXandYInputDrumKlang7(int y)
    {
        TransmitterXandY(InputDrumKlang, 8, y);
    }

    public void SendXandYInputDrumKlang8(int y)
    {
        TransmitterXandY(InputDrumKlang, 9, y);
    }

    public void SendXandYInputDrumKlang9(int y)
    {
        TransmitterXandY(InputDrumKlang, 10, y);
    }

    public void SendXandYInputDrumKlang10(int y)
    {
        TransmitterXandY(InputDrumKlang, 11, y);
    }

    public void SendXandYInputDrumKlang11(int y)
    {
        TransmitterXandY(InputDrumKlang, 12, y);
    }

    public void SendXandYInputDrumKlang12(int y)
    {
        TransmitterXandY(InputDrumKlang, 13, y);
    }

    public void SendXandYInputDrumKlang13(int y)
    {
        TransmitterXandY(InputDrumKlang, 14, y);
    }

    public void SendXandYInputDrumKlang14(int y)
    {
        TransmitterXandY(InputDrumKlang, 15, y);
    }

    public void SendXandYInputDrumKlang15(int y)
    {
        TransmitterXandY(InputDrumKlang, 16, y);
    }

    #endregion

    #region InputDrumKick

    public void SendXandYInputDrumKick0(int y)
    {
        TransmitterXandY(InputDrumKick, 1, y);
    }

    public void SendXandYInputDrumKick1(int y)
    {
        TransmitterXandY(InputDrumKick, 2, y);
    }

    public void SendXandYInputDrumKick2(int y)
    {
        TransmitterXandY(InputDrumKick, 3, y);
    }

    public void SendXandYInputDrumKick3(int y)
    {
        TransmitterXandY(InputDrumKick, 4, y);
    }

    public void SendXandYInputDrumKick4(int y)
    {
        TransmitterXandY(InputDrumKick, 5, y);
    }

    public void SendXandYInputDrumKick5(int y)
    {
        TransmitterXandY(InputDrumKick, 6, y);
    }

    public void SendXandYInputDrumKick6(int y)
    {
        TransmitterXandY(InputDrumKick, 7, y);
    }

    public void SendXandYInputDrumKick7(int y)
    {
        TransmitterXandY(InputDrumKick, 8, y);
    }

    public void SendXandYInputDrumKick8(int y)
    {
        TransmitterXandY(InputDrumKick, 9, y);
    }

    public void SendXandYInputDrumKick9(int y)
    {
        TransmitterXandY(InputDrumKick, 10, y);
    }

    public void SendXandYInputDrumKick10(int y)
    {
        TransmitterXandY(InputDrumKick, 11, y);
    }

    public void SendXandYInputDrumKick11(int y)
    {
        TransmitterXandY(InputDrumKick, 12, y);
    }

    public void SendXandYInputDrumKick12(int y)
    {
        TransmitterXandY(InputDrumKick, 13, y);
    }

    public void SendXandYInputDrumKick13(int y)
    {
        TransmitterXandY(InputDrumKick, 14, y);
    }

    public void SendXandYInputDrumKick14(int y)
    {
        TransmitterXandY(InputDrumKick, 15, y);
    }

    public void SendXandYInputDrumKick15(int y)
    {
        TransmitterXandY(InputDrumKick, 16, y);
    }

    #endregion


    #region InputDrumKickTwo

    public void SendXandYInputDrumKickTwo0(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 1, y);
    }

    public void SendXandYInputDrumKickTwo1(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 2, y);
    }

    public void SendXandYInputDrumKickTwo2(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 3, y);
    }

    public void SendXandYInputDrumKickTwo3(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 4, y);
    }

    public void SendXandYInputDrumKickTwo4(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 5, y);
    }

    public void SendXandYInputDrumKickTwo5(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 6, y);
    }

    public void SendXandYInputDrumKickTwo6(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 7, y);
    }

    public void SendXandYInputDrumKickTwo7(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 8, y);
    }

    public void SendXandYInputDrumKickTwo8(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 9, y);
    }

    public void SendXandYInputDrumKickTwo9(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 10, y);
    }

    public void SendXandYInputDrumKickTwo10(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 11, y);
    }

    public void SendXandYInputDrumKickTwo11(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 12, y);
    }

    public void SendXandYInputDrumKickTwo12(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 13, y);
    }

    public void SendXandYInputDrumKickTwo13(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 14, y);
    }

    public void SendXandYInputDrumKickTwo14(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 15, y);
    }

    public void SendXandYInputDrumKickTwo15(int y)
    {
        TransmitterXandY(InputDrumKickTwo, 16, y);
    }

    #endregion
}