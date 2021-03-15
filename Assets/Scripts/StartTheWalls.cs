using System.Collections;
using System.Collections.Generic;
using Synth;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class StartTheWalls : MonoBehaviour
{
    [SerializeField] public GameObject wallsVfx;
    public VisualEffect myEffect;
    public static readonly string SPAWN_RATE_NAME = "SizeRate";

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

    private SynthScript _synthScript;
    private float pitchValue;
    public GameObject synthObj;

    private bool one = false;

    float currentDiss=0.93f;
    float targetDissNull=0f;
    float targetDissOne=0.93f;
    

    private const string _wallsShaderProp = "_Blend";
    private const string _wallsRestProp = "_Blend2";

    // Start is called before the first frame update
    void Start()
    {
        wallsVfx.SetActive(false);
        _synthScript = synthObj.GetComponent<SynthScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        pitchValue = _synthScript.s_PitchRatio;

        if (!one && pitchValue >= 0.1f)
        {
            wallsVfx.SetActive(true);

            lerpNow = true;
            lerpStart = Time.time;
            one = true;
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

        myEffect.SetFloat(SPAWN_RATE_NAME, 4000);

        if (lerpDuration < progress)
        {
            lerpNow = false;
        }
    }
    void ChangeToNormalStationLerp(MeshRenderer obj, string prop)
    {
        var progress = Time.time - lerpStart;

        currentDiss = Mathf.Lerp(currentDiss, targetDissOne, progress / lerpDuration);
        
        obj.material.SetFloat(prop, currentDiss);

        myEffect.SetFloat(SPAWN_RATE_NAME, 0);

        if (lerpDuration < progress)
        {
            lerpNow = false;
        }
    }
    
    
}