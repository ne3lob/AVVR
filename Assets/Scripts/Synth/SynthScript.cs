using System;
using System.Globalization;
using extOSC;
using TMPro;
using UnityEngine;

namespace Synth
{
    public class SynthScript : MonoBehaviour
    {
        [Header("OSC Settings")] public OSCTransmitter transmitter;

        //ADRESS
        private const string oscAddressVolume = "/volume";
        private const string oscAddressPitch = "/pitch";
        private const string oscAddressDrumVolume = "/drumVolume";
        private const string oscAddressVolumeEnv = "/VolumeEnvelope";
        private const string oscAddressDistOnOff = "/DistortionOnOff";
        private const string oscAddressDistValue = "/DistortionValue";
        private const string oscAddressSubPitch = "/SubPitch";
        private const string oscAddressReverbOnOff = "/ReverbOnOff";
        private const string oscAddressFilterFrequency = "/FilterFrequency";
        private const string oscAddressFilterResonance = "/FilterResonance";
        private const string oscAddreessDelayTimeValue = "/DelayTimeValue";
        private const string oscAddreessDelayTimeFeedback = "/DelayTimeFeedback";
        private const string oscAddreessFilterEnvelope = "/FilterEnvelope";
        private const string oscAddreessPitchLfo = "/PitchLfo";
        private const string oscAddreessFilterLfo = "/FilterLfo";
        private const string oscAddreessPitchLfoFrequency = "/PitchLfoFrequency";
        private const string oscAddreessPitchLfoLenght = "/PitchLfoLenght";
        private const string oscAddreessFilterLfoFrequency = "/FilterLfoFrequency";
        private const string oscAddreessFilterLfoLenght = "/FilterLfoLenght";
        private const string timeSeqSlider = "/TimeSeqSlider";
        private const string reverbSpace = "/ReverbSpace";
        private const string _reflectionReverb = "/ReverbReflection";
        private const string _sequencerOnOff = "/SequencerOnOff";
        private const string adressBpm = "/Bpm";
        private const string oscAddressButtonRandom = "/ButtonRandom";

        private const string _drumSeqOn = "/DrumSeqOn";
        private const string _drumSecondSeqOn = "/DrumSecondSeqOn";
        private const string _drumKlangOnOff = "/DrumKlang";
        private const string _drumKickOnOff = "/DrumKick";
        private const string _drumKickTwoOnOff = "/DrumKickTwo";


        private const string oscAddresssDrumKlang = "/DialDrumKlang";
        private const string oscAddresssDrumSecondSeqPitchOne = "/DrumSecondSeqPitchOne";
        private const string oscAddresssDrumSecondSeqPitchTwo = "/DrumSecondSeqPitchTwo";
        private const string oscAddresssDrumSecondSeqEnvelope = "/DrumSecondSeqEnvelope";


        private const string oscAddressDrumSeqPitchOne = "/DrumSeqPitchOne";
        private const string oscAddressDrumSeqPitchTwo = "/DrumSeqPitchTwo";
        private const string oscAddressDrumSeqPitchThree = "/DrumSeqPitchThree";

        private const string oscAddressDrumSeqEnvelopOne = "/DrumSeqEnvelopOne";
        private const string oscAddressDrumSeqEnvelopTwo = "/DrumSeqEnvelopTwo";
        private const string oscAddressDrumSeqEnvelopThree = "/DrumSeqEnvelopThree";

        private const string oscAddressDrumSeqOverdrive = "/DrumSeqOverDrive";

        //STARTING FLOATS
        private float s_VolumeRatio = 0.0f;
        public float s_PitchRatio = 0.0f;
        private float s_DrumVolume = 0.0f;
        private float s_RatioDistortion = 0.0f;
        private float s_SubPitch = 0.0f;
        private float s_FilterFrequency = 0.0f;
        private float s_FilterResonance = 0.0f;
        private float s_DalayTimeValue = 0.0f;
        private float s_DelayTimeFeedback = 0.0f;
        private float s_LfoPitchFrequency = 0.0f;
        private float s_LfoPitchLenght = 0.0f;
        private float s_LfoFilterLenght = 0.0f;
        private float s_LfoFilterFrequency = 0.0f;
        private float s_TimeSeqSlider = 0.0f;
        private float s_ReverbSpace = 0.0f;
        private float s_ReverbReflection = 0.0f;
        private float s_Bpm = 0.0f;
        private float s_DrumKlang = 0.0f;
        private float s_SecondSeqPitchOne = 0.0f;
        private float s_DrumSecondSeqPitchTwo = 0.0f;
        private float s_DrumSecondSeqEnvelope = 0.0f;
        private float s_DrumSeqPitchOne = 0.0f;
        private float s_DrumSeqPitchTwo = 0.0f;
        private float s_DrumSeqPitchThree = 0.0f;
        private float s_DrumSeqEnvelopOne = 0.0f;
        private float s_DrumSeqEnvelopTwo = 0.0f;
        private float s_DrumSeqEnvelopThree = 0.0f;
        private float s_DrumSeqOverdrive = 0.0f;

