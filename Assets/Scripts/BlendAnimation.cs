using System.Collections;
using System.Collections.Generic;
using Synth;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BlendAnimation : MonoBehaviour
{
    #region Blendshapes

    [SerializeField] private GameObject FirstCircle;
    [SerializeField] private GameObject SecondCircle;


    SkinnedMeshRenderer skinnedMeshRendererFirst;

    SkinnedMeshRenderer skinnedMeshRendererSecond;

    [SerializeField] private GameObject synthObj;
    private SynthScript _synthScript;
    private float spaceValue;
    private float feedbackValue;
    private float blendValueFirst;
    private float blendValueSecond;
    private float lerpStart;

    #endregion

    [SerializeField] private GameObject wall1_z;
    [SerializeField] private GameObject wall2_z;

    [SerializeField] private GameObject wall1_x;
    [SerializeField] private GameObject wall2_x;

    [SerializeField] private GameObject celling;


    // Start is called before the first frame update
    void Start()
    {
        _synthScript = synthObj.GetComponent<SynthScript>();
        skinnedMeshRendererFirst = FirstCircle.GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRendererSecond = SecondCircle.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Space Value
        spaceValue = _synthScript.s_ReverbSpace;
        blendValueFirst = Mathf.Lerp(blendValueFirst, spaceValue * 100f, (Time.time - lerpStart) / 4000f);
        skinnedMeshRendererFirst.SetBlendShapeWeight(0, blendValueFirst);


        // maxFloat_centerCollider = Mathf.Clamp(spaceValue * 10, 0f, 6f);
        // MCollider.center = new Vector3(MCollider.center.x, MCollider.center.y, maxFloat_centerCollider);


        //Feedback Value
        feedbackValue = _synthScript.s_DelayTimeFeedback;
        blendValueSecond = Mathf.Lerp(blendValueSecond, feedbackValue * 100f, (Time.time - lerpStart) / 4000f);
        skinnedMeshRendererSecond.SetBlendShapeWeight(0, blendValueSecond);
    }
}