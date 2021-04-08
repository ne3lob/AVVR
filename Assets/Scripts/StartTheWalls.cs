using System;
using System.Collections;
using System.Collections.Generic;
using Synth;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class StartTheWalls : MonoBehaviour
{
    public GameObject colomnReally;
    public VisualEffect[] myEffects;
    public static readonly string SPAWN_RATE_NAME_A = "CapacityA";
    public static readonly string SPAWN_RATE_NAME_B = "CapacityB";

    public MeshRenderer wallsObj;

    public MeshRenderer blackWallsObj;

    public MeshRenderer bottomCellingObj;


    private Material newMatWall;
    private Material newMatBlackWall;
    private Material newMatCelling;

    private Color newTranspWall;

    private float lerpDuration = 1000.0f;
    private bool lerpNow = false;
    private float lerpStart = 0;
    private bool lerpNowSecond;
    private float lerpStartSecond;

    private SynthScript _synthScript;
    private float pitchValue;
    public GameObject synthObj;

    private bool one = false;
    private bool two = false;


    float currentDiss = 0.93f;
    float targetDissNull = 0f;
    float targetDissOne = 0.93f;
    private float speed = 0.5f;


    private const string _wallsShaderProp = "_Blend";
    private const string _wallsRestProp = "_Blend2";

    // Start is called before the first frame update
    void Start()
    {
        //  wallsVfx.SetActive(false);
        _synthScript = synthObj.GetComponent<SynthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        pitchValue = _synthScript.s_PitchRatio;
        float step = speed * Time.deltaTime;

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
        }

        if (lerpNowSecond)
        {
            ColomnVfxMax();

            colomnReally.transform.position =
                Vector3.MoveTowards(colomnReally.transform.position, new Vector3(0, -5.65f, 0.08f), step);
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
        }

        if (!lerpNowSecond)

        {
            ColomnVfxNull();
            colomnReally.transform.position =
                Vector3.MoveTowards(colomnReally.transform.position, new Vector3(0, -0.3f, 0.08f), step);
        }


        if (!lerpNow)

        {
            ChangeToNormalStationLerp(wallsObj, _wallsShaderProp);
            ChangeToNormalStationLerp(blackWallsObj, _wallsRestProp);
            ChangeToNormalStationLerp(bottomCellingObj, _wallsShaderProp);
        }
    }

    void ChangeToTransparentLerp(MeshRenderer obj, string prop)
    {
        var progress = Time.time - lerpStart;

        currentDiss = Mathf.Lerp(currentDiss, targetDissNull, progress / lerpDuration);

        obj.material.SetFloat(prop, currentDiss);

        // myEffect.SetFloat(SPAWN_RATE_NAME, 4000);
        //
        // if (lerpDuration < progress)
        // {
        //     lerpNow = false;
        // }
    }

    void ChangeToNormalStationLerp(MeshRenderer obj, string prop)
    {
        var progress = Time.time - lerpStart;

        currentDiss = Mathf.Lerp(currentDiss, targetDissOne, progress / lerpDuration);

        obj.material.SetFloat(prop, currentDiss);

        // myEffect.SetFloat(SPAWN_RATE_NAME, 0);
        //
        // if (lerpDuration < progress)
        // {
        //     lerpNow = false;
        // }
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