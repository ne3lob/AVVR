using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class StartTheWalls : MonoBehaviour
{
    [SerializeField]
    public GameObject wallsVfx;
    public VisualEffect myEffect;
    public static readonly string SPAWN_RATE_NAME = "SizeRate";

    public GameObject wallsObj;
    public Material wallsObjTransparent;
    
    public GameObject blackWallsObj;
    public Material blackWallsObjTransparent;
    
    private Material newMatWall;
    private Material newMatBlackWall;
    private Color newTranspWall;
    
    private float lerpDuration = 5.0f;
    private bool lerpNow = false;
    private float lerpStart = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        wallsVfx.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.A))
        { 
            print("a");
            wallsVfx.SetActive(true);
            
            newMatWall= wallsObjTransparent;
            wallsObj.GetComponent<MeshRenderer>().material = newMatWall;
            
            newMatBlackWall= blackWallsObjTransparent;
            blackWallsObj.GetComponent<MeshRenderer>().material = newMatWall;
            
            
            lerpNow = true;
            lerpStart = Time.time;
        }
        if (lerpNow) 
        {
            ChangeToTransparentLerp(wallsObj);
            ChangeToTransparentLerp(blackWallsObj);
            
        }
    }
    void ChangeToTransparentLerp(GameObject obj)
    {
        var progress = Time.time - lerpStart;
        Color colorOq = obj.GetComponent<MeshRenderer>().material.color ;
        colorOq.a = 1;
            
        Color colorTra = obj.GetComponent<MeshRenderer>().material.color ;
        colorTra.a = 0;
        
        newTranspWall = Color.Lerp(colorOq, colorTra, progress/lerpDuration);
        obj.GetComponent<MeshRenderer>().material.color = newTranspWall;
        
        myEffect.SetFloat(SPAWN_RATE_NAME, 3500);
        
        if (lerpDuration < progress) 
        {
            lerpNow = false;
        }
    }
}