        //bools Volume Envelope
        private bool changedVolume;
        private bool sendOneTime;

        //bools Distortion
        private bool changedDistortion;
        private bool sendOneTimeDist;

        //bools Reverb
        private bool changedReverb;
        private bool sendOneTimeRev;

        //bools Filter Envelope
        private bool changedFilterEnv;
        private bool sendOneTimeFilterEnve;

        //bools Pitch Lfo
        private bool changedPitchLfo;
        private bool sendOneTimePitchLfo;

        //bools Filter Lfo
        private bool changedFilterLfo;
        private bool sendOneTimeFilterLfo;

        private bool changedSeq;
        private bool sendOneTimeSeq;

        //SeqDrum
        private bool changedDragSeqOn;
        private bool sendOneTimeDrugSeq;


        private bool changedDragKickTwo;
        private bool sendOneTimeKickTwo;
        
        private bool changedDragSecondSeqOn;
        private bool sendOneTimeDrugSecondSeq;

        #region OSCMessagesSec

        private OSCMessage _messageVol;
        private OSCMessage _messagePitch;
        private OSCMessage _messageVolumeDrumVolume;
        private OSCMessage _messageDistortionVolume;
        private OSCMessage _messageLfoPitchFrequency;
        private OSCMessage _messageLfoPitchLenght;
        private OSCMessage _messageLfoFilterLenght;
        private OSCMessage _messageLfoFilterFrequency;
        private OSCMessage _messageSubPitch;
        private OSCMessage _messageFilterFrequency;
        private OSCMessage _messageFilterResonance;
        private OSCMessage _messageDelayTimeValue;
        private OSCMessage _messageDelayTimeFeedback;
        private OSCMessage _messageDragEnvOn;
        private OSCMessage _messageDistDrag;
        private OSCMessage _messageRevDrag;
        private OSCMessage _messageFilterEnvelope;
        private OSCMessage _messagePitchLfo;
        private OSCMessage _messageFilterLfo;
        private OSCMessage _messageTimeSeqSlider;
        private OSCMessage _messageReverbSpace;
        private OSCMessage _messageReverbReflection;
        private OSCMessage _messageSeq;
        private OSCMessage _messageBpm;
        private OSCMessage _messageButtonRandom;
        private OSCMessage _messageSeqDrumOn;
        private OSCMessage _messageKickTwo;
        private OSCMessage _messagesDrumKlang;
        private OSCMessage _messagesDrumSecondSeqPitchOne;
        private OSCMessage _messagesDrumSecondSeqPitchTwo;
        private OSCMessage _messagesDrumSecondSeqEnvelope;
        private OSCMessage _messagesDrumSeqPitchOne;
        private OSCMessage _messagesDrumSeqPitchTwo;
        private OSCMessage _messagesDrumSeqPitchThree;
        private OSCMessage _messagesDrumSeqEnvelopOne;
        private OSCMessage _messagesDrumSeqEnvelopTwo;
        private OSCMessage _messagesDrumSeqEnvelopThree;
        private OSCMessage _messagesDrumSeqOverdrive;
        private OSCMessage _messageSecondSeqDrumOn;
        #endregion


        //space
        public TextMeshPro space;
        private string nameS;


        //bpm
        public TextMeshPro bpm;
        private string nameBpm;


        private void DialTypeChangedFloat(out OSCMessage messageName, string addressType, float ratioScaleFlaot)
        {
            messageName = new OSCMessage(addressType);
            messageName.AddValue(OSCValue.Float(ratioScaleFlaot));
            transmitter.Send(messageName);
        }

