using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;

public class BestQuality : MonoBehaviour {
    void Start () {
        XRSettings.eyeTextureResolutionScale = 1.5f;
    }
}