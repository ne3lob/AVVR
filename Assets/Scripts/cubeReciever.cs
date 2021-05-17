using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class cubeReciever : MonoBehaviour
{
    public OSCReceiver cubeReceiver;

    private const string oscAddress = "/cube";

    private float x_go;
    private float y_go;
    private float lerpStart;

    // Start is called before the first frame update
    void Start()
    {
        cubeReceiver.Bind(oscAddress, ReceivedMessageOne);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void ReceivedMessageOne(OSCMessage message)
    {
        var cube = message.Values[0].FloatValue;
        x_go = Mathf.Lerp(x_go, cube, (Time.time - lerpStart) / 100f);

        var cube2 = message.Values[1].FloatValue;
        y_go = Mathf.Lerp(y_go, cube2, (Time.time - lerpStart) / 100f);


        this.transform.localPosition = new Vector3(x_go, y_go, Random.Range(x_go, y_go));
    }
}