using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class WavesScript : MonoBehaviour
{
    public XRExclusiveSocketInteractor socketInteractor;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    //SAW
    public void SocketSawIn(XRBaseInteractable interactable)
    {
        Debug.Log("SawIn");
    }
    public void SocketSawOut(XRBaseInteractable interactable)
    {
        Debug.Log("SawOut");
    }
    //RECT
    public void SocketRectIn(XRBaseInteractable interactable)
    {
        Debug.Log("RectOut");
    }
    public void SocketRectOut(XRBaseInteractable interactable)
    {
        Debug.Log("RectOut");
    }
    //TRI
    public void SocketTriIn(XRBaseInteractable interactable)
    {
        Debug.Log("TriOut");
    }
    public void SocketTriOut(XRBaseInteractable interactable)
    {
        Debug.Log("TriOut");
    }
    //SIN
    public void SocketSinIn(XRBaseInteractable interactable)
    {
        Debug.Log("SinOut");
    }
    public void SocketSinOut(XRBaseInteractable interactable)
    {
        Debug.Log("SinOut");
    }
    //NOISE
    public void SocketNoiseIn(XRBaseInteractable interactable)
    {
        Debug.Log("NoiseOut");
    }
    public void SocketNoiseOut(XRBaseInteractable interactable)
    {
        Debug.Log("NoiseOut");
    }
    
    
}
