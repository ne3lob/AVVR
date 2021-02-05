using System.Collections;
using System.Collections.Generic;
using extOSC;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public OSCReceiver camReceiver;
    
    private const string oscAddress = "/cam";
   public Transform target;
   
   private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        camReceiver.Bind(oscAddress, ReceivedMessage);
        
        targetPos= target.transform.position;//get target's coords
        transform.LookAt(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        //   transform.RotateAround (targetPos,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime );
    }

    private void ReceivedMessage(OSCMessage message)
    {
        var cam = message.Values[0].FloatValue;

        transform.RotateAround (targetPos,new Vector3(0.0f,1.0f,0.0f),70 * Time.deltaTime * cam*500f );
    }
}