        private void DialTypeChangedInt(out OSCMessage messageName, string addressType, int ratioScaleInt)
        {
            messageName = new OSCMessage(addressType);
            messageName.AddValue(OSCValue.Float(ratioScaleInt));
            transmitter.Send(messageName);
        }

        public void DialDrumSeqPitchOne(DialInteractable dial)
        {
            float ratioDrumSeqPitchOne = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSeqPitchOne = ratioDrumSeqPitchOne;

            DialTypeChangedFloat(out _messagesDrumSeqPitchOne, oscAddressDrumSeqPitchOne, s_DrumSeqPitchOne);
        }

        public void DialDrumSeqPitchTwo(DialInteractable dial)
        {
            float ratioDrumSeqPitchTwo = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSeqPitchTwo = ratioDrumSeqPitchTwo;

            DialTypeChangedFloat(out _messagesDrumSeqPitchTwo, oscAddressDrumSeqPitchTwo, s_DrumSeqPitchTwo);
        }

        public void DialDrumSeqEnvelopOne(DialInteractable dial)
        {
            float ratioDrumSeqEnvelopOne = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSeqEnvelopOne = ratioDrumSeqEnvelopOne;

            DialTypeChangedFloat(out _messagesDrumSeqEnvelopOne, oscAddressDrumSeqEnvelopOne, s_DrumSeqEnvelopOne);
        }

        public void DialDrumSeqEnvelopTwo(DialInteractable dial)
        {
            float ratioDrumSeqEnvelopTwo = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSeqEnvelopTwo = ratioDrumSeqEnvelopTwo;

            DialTypeChangedFloat(out _messagesDrumSeqEnvelopTwo, oscAddressDrumSeqEnvelopTwo, s_DrumSeqEnvelopTwo);
        }

        public void DialDrumSeqEnvelopThree(DialInteractable dial)
        {
            float ratioDrumSeqEnvelopThree = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSeqEnvelopThree = ratioDrumSeqEnvelopThree;

            DialTypeChangedFloat(out _messagesDrumSeqEnvelopThree, oscAddressDrumSeqEnvelopThree,
                s_DrumSeqEnvelopThree);
        }

        public void DialDrumSeqOverdrive(DialInteractable dial)
        {
            float ratioDrumSeqOverdrive = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSeqOverdrive = ratioDrumSeqOverdrive;

            DialTypeChangedFloat(out _messagesDrumSeqOverdrive, oscAddressDrumSeqOverdrive, s_DrumSeqOverdrive);
        }

        public void DialDrumSeqPitchThree(DialInteractable dial)
        {
            float ratioDrumSeqPitchThree = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSeqPitchThree = ratioDrumSeqPitchThree;

            DialTypeChangedFloat(out _messagesDrumSeqPitchThree, oscAddressDrumSeqPitchThree, s_DrumSeqPitchThree);
        }

        public void DialDrumKlang(DialInteractable dial)
        {
            float ratioDrumKlang = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumKlang = ratioDrumKlang;

            DialTypeChangedFloat(out _messagesDrumKlang, oscAddresssDrumKlang, s_DrumKlang);
        }

        public void DialDrumSecondSeqPitchOne(DialInteractable dial)
        {
            float ratioDrumSecondSeqPitchOne = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_SecondSeqPitchOne = ratioDrumSecondSeqPitchOne;

            DialTypeChangedFloat(out _messagesDrumSecondSeqPitchOne, oscAddresssDrumSecondSeqPitchOne,
                s_SecondSeqPitchOne);
        }

        public void DialDrumSecondSeqPitchTwo(DialInteractable dial)
        {
            float ratioDrumSecondSeqPitchTwo = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSecondSeqPitchTwo = ratioDrumSecondSeqPitchTwo;

            DialTypeChangedFloat(out _messagesDrumSecondSeqPitchTwo, oscAddresssDrumSecondSeqPitchTwo,
                s_DrumSecondSeqPitchTwo);
        }

        public void DialDrumSecondSeqEnvelope(DialInteractable dial)
        {
            float ratioDrumSecondSeqEnvelope = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumSecondSeqEnvelope = ratioDrumSecondSeqEnvelope;

            DialTypeChangedFloat(out _messagesDrumSecondSeqEnvelope, oscAddresssDrumSecondSeqEnvelope,
                s_DrumSecondSeqEnvelope);
        }


        public void SynthVolumeChanged(DialInteractable dial)
        {
            float ratioVolume = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_VolumeRatio = ratioVolume;

            DialTypeChangedFloat(out _messageVol, oscAddressVolume, s_VolumeRatio);
        }

