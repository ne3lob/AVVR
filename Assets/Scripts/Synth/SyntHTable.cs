using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using List = System.Collections.Generic.List<int>;

public class SyntHTable : MonoBehaviour
{
    private InputDevice device;

    private List<InputDevice> rightDevices = new List<InputDevice>
    {
        new InputDevice()
    };

    private List<InputDevice> leftDevices = new List<InputDevice>
    {
        new InputDevice()
    };

    public GameObject synth;
    public bool IsPressed { get; private set; }

    public float speedTurn;
    private bool fors;
    private bool state;
    private MeshRenderer m;

    private InputDevice rightDevice;
    private InputDevice leftDevice;

    [SerializeField] private List<MeshRenderer> cabelsMeshes;
    private Vector2 currentStateValue = Vector2.zero;

    public float _speedOnOff;


    // Start is called before the first frame update
    void Start()
    {
        rightDevices.Clear();
        leftDevices.Clear();
        synth.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, rightDevices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, leftDevices);

        if (rightDevices.Count == 1)
        {
            rightDevice = rightDevices[0];
        }

        if (leftDevices.Count == 1)
        {
            leftDevice = leftDevices[0];
        }

        if (rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out fors) && fors)
        {
            if (!IsPressed)
            {
                IsPressed = true;
                synth.SetActive(!synth.activeSelf);

                for (int i = 0; i < cabelsMeshes.Count; i++)
                {
                    MeshRenderer cabelMesh = cabelsMeshes[i];

                    if (cabelMesh.enabled)
                    {
                        cabelMesh.enabled = false;
                    }
                    else if (!cabelMesh.enabled)
                    {
                        cabelMesh.enabled = true;
                    }
                }
            }
        }

        else if (IsPressed)
        {
            IsPressed = false;
        }

        InputFeatureUsage<Vector2> currentState = CommonUsages.primary2DAxis;


        if (leftDevice.TryGetFeatureValue(currentState, out currentStateValue) && currentStateValue != Vector2.zero)
        {
            speedTurn = currentStateValue.x * _speedOnOff;
        }


        if (rightDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool trigger) && trigger)
        {
            _speedOnOff = 0f;
        }
        else
        {
            _speedOnOff = 40f;
        }
    }
}