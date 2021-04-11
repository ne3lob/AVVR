using System;
using System.Collections;
using System.Collections.Generic;
using Synth;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class StartTheWalls : MonoBehaviour
{
    //PUBLIC

    public GameObject colomnReally;
    public VisualEffect[] myEffects;

    [Header("WallsMeshRender")] public MeshRenderer wallsObj;
    public MeshRenderer blackWallsObj;
    public MeshRenderer bottomCellingObj;

    [Header("MaterialsCircles")] public Material FirstCircleEnvironment;
    public Material SecondCircleEnvironment;

    private Material newMatWall;
    private Material newMatBlackWall;
    private Material newMatCelling;

    public GameObject synthObj;


    //PRIVATE 

    private Color newTranspWall;

    private float lerpDuration = 1000.0f;
    private bool lerpNow;
    private float lerpStart = 0;
    private bool lerpNowSecond;
    private float lerpStartSecond;

    private bool courOn = true;


    private SynthScript _synthScript;
    private float pitchValue;


    private bool one;
    private bool two;


    private float firstCurrentStrate = 13f;
    private float firstCurrentStateTwo = -24f;
    private float firstTargetStrateOne = -24f;
    private float firstTargetStrateTwo = 13f;


    private float secondCurrentStrate = -24f;
    private float secondCurrentStrateTwo = 13f;
    private float secondTargetStrateOne = 13f;
    private float secondTargetStrateTwo = -24f;


    float currentDiss = 0.93f;
    float targetDissNull = 0f;
    float targetDissOne = 0.93f;
    private float speed = 0.5f;

    private static readonly string SPAWN_RATE_NAME_A = "CapacityA";
    private static readonly string SPAWN_RATE_NAME_B = "CapacityB";
    private static readonly int _up = Shader.PropertyToID("Up");
    private const string _wallsShaderProp = "_Blend";
    private const string _wallsRestProp = "_Blend2";

    Coroutine colomnFallFirstCircleCoroutineNull;
    Coroutine colomnFallSecondCircleCoroutineNull;

    Coroutine colomnFallFirstCircleCoroutineOne;
    Coroutine colomnFallSecondCircleCoroutineOne;


    // Start is called before the first frame update
    void Start()
    {
        _synthScript = synthObj.GetComponent<SynthScript>();
        FirstCircleEnvironment.SetFloat("Up", 13f);
        SecondCircleEnvironment.SetFloat("Up", -24f);
    }

    // Update is called once per frame
    void Update()
    {
        pitchValue = _synthScript.s_PitchRatio;
        float stepSpeed = speed * Time.deltaTime;


        if (!one && pitchValue >= 0.1f)
        {
            lerpNow = true;
            lerpStart = Time.time;
            one = true;
        }

        if (!two && pitchValue >= 0.2f)
        {
            lerpNowSecond = true;
            lerpStartSecond = Time.time;
            two = true;
            courOn = true;
        }

        if (lerpNowSecond)
        {
            ColomnVfxMax();
            colomnReally.transform.position =
                Vector3.MoveTowards(colomnReally.transform.position, new Vector3(0, -5.65f, 0.08f), stepSpeed);
            //SECOND CIRCLE
            if (courOn)
            {
                var newProgress = Time.time - lerpStartSecond;
                firstCurrentStrate = Mathf.Lerp(firstCurrentStrate, firstTargetStrateOne, newProgress / lerpDuration);
                colomnFallFirstCircleCoroutineNull =
                    StartCoroutine(ColomnFallFirstCircle(FirstCircleEnvironment, firstCurrentStrate, 5));
                if (firstCurrentStateTwo >= -23.5f)
                {
                    StopCoroutine(colomnFallFirstCircleCoroutineNull);
                }


                secondCurrentStrate =
                    Mathf.Lerp(secondCurrentStrate, secondTargetStrateOne, newProgress / lerpDuration);
                colomnFallSecondCircleCoroutineNull =
                    StartCoroutine(ColomnFallFirstCircle(SecondCircleEnvironment, secondCurrentStrate, 10));
                if (firstCurrentStateTwo >= 12.5)
                {
                    StopCoroutine(colomnFallSecondCircleCoroutineNull);
                }
            }
        }

        if (lerpNow)

        {
            ChangeToTransparentLerp(wallsObj, _wallsShaderProp);
            ChangeToTransparentLerp(blackWallsObj, _wallsRestProp);
            ChangeToTransparentLerp(bottomCellingObj, _wallsShaderProp);
        }

        if (one && pitchValue <= 0.1)
        {
            one = false;
            lerpNow = false;
            lerpStart = Time.time;
        }

        if (two && pitchValue <= 0.2)
        {
            two = false;
            lerpNowSecond = false;
            lerpStartSecond = Time.time;
            courOn = false;
        }

        if (!lerpNowSecond)

        {
            ColomnVfxNull();
            colomnReally.transform.position =
                Vector3.MoveTowards(colomnReally.transform.position, new Vector3(0, -0.3f, 0.08f), stepSpeed);
            //SECOND CIRCLE
            if (!courOn)
            {
                
                
                
                var newProgressSecond = Time.time - lerpStartSecond;

                firstCurrentStateTwo = Mathf.Lerp(firstCurrentStateTwo, firstTargetStrateTwo,
                    newProgressSecond / lerpDuration);

                colomnFallFirstCircleCoroutineOne =
                    StartCoroutine(ColomnFallSecondCircle(FirstCircleEnvironment, firstCurrentStateTwo, 0));
                if (firstCurrentStateTwo >= 12.5f)
                {
                    StopCoroutine(colomnFallFirstCircleCoroutineOne);
                }


                secondCurrentStrateTwo =
                    Mathf.Lerp(secondCurrentStrateTwo, secondTargetStrateTwo, newProgressSecond / lerpDuration);
                colomnFallSecondCircleCoroutineOne =
                    StartCoroutine(ColomnFallSecondCircle(SecondCircleEnvironment, secondCurrentStrateTwo, 0));

                if (secondCurrentStrateTwo >= -23f)
                {
                    StopCoroutine(colomnFallSecondCircleCoroutineOne);
                }
            }
        }


        if (!lerpNow)

        {
            ChangeToNormalStationLerp(wallsObj, _wallsShaderProp);
            ChangeToNormalStationLerp(blackWallsObj, _wallsRestProp);
            ChangeToNormalStationLerp(bottomCellingObj, _wallsShaderProp);
        }
    }

    IEnumerator ColomnFallFirstCircle(Material circle, float valueUp, int delay_)
    {
        yield return new WaitForSeconds(delay_);
        circle.SetFloat("Up", valueUp);
        yield return null;
    }

    IEnumerator ColomnFallSecondCircle(Material circle, float valueUp, int delay_)
    {
        yield return new WaitForSeconds(delay_);
        circle.SetFloat("Up", valueUp);
        yield return null;
    }


    void ChangeToTransparentLerp(MeshRenderer obj, string prop)
    {
        var progress = Time.time - lerpStart;

        currentDiss = Mathf.Lerp(currentDiss, targetDissNull, progress / lerpDuration);

        obj.material.SetFloat(prop, currentDiss);
    }


    void ChangeToNormalStationLerp(MeshRenderer obj, string prop)
    {
        var progress = Time.time - lerpStart;

        currentDiss = Mathf.Lerp(currentDiss, targetDissOne, progress / lerpDuration);

        obj.material.SetFloat(prop, currentDiss);
    }

    void ColomnVfxNull()
    {
        var progressVfx = Time.time - lerpStartSecond;

        foreach (var effect in myEffects)
        {
            effect.SetFloat(SPAWN_RATE_NAME_A, 0);
            effect.SetFloat(SPAWN_RATE_NAME_B, 0);
        }

        if (lerpDuration < progressVfx)
        {
            lerpNowSecond = false;
        }
    }

    void ColomnVfxMax()
    {
        var progressVfx = Time.time - lerpStartSecond;

        foreach (var effect in myEffects)
        {
            effect.SetFloat(SPAWN_RATE_NAME_A, 20);
            effect.SetFloat(SPAWN_RATE_NAME_B, 30);
        }

        if (lerpDuration < progressVfx)
        {
            lerpNowSecond = false;
        }
    }
}