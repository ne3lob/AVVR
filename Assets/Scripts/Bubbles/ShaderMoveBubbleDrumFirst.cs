using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using extOSC;

public class ShaderMoveBubbleDrumFirst : MonoBehaviour
{
    private readonly string AddressDrumFirst = "/drumFirst";


    [Header("OSC Settings")] public OSCReceiver Receiver;

    [FormerlySerializedAs("renderer")] public Renderer RendererDrumFirst;
    MaterialPropertyBlock m_bubbleDrumFirst;
    int m_BubblePannerID;


    [HideInInspector] public float lerpStart;


    float m_PannerStartOne = -0.2f;
    float m_PannerEndOne = 1.3f;

    float m_PannerStartTwo = -0.2f;
    float m_PannerEndTwo = 1.3f;


    public float durationBubbleTime;
    private bool _start = true;
    private bool moveBubbleUp;
    private bool moveBubbleDown;

    private bool drumFirst;


    private void ReceivedMessageDrumFirst(OSCMessage messageDrumFirst)
    {
        if (messageDrumFirst.ToInt(out var value))
        {
            drumFirst = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Receiver.Bind(AddressDrumFirst, ReceivedMessageDrumFirst);


        if (RendererDrumFirst == null)
        {
            RendererDrumFirst = GetComponent<Renderer>();
        }


        m_BubblePannerID = Shader.PropertyToID("Panner");
        m_bubbleDrumFirst = new MaterialPropertyBlock();
        m_PannerStartOne = -0.2f;
        m_bubbleDrumFirst.SetFloat(m_BubblePannerID, m_PannerStartOne);
    }


    private float tDown;


    private void ChangingShaderValueDrumFirst(ref bool toCheck)
    {
        tDown += Time.deltaTime;
        m_PannerEndTwo = Mathf.Lerp(m_PannerEndTwo, m_PannerStartTwo, tDown / durationBubbleTime);

        RendererDrumFirst.GetPropertyBlock(m_bubbleDrumFirst);
        m_bubbleDrumFirst.SetFloat(m_BubblePannerID, m_PannerEndTwo);

        RendererDrumFirst.SetPropertyBlock(m_bubbleDrumFirst);

        if (tDown > durationBubbleTime)
        {
            tDown = 0;
            m_PannerEndTwo = 1.3f;
            toCheck = false;
        }
    }


    void Update()
    {
        if (drumFirst)
        {
            ChangingShaderValueDrumFirst(ref drumFirst);
        }
    }
}