        public void SynthPitchChanged(DialInteractable dial)
        {
            float ratioPitch = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_PitchRatio = ratioPitch;

            DialTypeChangedFloat(out _messagePitch, oscAddressPitch, s_PitchRatio);
        }

        public void SynthDrumVolumeChanged(DialInteractable dial)
        {
            float ratioDrumVolume = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DrumVolume = ratioDrumVolume;

            DialTypeChangedFloat(out _messageVolumeDrumVolume, oscAddressDrumVolume, s_DrumVolume);
        }

        public void DistortionVolume(DialInteractable dial)
        {
            float ratioDistortionValue = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_RatioDistortion = ratioDistortionValue;

            DialTypeChangedFloat(out _messageDistortionVolume, oscAddressDistValue, s_RatioDistortion);
        }

        public void LfoPitchFrequency(DialInteractable dial)
        {
            float ratioLfoPitchFrequency = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_LfoPitchFrequency = ratioLfoPitchFrequency;

            DialTypeChangedFloat(out _messageLfoPitchFrequency, oscAddreessPitchLfoFrequency, s_LfoPitchFrequency);
        }

        public void LfoPitchLenght(DialInteractable dial)
        {
            float ratioLfoPitchLenght = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_LfoPitchLenght = ratioLfoPitchLenght;

            DialTypeChangedFloat(out _messageLfoPitchLenght, oscAddreessPitchLfoLenght, s_LfoPitchLenght);
        }

        public void LfoFilterLenght(DialInteractable dial)
        {
            float ratioLfoFilterLenght = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_LfoFilterLenght = ratioLfoFilterLenght;

            DialTypeChangedFloat(out _messageLfoFilterLenght, oscAddreessFilterLfoLenght, s_LfoFilterLenght);
        }

        public void LfoFilterFrequency(DialInteractable dial)
        {
            float ratioLfoFilterFrequency = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_LfoFilterFrequency = ratioLfoFilterFrequency;

            DialTypeChangedFloat(out _messageLfoFilterFrequency, oscAddreessFilterLfoFrequency, s_LfoFilterFrequency);
        }

        public void SubPitch(DialInteractable dial)
        {
            float ratioSubPitch = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_SubPitch = ratioSubPitch;

            DialTypeChangedFloat(out _messageSubPitch, oscAddressSubPitch, s_SubPitch);
        }

        public void FilterFrequency(DialInteractable dial)
        {
            float ratioFilterFrequency = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_FilterFrequency = ratioFilterFrequency;

            DialTypeChangedFloat(out _messageFilterFrequency, oscAddressFilterFrequency, s_FilterFrequency);
        }

        public void FilterResonance(DialInteractable dial)
        {
            float ratioFilterResonance = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_FilterResonance = ratioFilterResonance;

            DialTypeChangedFloat(out _messageFilterResonance, oscAddressFilterResonance, s_FilterResonance);
        }

        public void DelayTimeValue(DialInteractable dial)
        {
            float ratioDalayTimeValue = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DalayTimeValue = ratioDalayTimeValue;

            DialTypeChangedFloat(out _messageDelayTimeValue, oscAddreessDelayTimeValue, s_DalayTimeValue);
        }

        public void DelayTimeFeedback(DialInteractable dial)
        {
            float ratioDalayTimeFeedback = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_DelayTimeFeedback = ratioDalayTimeFeedback;

            DialTypeChangedFloat(out _messageDelayTimeFeedback, oscAddreessDelayTimeFeedback, s_DelayTimeFeedback);
        }

        public void TimeSeqSlider(DialInteractable dial)
        {
            float ratioTimeSeqSlider = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_TimeSeqSlider = ratioTimeSeqSlider;


            DialTypeChangedFloat(out _messageTimeSeqSlider, timeSeqSlider, s_TimeSeqSlider);
        }

        public void ReverbSpace(DialInteractable dial)
        {
            float ratioReverbSpace = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_ReverbSpace = ratioReverbSpace;

            DialTypeChangedFloat(out _messageReverbSpace, reverbSpace, s_ReverbSpace);
        }

        public void ReflectionReverb(Single reflectionReverb)
        {
            DialTypeChangedFloat(out _messageReverbReflection, _reflectionReverb, reflectionReverb);
            var rightreflectionReverb = reflectionReverb * 10f;
            space.maxVisibleCharacters = 4;
            space.text = rightreflectionReverb.ToString(nameS);
        }

