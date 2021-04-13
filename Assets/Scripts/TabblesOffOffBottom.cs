using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TabblesOffOffBottom : MonoBehaviour
{
    public List<GameObject> tabbles = new List<GameObject>(3);

    private void Start()
    {
        foreach (var tabble in tabbles)
        {
            tabble.SetActive(false);
        }
    }


    public void CheckEnabling(GameObject thisTabble)
    {
        foreach (var tabble in tabbles)
        {
            tabble.SetActive(false);
        }

        thisTabble.SetActive(true);
    }

    public void Off()
    {
        foreach (var tabble in tabbles)
        {
            tabble.SetActive(false);
        }
    }
}