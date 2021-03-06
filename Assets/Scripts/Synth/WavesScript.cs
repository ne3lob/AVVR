using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using extOSC;


public class WavesScript : MonoBehaviour
{
    [Header("OSC Settings")] public OSCReceiver receiver;
    public OSCTransmitter transmitter;
    public XRExclusiveSocketInteractor socketInteractor;
    
    private const string oscAddressSynthWaveVCO = "/vcoWaveFirst";
    private const string oscAddressSynthWaveVCOSub = "/vcoWaveSecond";
    private const string oscAddressSynthWaveSubOnOff = "/vcoSecondOnOff";
    private const string oscAddressInputSynth = "/InputSynth";
    private const string oscAddressFilterType = "/FilterType";
    private const string oscAddressDelay= "/DelayNumber";
    private const string oscAdreessDelayTimeOnOff= "/DelayTimeOnOff";

    
    //TODO
    // public OSCMessage messageOn;
    // public void RatiooOn(OSCMessage bang, int kak, string kuk)
    // {
    //     bang=new OSCMessage(kuk);
    //     bang.AddValue(OSCValue.Int(kak));
    //     transmitter.Send(bang);
    // }
    // public void RatioChange(XRBaseInteractable interactable)
    // {
    //     RatiooOn(messageOn,0,oscAddressSynthWaveVCO);
    // }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //OFF
    public void SocketType(out OSCMessage messageName,string addressType,int numberType)
    {
        messageName = new OSCMessage(addressType);
        messageName.AddValue(OSCValue.Int(numberType));
        transmitter.Send(messageName);
    }
    public void SocketOFF(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageOff= new OSCMessage(oscAddressSynthWaveVCO);
        messageOff.AddValue(OSCValue.Int(0));
        transmitter.Send(messageOff);
        
    }
    //SAW
    public void SocketSaw(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageSaw= new OSCMessage(oscAddressSynthWaveVCO);
        messageSaw.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSaw);
        
    }
    //RECT
    public void SocketRect(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageRect= new OSCMessage(oscAddressSynthWaveVCO);
        messageRect.AddValue(OSCValue.Int(2));
        transmitter.Send(messageRect);
       
    }
    //TRI
    public void SocketTri(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageTri= new OSCMessage(oscAddressSynthWaveVCO);
        messageTri.AddValue(OSCValue.Int(3));
        transmitter.Send(messageTri);
        
    }
    //SIN
    public void SocketSin(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageSin= new OSCMessage(oscAddressSynthWaveVCO);
        messageSin.AddValue(OSCValue.Int(4));
        transmitter.Send(messageSin);
        
    }
    //NOISE
    public void SocketNoise(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageNoise= new OSCMessage(oscAddressSynthWaveVCO);
        messageNoise.AddValue(OSCValue.Int(5));
        transmitter.Send(messageNoise);
       
    }
    public void SockeSubNoise(XRBaseInteractable interactabletwo)
    {
        if (transmitter == null) return;
        
        var messageNoiseSub= new OSCMessage(oscAddressSynthWaveVCOSub);
        messageNoiseSub.AddValue(OSCValue.Int(5));
        transmitter.Send(messageNoiseSub);
        
        var messageSubOnOff= new OSCMessage(oscAddressSynthWaveSubOnOff);
        messageSubOnOff.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSubOnOff);
     
    }
    public void SocketSubSin(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageSinSub= new OSCMessage(oscAddressSynthWaveVCOSub);
        messageSinSub.AddValue(OSCValue.Int(4));
        transmitter.Send(messageSinSub);
        
        var messageSubOnOff= new OSCMessage(oscAddressSynthWaveSubOnOff);
        messageSubOnOff.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSubOnOff);
        
    }
    public void SocketSubTri(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageTriSub= new OSCMessage(oscAddressSynthWaveVCOSub);
        messageTriSub.AddValue(OSCValue.Int(3));
        transmitter.Send(messageTriSub);
     
        var messageSubOnOff= new OSCMessage(oscAddressSynthWaveSubOnOff);
        messageSubOnOff.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSubOnOff);
        
    }
    public void SocketSubSaw(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageSawSub= new OSCMessage(oscAddressSynthWaveVCOSub);
        messageSawSub.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSawSub);
       
        var messageSubOnOff= new OSCMessage(oscAddressSynthWaveSubOnOff);
        messageSubOnOff.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSubOnOff);
    }
    //RECT
    public void SocketSubRect(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageRectSub= new OSCMessage(oscAddressSynthWaveVCOSub);
        messageRectSub.AddValue(OSCValue.Int(2));
        transmitter.Send(messageRectSub);
        
        var messageSubOnOff= new OSCMessage(oscAddressSynthWaveSubOnOff);
        messageSubOnOff.AddValue(OSCValue.Int(1));
        transmitter.Send(messageSubOnOff);

    }
    public void SocketSubOFF(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageOff= new OSCMessage(oscAddressSynthWaveVCOSub);
        messageOff.AddValue(OSCValue.Int(0));
        transmitter.Send(messageOff);
        
        var messageSubOnOff= new OSCMessage(oscAddressSynthWaveSubOnOff);
        messageSubOnOff.AddValue(OSCValue.Int(0));
        transmitter.Send(messageSubOnOff);
        
    }
    public void OffInput(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageOffInput= new OSCMessage(oscAddressInputSynth);
        messageOffInput.AddValue(OSCValue.Int(0));
        transmitter.Send(messageOffInput);
    }
    public void PitchInput(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messagePitchInput= new OSCMessage(oscAddressInputSynth);
        messagePitchInput.AddValue(OSCValue.Int(1));
        transmitter.Send(messagePitchInput);
    }
    public void SequencerInput(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageSeqInput= new OSCMessage(oscAddressInputSynth);
        messageSeqInput.AddValue(OSCValue.Int(2));
        transmitter.Send(messageSeqInput);
    }
    public void SeqSlideInput(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageSeqSlideInput= new OSCMessage(oscAddressInputSynth);
        messageSeqSlideInput.AddValue(OSCValue.Int(3));
        transmitter.Send(messageSeqSlideInput);
    }
    public void FilterTypeOff (XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageFilterTypeOff= new OSCMessage(oscAddressFilterType);
        messageFilterTypeOff.AddValue(OSCValue.Int(0));
        transmitter.Send(messageFilterTypeOff);
    }
    public void FilterTypeLow (XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageFilterTypeLow= new OSCMessage(oscAddressFilterType);
        messageFilterTypeLow.AddValue(OSCValue.Int(1));
        transmitter.Send(messageFilterTypeLow);
    }
    public void FilterTypeHigh (XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageFilterTypeHigh= new OSCMessage(oscAddressFilterType);
        messageFilterTypeHigh.AddValue(OSCValue.Int(2));
        transmitter.Send(messageFilterTypeHigh);
    }
    public void FilterTypeBand (XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageFilterTypeBand= new OSCMessage(oscAddressFilterType);
        messageFilterTypeBand.AddValue(OSCValue.Int(3));
        transmitter.Send(messageFilterTypeBand);
    }
    public void DelayNumberNull (XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageDelayNumberNull= new OSCMessage(oscAddressDelay);
        messageDelayNumberNull.AddValue(OSCValue.Int(0));
        transmitter.Send(messageDelayNumberNull);
        
        var messageDelayTime= new OSCMessage( oscAdreessDelayTimeOnOff);
        messageDelayTime.AddValue(OSCValue.Int(1));
        transmitter.Send(messageDelayTime);
    }
    public void DelayNumberOne (XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageDelayNumberOne= new OSCMessage(oscAddressDelay);
        messageDelayNumberOne.AddValue(OSCValue.Int(1));
        transmitter.Send(messageDelayNumberOne);
        
        var messageDelayTime= new OSCMessage( oscAdreessDelayTimeOnOff);
        messageDelayTime.AddValue(OSCValue.Int(1));
        transmitter.Send(messageDelayTime);
    }
    public void DelayNumberTwo (XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageDelayNumberTwo= new OSCMessage(oscAddressDelay);
        messageDelayNumberTwo.AddValue(OSCValue.Int(2));
        transmitter.Send(messageDelayNumberTwo);
        
        var messageDelayTime= new OSCMessage( oscAdreessDelayTimeOnOff);
        messageDelayTime.AddValue(OSCValue.Int(1));
        transmitter.Send(messageDelayTime);
    }

    public void DelayNumberThree(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        var messageDelayNumberThree = new OSCMessage(oscAddressDelay);
        messageDelayNumberThree.AddValue(OSCValue.Int(3));
        transmitter.Send(messageDelayNumberThree);
        
        var messageDelayTime= new OSCMessage( oscAdreessDelayTimeOnOff);
        messageDelayTime.AddValue(OSCValue.Int(1));
        transmitter.Send(messageDelayTime);
    }
    public void DelayNumberFour(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageDelayNumberFour = new OSCMessage(oscAddressDelay);
        messageDelayNumberFour.AddValue(OSCValue.Int(4));
        transmitter.Send(messageDelayNumberFour);
        
        var messageDelayTime= new OSCMessage( oscAdreessDelayTimeOnOff);
        messageDelayTime.AddValue(OSCValue.Int(1));
        transmitter.Send(messageDelayTime);
    }
    public void DelayNumberFive(XRBaseInteractable interactable)
    {
        if (transmitter == null) return;
        
        var messageDelayNumberFive = new OSCMessage(oscAddressDelay);
        messageDelayNumberFive.AddValue(OSCValue.Int(5));
        transmitter.Send(messageDelayNumberFive);
        
        var messageDelayTime= new OSCMessage( oscAdreessDelayTimeOnOff);
        messageDelayTime.AddValue(OSCValue.Int(1));
        transmitter.Send(messageDelayTime);
    }

}
