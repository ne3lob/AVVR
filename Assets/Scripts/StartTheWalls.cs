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


    public Material cubeM;
    public Material bubblesM;
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


    private float structureOff = 0.2f;
    private float structureOn = 1.3f;
    private float structureOffTwo = 0.2f;
    private float structureOnTwo = 1.3f;


    private float lightOn = 20;
    private float lightOnTwo = 20;

    private float lightOff = 0;
    private float lightOffTwo = 0;


    float currentDiss = 0.93f;
    float targetDissNull = 0f;
    float targetDissOne = 0.93f;
    private float speed = 0.5f;

    private static readonly string SPAWN_RATE_NAME_A = "CapacityA";
    private static readonly string SPAWN_RATE_NAME_B = "CapacityB";
    private static readonly int _up = Shader.PropertyToID("Up");
    private const string _wallsShaderProp = "_Blend";
    private const string _wallsRestProp = "_Blend2";

    [SerializeField] private GameObject Structur;
    [SerializeField] private Light[] LightStructur;

    // Start is called before the first frame update
    void Start()
    {
        _synthScript = synthObj.GetComponent<SynthScript>();
        FirstCircleEnvironment.SetFloat("Up", 13f);

        cubeM.SetFloat("Visible", 0.2f);
        //bubblesM.SetFloat("Visible", 0.2f);

        foreach (var light in LightStructur)
        {
            light.range = 0f;
        }
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
                CircleFirstOn(FirstCircleEnvironment, 1500f);
                VisibleStructur(cubeM, bubblesM, 40f);
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
            firstCurrentStrate = 13f;
            firstCurrentStateTwo = -24f;

            structureOff = 0.2f;
            structureOn = 1.3f;

            structureOffTwo = 0.2f;
            structureOnTwo = 1.3f;

            lightOff = 0f;
            lightOffTwo = 0f;
            lightOn = 20f;
            lightOnTwo = 20f;
        }

        if (!lerpNowSecond)

        {
            ColomnVfxNull();
            colomnReally.transform.position =
                Vector3.MoveTowards(colomnReally.transform.position, new Vector3(0, -0.3f, 0.08f), stepSpeed);
            //SECOND CIRCLE
            if (!courOn)
            {
                CircleFirstOff(FirstCircleEnvironment, 1000f);
                NoVisibleStructur(cubeM, bubblesM, 40f);
            }
        }


        if (!lerpNow)

        {
            ChangeToNormalStationLerp(wallsObj, _wallsShaderProp);
            ChangeToNormalStationLerp(blackWallsObj, _wallsRestProp);
            ChangeToNormalStationLerp(bottomCellingObj, _wallsShaderProp);
        }
    }


    void CircleFirstOn(Material circle, float durationOn)
    {
        var newProgress = Time.time - lerpStartSecond;

        firstCurrentStrate = Mathf.Lerp(firstCurrentStrate, firstTargetStrateOne, newProgress / durationOn);
        circle.SetFloat("Up", firstCurrentStrate);
    }


    void CircleFirstOff(Material circle, float durationOn)
    {
        var newProgressTwo = Time.time - lerpStartSecond;

        firstCurrentStateTwo = Mathf.Lerp(firstCurrentStateTwo, firstTargetStrateTwo,
            newProgressTwo / durationOn);
        circle.SetFloat("Up", firstCurrentStateTwo);
    }


    void VisibleStructur(Material cubeMat, Material bubblesMat, float durationStruct)
    {
        var newProgressStruct = Time.time - lerpStartSecond;

        structureOff = Mathf.Lerp(structureOff, structureOn, newProgressStruct / durationStruct);

        cubeMat.SetFloat("Visible", structureOff);
        bubblesMat.SetFloat("Visible", structureOff);

        foreach (var light in LightStructur)
        {
            lightOff = Mathf.Lerp(lightOff, lightOn, newProgressStruct / durationStruct);
            light.range = lightOff;
        }
    }

    void NoVisibleStructur(Material cubeMat, Material bubblesMat, float durationStruct)
    {
        var newProgressStruct = Time.time - lerpStartSecond;

        structureOnTwo = Mathf.Lerp(structureOnTwo, structureOffTwo, newProgressStruct / durationStruct);

        cubeMat.SetFloat("Visible", structureOnTwo);
        bubblesMat.SetFloat("Visible", structureOnTwo);

        foreach (var light in LightStructur)
        {
            lightOnTwo = Mathf.Lerp(lightOnTwo, lightOffTwo, newProgressStruct / durationStruct);
            light.range = lightOnTwo;
        }
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