        public void Bpm(DialInteractable dial)
        {
            float ratioBpm = dial.CurrentAngle / dial.RotationAngleMaximum;
            s_Bpm = ratioBpm;
            DialTypeChangedFloat(out _messageBpm, adressBpm, s_Bpm);

            var rightBpm = s_Bpm / 5.6f * 1000f;
            bpm.maxVisibleCharacters = 3;
            bpm.text = rightBpm.ToString(nameBpm);
        }

        public void SequencerOnOff(Single dragSeq)
        {
            if (dragSeq >= 0.015f)
            {
                changedSeq = true;
                if (!sendOneTimeSeq)
                {
                    DialTypeChangedInt(out _messageSeq, _sequencerOnOff, 1);
                    sendOneTimeSeq = true;
                }
            }

            if (dragSeq < 0.025f)
            {
                changedSeq = false;
                if (sendOneTimeSeq)
                {
                    DialTypeChangedInt(out _messageSeq, _sequencerOnOff, 0);
                    sendOneTimeSeq = false;
                }
            }
        }


        public void DrumSeqOn(Single dragSeq)
        {
            if (dragSeq >= 0.025f)
            {
                changedDragSeqOn = true;
                if (!sendOneTimeDrugSeq)
                {
                    DialTypeChangedInt(out _messageSeqDrumOn, _drumSeqOn, 1);
                    sendOneTimeDrugSeq = true;
                }
            }

            if (dragSeq < 0.025f)
            {
                changedDragSeqOn = false;
                if (sendOneTimeDrugSeq)
                {
                    DialTypeChangedInt(out _messageSeqDrumOn, _drumSeqOn, 0);
                    sendOneTimeDrugSeq = false;
                }
            }
        }
        

        public void DrumSecondSeqOn(Single dragSeq)
        {
            if (dragSeq >= 0.025f)
            {
                changedDragSecondSeqOn = true;
                if (!sendOneTimeDrugSecondSeq)
                {
                    DialTypeChangedInt(out _messageSecondSeqDrumOn, _drumSecondSeqOn, 1);
                    sendOneTimeDrugSecondSeq = true;
                    Debug.Log(dragSeq);
                }
            }

            if (dragSeq < 0.025f)
            {
                changedDragSecondSeqOn = false;
                if (sendOneTimeDrugSecondSeq)
                {
                    DialTypeChangedInt(out _messageSecondSeqDrumOn, _drumSecondSeqOn, 0);
                    sendOneTimeDrugSecondSeq = false;
                    Debug.Log(dragSeq);
                }
            }
        }

        private bool changedDragKlang;
        private bool sendOneTimeKlang;
        private OSCMessage _messageKlang;

        public void DrumKlang(Single dragSeq)
        {
            if (dragSeq >= 0.025f)
            {
                changedDragKlang = true;
                if (!sendOneTimeKlang)
                {
                    DialTypeChangedInt(out _messageKlang, _drumKlangOnOff, 1);
                    sendOneTimeKlang = true;
                }
            }

            if (dragSeq < 0.025f)
            {
                changedDragKlang = false;
                if (sendOneTimeKlang)
                {
                    DialTypeChangedInt(out _messageKlang, _drumKlangOnOff, 0);
                    sendOneTimeKlang = false;
                }
            }
        }

        private bool changedDragKick;
        private bool sendOneTimeKick;
        private OSCMessage _messageKick;

        public void DrumKick(Single dragSeq)
        {
            if (dragSeq >= 0.025f)
            {
                changedDragKick = true;
                if (!sendOneTimeKick)
                {
                    DialTypeChangedInt(out _messageKick, _drumKickOnOff, 1);
                    sendOneTimeKick = true;
                }
            }

            if (dragSeq < 0.025f)
            {
                changedDragKick = false;
                if (sendOneTimeKick)
                {
                    DialTypeChangedInt(out _messageKick, _drumKickOnOff, 0);
                    sendOneTimeKick = false;
                }
            }
        }


