using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OscCubeCoordinate : MonoBehaviour
{
    [SerializeField] private string cubeAdress;
    [SerializeField] private GameObject cubeObject;


    [Header("OSC Settings")] public OSCTransmitter Transmitter;

    // Update is called once per frame
    void Update()
    {
        SendingTransformCube(cubeAdress, cubeObject);
    }

    public void SendingTransformCube(string address, GameObject cube)
    {
        var message = new OSCMessage(address);
        message.AddValue(OSCValue.Float(cube.transform.position.x));
        message.AddValue(OSCValue.Float(cube.transform.position.y));
        message.AddValue(OSCValue.Float(cube.transform.position.z));
        Transmitter.Send(message);
    }
}