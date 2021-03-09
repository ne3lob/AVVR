using extOSC;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Synth
{
    public class WavesScript : MonoBehaviour
    {
        [Header("OSC Settings")] public OSCTransmitter transmitter;

        private const string OscAddressSynthWaveVco = "/vcoWaveFirst";
        private const string OscAddressSynthWaveVcoSub = "/vcoWaveSecond";
        private const string OscAddressSynthWaveSubOnOff = "/vcoSecondOnOff";
        private const string OscAddressInputSynth = "/InputSynth";
        private const string OscAddressFilterType = "/FilterType";
        private const string OscAddressDelay = "/DelayNumber";
        private const string OscAddressDelayTimeOnOff = "/DelayTimeOnOff";

        #region OSCMessages
        private OSCMessage _messageOff;
        private OSCMessage _messageSaw;
        private OSCMessage _messageRect;
        private OSCMessage _messageTri;
        private OSCMessage _messageSin;
        private OSCMessage _messageNoise;
        private OSCMessage _messageNoiseSub;
        private OSCMessage _messageSubOnOff;
        private OSCMessage _messageSinSub;
        private OSCMessage _messageTriSub;
        private OSCMessage _messageSawSub;
        private OSCMessage _messageRectSub;
        private OSCMessage _messageOffInput;
        private OSCMessage _messagePitchInput;
        private OSCMessage _messageSeqInput;
        private OSCMessage _messageSeqSlideInput;
        private OSCMessage _messageFilterTypeOff;
        private OSCMessage _messageFilterTypeLow;
        private OSCMessage _messageFilterTypeHigh;
        private OSCMessage _messageFilterTypeBand;
        private OSCMessage _messageDelayTime;
        private OSCMessage _messageDelayNumberFive;
        private OSCMessage _messageDelayNumberFour;
        private OSCMessage _messageDelayNumberThree;
        private OSCMessage _messageDelayNumberTwo;
        private OSCMessage _messageDelayNumberOne;
        private OSCMessage _messageDelayNumberNull;
        
        #endregion
       

        //OFF
        private void SocketType(out OSCMessage messageName, string addressType, int numberType)
        {
            messageName = new OSCMessage(addressType);
            messageName.AddValue(OSCValue.Int(numberType));
            transmitter.Send(messageName);
        }
        

        public void SocketOff(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageOff, OscAddressSynthWaveVco, 0);
        }

        //SAW
        public void SocketSaw(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageSaw, OscAddressSynthWaveVco, 1);
        }

        //RECT
        public void SocketRect(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageRect, OscAddressSynthWaveVco, 2);
        }

        //TRI
        public void SocketTri(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageTri, OscAddressSynthWaveVco, 3);
        }

        //SIN
        public void SocketSin(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageSin, OscAddressSynthWaveVco, 4);
        }

        //NOISE
        public void SocketNoise(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageNoise, OscAddressSynthWaveVco, 5);
        }

        public void SocketSubNoise(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            
            SocketType(out _messageNoiseSub, OscAddressSynthWaveVcoSub, 5);
            SocketType(out _messageSubOnOff, OscAddressSynthWaveSubOnOff, 1);
        }

        public void SocketSubSin(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            
            SocketType(out _messageSinSub, OscAddressSynthWaveVcoSub, 4);
            SocketType(out _messageSubOnOff, OscAddressSynthWaveSubOnOff, 1);
            
        }

        public void SocketSubTri(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageTriSub, OscAddressSynthWaveVcoSub, 3);
            SocketType(out _messageSubOnOff, OscAddressSynthWaveSubOnOff, 1);
           
        }

        public void SocketSubSaw(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageSawSub, OscAddressSynthWaveVcoSub, 1);
            SocketType(out _messageSubOnOff, OscAddressSynthWaveSubOnOff, 1);
            
        }

        //RECT
        public void SocketSubRect(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageRectSub, OscAddressSynthWaveVcoSub, 2);
            SocketType(out _messageSubOnOff, OscAddressSynthWaveSubOnOff, 1);
        }

        public void SocketSubOff(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageOff, OscAddressSynthWaveVcoSub, 0);
            SocketType(out _messageSubOnOff, OscAddressSynthWaveSubOnOff, 0);
        }

        public void OffInput(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            
            SocketType(out _messageOffInput, OscAddressInputSynth, 0);
        }

        public void PitchInput(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messagePitchInput, OscAddressInputSynth, 1);
        }

        public void SequencerInput(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageSeqInput, OscAddressInputSynth, 2);
        }

        public void SeqSlideInput(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageSeqSlideInput, OscAddressInputSynth, 3);
        }

        public void FilterTypeOff(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageFilterTypeOff, OscAddressFilterType, 0);
        }

        public void FilterTypeLow(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageFilterTypeLow, OscAddressFilterType, 1);
        }

        public void FilterTypeHigh(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageFilterTypeHigh, OscAddressFilterType, 2);
        }

        public void FilterTypeBand(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageFilterTypeBand, OscAddressFilterType, 3);
           
        }

        public void DelayNumberNull(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageDelayNumberNull, OscAddressDelay, 0);
            
            SocketType(out _messageDelayTime, OscAddressDelayTimeOnOff, 1);
        
        }
        
        public void DelayNumberOne(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageDelayNumberOne, OscAddressDelay, 1);
            
            SocketType(out _messageDelayTime, OscAddressDelayTimeOnOff, 1);
        }

        public void DelayNumberTwo(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageDelayNumberTwo, OscAddressDelay, 2);
            
            SocketType(out _messageDelayTime, OscAddressDelayTimeOnOff, 1);
        }

        public void DelayNumberThree(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageDelayNumberThree, OscAddressDelay, 3);
           
            SocketType(out _messageDelayTime, OscAddressDelayTimeOnOff, 1);
            
        }

        public void DelayNumberFour(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageDelayNumberFour, OscAddressDelay, 4);
            SocketType(out _messageDelayTime, OscAddressDelayTimeOnOff, 1);
        }

        public void DelayNumberFive(XRBaseInteractable interactable)
        {
            if (transmitter == null) return;
            SocketType(out _messageDelayNumberFive, OscAddressDelay, 5);
            SocketType(out _messageDelayTime, OscAddressDelayTimeOnOff, 1);
        }
    } 
}