using System.Collections;
using System.Collections.Generic;
using Synth;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class StartTheWalls : MonoBehaviour
{
    [SerializeField]
    public GameObject wallsVfx;
    public VisualEffect myEffect;
    public static readonly string SPAWN_RATE_NAME = "SizeRate";

    public MeshRenderer wallsObj;
    
    public MeshRenderer blackWallsObj;
    
    public MeshRenderer bottomCellingObj;
  
    
    private Material newMatWall;
    private Material newMatBlackWall;
    private Material newMatCelling;
    
    private Color newTranspWall;
    
    private float lerpDuration = 5.0f;
    private bool lerpNow = false;
    private float lerpStart = 0;

    private SynthScript _synthScript;
    private float pitchValue;
    public GameObject synthObj;

    private bool one=false;

    float currentDiss;
    float targetDiss;
    
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
        
        if (!one && pitchValue>=0.1f)
        { 
            print("Big");
            wallsVfx.SetActive(true);
            
            lerpNow = true;
            lerpStart = Time.time;
            one = true;
        }
        if (lerpNow) 
        
        {
            print("Da");
            ChangeToTransparentLerp(wallsObj);
            ChangeToTransparentLerp(blackWallsObj);
            ChangeToTransparentLerp(bottomCellingObj);
           
        }
        
        if (one && pitchValue <= 0.1)
        {
            print("Small");
            wallsVfx.SetActive(false);
            one = false;
        }
    }
    void ChangeToTransparentLerp(MeshRenderer obj)
    {
        var progress = Time.time - lerpStart;

        obj.material.SetFloat("_Blend",currentDiss);
        
        currentDiss = Mathf.Lerp(currentDiss, targetDiss, progress/lerpDuration);
        
        myEffect.SetFloat(SPAWN_RATE_NAME, 4000);
        
        if (lerpDuration < progress) 
        {
            lerpNow = false;
        }
        
    }

   
    
}
