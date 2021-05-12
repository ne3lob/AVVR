using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using extOSC;

public class ShaderMoveBubbleKickTwo : MonoBehaviour
{
    private readonly string AddressDrumKickTwo = "/drumKickTwo";

    [Header("OSC Settings")] public OSCReceiver Receiver;
    private int bangDrumKlang;

    [FormerlySerializedAs("renderer")] public Renderer RendererKickTwo;
    MaterialPropertyBlock m_bubbleKickTwo;
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


    private bool drumKickTwo;


    private void ReceivedMessageDrumKickTwo(OSCMessage messageDrumKickTwo)
    {
        if (messageDrumKickTwo.ToInt(out var value))
        {
            drumKickTwo = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Receiver.Bind(AddressDrumKickTwo, ReceivedMessageDrumKickTwo);


        if (RendererKickTwo == null)
        {
            RendererKickTwo = GetComponent<Renderer>();
        }

        //  _shaderBubblesMovement = shaderBubbleScript.GetComponent<ShaderBubblesMovement>();

        m_BubblePannerID = Shader.PropertyToID("Panner");
        m_bubbleKickTwo = new MaterialPropertyBlock();
        m_PannerStartOne = -0.2f;
        m_bubbleKickTwo.SetFloat(m_BubblePannerID, m_PannerStartOne);
    }


    private float tDown;


    private void ChangingShaderValueKickTwo(ref bool toCheck)
    {
        tDown += Time.deltaTime;
        m_PannerEndTwo = Mathf.Lerp(m_PannerEndTwo, m_PannerStartTwo, tDown / durationBubbleTime);

        RendererKickTwo.GetPropertyBlock(m_bubbleKickTwo);
        m_bubbleKickTwo.SetFloat(m_BubblePannerID, m_PannerEndTwo);

        RendererKickTwo.SetPropertyBlock(m_bubbleKickTwo);

        if (tDown > durationBubbleTime)
        {
            tDown = 0;
            m_PannerEndTwo = 1.3f;
            toCheck = false;
        }
    }


    void Update()
    {
        if (drumKickTwo)
        {
            ChangingShaderValueKickTwo(ref drumKickTwo);
        }
    }
}