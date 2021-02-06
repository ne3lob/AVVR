using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    //public ParticleSystem[] SparkleFuseVFX;
    //public ParticleSystem[] SwitchedOnVFX;
    //public ParticleSystem[] SwitchedOffVFX;
    
    bool m_FusePresent = false;

    public void Switched(int step)
    {
        if (!m_FusePresent)
            return;

        if (step == 0)
        {
            //
        }
        else
        {
            //
        }
    }
    
    public void FuseSocketed(bool socketed)
    {
        m_FusePresent = socketed;

        if (m_FusePresent)
        {
           //
        }
    }
}
