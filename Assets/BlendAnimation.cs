using System.Collections;
using System.Collections.Generic;
using Synth;
using UnityEngine;

public class BlendAnimation : MonoBehaviour
{
    [SerializeField] private GameObject FirstCircle;
    [SerializeField] private GameObject SecondCircle;

    SkinnedMeshRenderer skinnedMeshRendererFirst;


    SkinnedMeshRenderer skinnedMeshRendererSecond;


    public GameObject synthObj;
    private SynthScript _synthScript;
    private float spaceValue;
    private float feedbackValue;
    private float blendValueFirst;
    private float blendValueSecond;
    private float lerpStart;

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

        //Feedback Value
        feedbackValue = _synthScript.s_DelayTimeFeedback;
        blendValueSecond = Mathf.Lerp(blendValueSecond, feedbackValue * 100f, (Time.time - lerpStart) / 4000f);
        skinnedMeshRendererSecond.SetBlendShapeWeight(0, blendValueSecond);
    }
}