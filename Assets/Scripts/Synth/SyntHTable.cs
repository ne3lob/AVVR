using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SyntHTable : MonoBehaviour
{
    [SerializeField] 
    private XRNode xrNode = XRNode.RightHand;
    private XRNode xrNodeL = XRNode.LeftHand;
    
    private InputDevice device;
    private List<InputDevice> rightDevice= new List<InputDevice>();
    private List<InputDevice> leftDevice= new List<InputDevice>();
    
    public GameObject synth;
    private InputFeatureUsage<bool> inputFeature;
    public bool IsPressed { get; private set; }
    
    public float speedTurn; 
    private bool fors;
    private bool state;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithRole(InputDeviceRole.RightHanded,rightDevice);
        InputDevices.GetDevicesWithRole(InputDeviceRole.LeftHanded,leftDevice);
        
        if (rightDevice.Count >= 1)
        {
            if (rightDevice[0].TryGetFeatureValue(CommonUsages.primaryButton, out fors) && fors)
            {
                if (!IsPressed)
                {
                    IsPressed = true;
                    synth.SetActive(!synth.activeSelf);
                }
            }
            else if (IsPressed)
            {
                    IsPressed = false;
            }
        }
        Vector2 currentStateValue=Vector2.zero;
        InputFeatureUsage<Vector2> currentState = CommonUsages.primary2DAxis;
        
        if (leftDevice[0].TryGetFeatureValue(currentState, out currentStateValue) && currentStateValue != Vector2.zero)
        { 
            speedTurn = currentStateValue.x * 40;
        }
    }
    
}