        public void DrumKickTwo(Single dragSeq)
        {
            if (dragSeq >= 0.025f)
            {
                changedDragKickTwo = true;
                if (!sendOneTimeKickTwo)
                {
                    DialTypeChangedInt(out _messageKickTwo, _drumKickTwoOnOff, 1);
                    sendOneTimeKickTwo = true;
                }
            }

            if (dragSeq < 0.025f)
            {
                changedDragKickTwo = false;
                if (sendOneTimeKickTwo)
                {
                    DialTypeChangedInt(out _messageKickTwo, _drumKickTwoOnOff, 0);
                    sendOneTimeKickTwo = false;
                }
            }
        }


        public void ButtonRandom()
        {
            DialTypeChangedInt(out _messageButtonRandom, oscAddressButtonRandom, 1);
        }


        public void VolumeEnv(Single dragEnv)
        {
            if (dragEnv >= 0.05f)
            {
                changedVolume = true;
                if (!sendOneTime)
                {
                    DialTypeChangedInt(out _messageDragEnvOn, oscAddressVolumeEnv, 1);
                    sendOneTime = true;
                }
            }

            if (dragEnv < 0.05f)
            {
                changedVolume = false;
                if (sendOneTime)
                {
                    DialTypeChangedInt(out _messageDragEnvOn, oscAddressVolumeEnv, 0);
                    sendOneTime = false;
                }
            }
        }

        public void FiltrEnv(Single dragFilterEnv)
        {
            if (dragFilterEnv >= 0.05f)
            {
                changedFilterEnv = true;
                if (!sendOneTimeFilterEnve)
                {
                    DialTypeChangedInt(out _messageFilterEnvelope, oscAddreessFilterEnvelope, 1);

                    sendOneTimeFilterEnve = true;
                }
            }

            if (dragFilterEnv < 0.05f)
            {
                changedFilterEnv = false;
                if (sendOneTimeFilterEnve)
                {
                    DialTypeChangedInt(out _messageFilterEnvelope, oscAddreessFilterEnvelope, 0);
                    sendOneTimeFilterEnve = false;
                }
            }
        }

        public void PitchLfo(Single dragPitchLfo)
        {
            if (dragPitchLfo >= 0.05f)
            {
                changedPitchLfo = true;
                if (!sendOneTimePitchLfo)
                {
                    DialTypeChangedInt(out _messagePitchLfo, oscAddreessPitchLfo, 1);

                    sendOneTimePitchLfo = true;
                }
            }

            if (dragPitchLfo < 0.05f)
            {
                changedPitchLfo = false;
                if (sendOneTimePitchLfo)
                {
                    DialTypeChangedInt(out _messagePitchLfo, oscAddreessPitchLfo, 0);

                    sendOneTimePitchLfo = false;
                }
            }
        }

        public void FiltrLfo(Single dragFilterLfo)
        {
            if (dragFilterLfo >= 0.05f)
            {
                changedFilterLfo = true;
                if (!sendOneTimeFilterLfo)
                {
                    DialTypeChangedInt(out _messageFilterLfo, oscAddreessFilterLfo, 1);

                    sendOneTimeFilterLfo = true;
                }
            }

            if (dragFilterLfo < 0.05f)
            {
                changedFilterLfo = false;
                if (sendOneTimeFilterLfo)
                {
                    DialTypeChangedInt(out _messageFilterLfo, oscAddreessFilterLfo, 0);

                    sendOneTimeFilterLfo = false;
                }
            }
        }

        public void DistortionOnOff(Single dragDist)
        {
            if (dragDist >= 0.05f)
            {
                changedDistortion = true;
                if (!sendOneTimeDist)
                {
                    DialTypeChangedInt(out _messageDistDrag, oscAddressDistOnOff, 1);
                    sendOneTimeDist = true;
                }
            }

            if (dragDist < 0.05f)
            {
                changedDistortion = false;
                if (sendOneTimeDist)
                {
                    DialTypeChangedInt(out _messageDistDrag, oscAddressDistOnOff, 0);
                    sendOneTimeDist = false;
                }
            }
        }

        public void ReverbDrag(Single dragRev)
        {
            if (dragRev >= 0.05f)
            {
                changedReverb = true;
                if (!sendOneTimeRev)
                {
                    DialTypeChangedInt(out _messageRevDrag, oscAddressReverbOnOff, 1);
                    sendOneTimeRev = true;
                }
            }

            if (dragRev < 0.05f)
            {
                changedReverb = false;
                if (sendOneTimeRev)
                {
                    DialTypeChangedInt(out _messageRevDrag, oscAddressReverbOnOff, 0);

                    sendOneTimeRev = false;
                }
            }
        }
    }
}