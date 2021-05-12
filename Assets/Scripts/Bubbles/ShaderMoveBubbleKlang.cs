using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using extOSC;

public class ShaderMoveBubbleKlang : MonoBehaviour
{
    private readonly string AddressDrumKlangForBubbles = "/drumKlang";


    [Header("OSC Settings")] public OSCReceiver Receiver;
    private int bangDrumKlang;

    [FormerlySerializedAs("renderer")] public Renderer RendererKlang;
    MaterialPropertyBlock m_bubbleKlang;
    int m_BubblePannerID;


    float m_PannerStartOne = -0.2f;
    float m_PannerEndOne = 1.3f;

    float m_PannerStartTwo = -0.2f;
    float m_PannerEndTwo = 1.3f;


    public float durationBubbleTime;
    private bool _start = true;
    private bool moveBubbleUp;
    private bool moveBubbleDown;


    private bool drumKlang;


    private void ReceivedMessageDrumKlang(OSCMessage messageKangDrum)
    {
        if (messageKangDrum.ToInt(out var value))
        {
            drumKlang = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Receiver.Bind(AddressDrumKlangForBubbles, ReceivedMessageDrumKlang);


        if (RendererKlang == null)
        {
            RendererKlang = GetComponent<Renderer>();
        }


        m_BubblePannerID = Shader.PropertyToID("Panner");
        m_bubbleKlang = new MaterialPropertyBlock();
        m_PannerStartOne = -0.2f;
        m_bubbleKlang.SetFloat(m_BubblePannerID, m_PannerStartOne);
    }


    private float tUp;

    private void ChangingShaderValueKlang(ref bool toCheck)
    {
        tUp += Time.deltaTime;
        m_PannerStartOne = Mathf.Lerp(m_PannerStartOne, m_PannerEndOne, tUp / durationBubbleTime);

        RendererKlang.GetPropertyBlock(m_bubbleKlang);
        m_bubbleKlang.SetFloat(m_BubblePannerID, m_PannerStartOne);

        RendererKlang.SetPropertyBlock(m_bubbleKlang);

        if (tUp >= durationBubbleTime)
        {
            tUp = 0;
            m_PannerStartOne = 0f;
            toCheck = false;
        }
    }


    void Update()
    {
        if (drumKlang)
        {
            ChangingShaderValueKlang(ref drumKlang);
        }
    }
}