using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;

public class VFXSwitch : MonoBehaviour
{
    [SerializeField] private UniversalRendererData _universalRendererData;

    private KeyCode keyPressed;
    // Update is called once per frame
    void Update()
    {
 
    }
    public void SwitchPP(int Number)
    {
        _universalRendererData.rendererFeatures[Number].SetActive(!_universalRendererData.rendererFeatures[Number].isActive);
    }



    public void ToggleParticle(VisualEffect particleSystem)
    {
        
    }
}
