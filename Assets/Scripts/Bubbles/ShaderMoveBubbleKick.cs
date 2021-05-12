using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using extOSC;

public class ShaderMoveBubbleKick : MonoBehaviour
{
    private readonly string AddressDrumKick = "/drumKick";


    [Header("OSC Settings")] public OSCReceiver Receiver;
    private int bangDrumKlang;

    [FormerlySerializedAs("renderer")] public Renderer RendererKickFirst;
    MaterialPropertyBlock m_bubbleKickFirst;
    int m_BubblePannerID;


    float m_PannerStartOne = -0.2f;
    float m_PannerEndOne = 1.3f;

    float m_PannerStartTwo = -0.2f;
    float m_PannerEndTwo = 1.3f;


    public float durationBubbleTime;
    private bool _start = true;
    private bool moveBubbleUp;
    private bool moveBubbleDown;


    private bool drumKick;


    private void ReceivedMessageDrumKick(OSCMessage messageDrumKick)
    {
        if (messageDrumKick.ToInt(out var value))
        {
            drumKick = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Receiver.Bind(AddressDrumKick, ReceivedMessageDrumKick);


        if (RendererKickFirst == null)
        {
            RendererKickFirst = GetComponent<Renderer>();
        }

        //  _shaderBubblesMovement = shaderBubbleScript.GetComponent<ShaderBubblesMovement>();

        m_BubblePannerID = Shader.PropertyToID("Panner");
        m_bubbleKickFirst = new MaterialPropertyBlock();
        m_PannerStartOne = -0.2f;
        m_bubbleKickFirst.SetFloat(m_BubblePannerID, m_PannerStartOne);
    }

    private float tDown;


    private void ChangingShaderValueKickFirst(ref bool toCheck)
    {
        tDown += Time.deltaTime;
        m_PannerEndTwo = Mathf.Lerp(m_PannerEndTwo, m_PannerStartTwo, tDown / durationBubbleTime);

        RendererKickFirst.GetPropertyBlock(m_bubbleKickFirst);
        m_bubbleKickFirst.SetFloat(m_BubblePannerID, m_PannerEndTwo);

        RendererKickFirst.SetPropertyBlock(m_bubbleKickFirst);

        if (tDown > durationBubbleTime)
        {
            tDown = 0;
            m_PannerEndTwo = 1.3f;
            toCheck = false;
        }
    }


    void Update()
    {
        if (drumKick)
        {
            ChangingShaderValueKickFirst(ref drumKick);
        }
    }
}