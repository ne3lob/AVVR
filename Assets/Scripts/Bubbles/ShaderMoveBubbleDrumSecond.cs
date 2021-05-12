using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using extOSC;

public class ShaderMoveBubbleDrumSecond : MonoBehaviour
{
    private readonly string AddressDrumSecond = "/drumSecond";


    [Header("OSC Settings")] public OSCReceiver Receiver;


    [FormerlySerializedAs("renderer")] public Renderer RendererDrumSecond;
    MaterialPropertyBlock m_bubbleDrumSecond;
    int m_BubblePannerID;


    float m_PannerStartOne = -0.2f;
    float m_PannerEndOne = 1.3f;

    float m_PannerStartTwo = -0.2f;
    float m_PannerEndTwo = 1.3f;


    public float durationBubbleTime;
    private bool _start = true;
    private bool moveBubbleUp;
    private bool moveBubbleDown;


    private bool drumSecond;


    private void ReceivedMessageDrumSecond(OSCMessage messageDrumSecond)
    {
        if (messageDrumSecond.ToInt(out var value))
        {
            drumSecond = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Receiver.Bind(AddressDrumSecond, ReceivedMessageDrumSecond);


        if (RendererDrumSecond == null)
        {
            RendererDrumSecond = GetComponent<Renderer>();
        }


        m_BubblePannerID = Shader.PropertyToID("Panner");
        m_bubbleDrumSecond = new MaterialPropertyBlock();
        m_PannerStartOne = -0.2f;
        m_bubbleDrumSecond.SetFloat(m_BubblePannerID, m_PannerStartOne);
    }


    private float tUp;

    private void ChangingShaderValueDrumSecond(ref bool toCheck)
    {
        tUp += Time.deltaTime;
        m_PannerStartOne = Mathf.Lerp(m_PannerStartOne, m_PannerEndOne, tUp / durationBubbleTime);

        RendererDrumSecond.GetPropertyBlock(m_bubbleDrumSecond);
        m_bubbleDrumSecond.SetFloat(m_BubblePannerID, m_PannerStartOne);

        RendererDrumSecond.SetPropertyBlock(m_bubbleDrumSecond);

        if (tUp > durationBubbleTime)
        {
            tUp = 0;
            m_PannerStartOne = 0f;
            toCheck = false;
        }
    }

    void Update()
    {
        if (drumSecond)
        {
            ChangingShaderValueDrumSecond(ref drumSecond);
        }
    }
}