using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TabblesScript : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;

    //MATERIAL 
    [FormerlySerializedAs("renderer")] public Renderer _renderer;

    float activeTabble = 0.0f;
    MaterialPropertyBlock t_Block;
    int t_activeTabbleID;


    // Start is called before the first frame update
    void Start()
    {
        if (_renderer == null)
        {
            _renderer = GetComponent<Renderer>();
        }
        
       

        t_activeTabbleID = Shader.PropertyToID("ActiveTabble");
        t_Block = new MaterialPropertyBlock();
        t_Block.SetFloat(t_activeTabbleID, activeTabble);
        _renderer.SetPropertyBlock(t_Block);
    }

    public void SelectTheCube()
    {
        switch (activeTabble)
        {
            case 0.0f:
                CheckActiveMaterial(1.0f);
                activeTabble = 1.0f;
                break;

            case 1.0f:
                CheckActiveMaterial(0.0f);
                activeTabble = 0.0f;
                break;
        }

        Debug.Log(activeTabble);
    }


    private void CheckActiveMaterial(float onOff)
    {
        _renderer.GetPropertyBlock(t_Block);
        t_Block.SetFloat(t_activeTabbleID, onOff);
        _renderer.SetPropertyBlock(t_Block);
    }
}