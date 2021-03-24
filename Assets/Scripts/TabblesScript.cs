using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class TabblesScript : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>(8);

    public Material notSelected;

    private SyntHTable inputScript;

    private bool isPressed;

    private void Start()
    {
        inputScript = GameObject.Find("======== VR MANAGMENT ========").GetComponent<SyntHTable>();
    }

    private float grip;

    private void Update()
    {
       
    }

    public void ChangeTheColor(Material change)
    {
        foreach (var cubesMaterial in cubes)
        {
            cubesMaterial.GetComponent<MeshRenderer>().material = notSelected;
            
        }
        this.gameObject.GetComponent<MeshRenderer>().material = change;
    }
    
}