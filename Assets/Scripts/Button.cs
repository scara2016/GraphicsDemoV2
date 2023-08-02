using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class Button : MonoBehaviour
{
    private VFXSwitch VFXSwitch;

    enum Type
    {
        PP,
        ParticleEffect,
    }
    [SerializeField]
    private int shaderNumber;

    private Material buttonMaterial;
    private bool On = false;
    [SerializeField] private VisualEffect _visualEffect;
    [SerializeField] private Material _material;
    [SerializeField] private String propertyName;
    [SerializeField] private int Min;
    [SerializeField] private int Max;
    [SerializeField] private Type vfxType;
    private float sliderValue;
    private StarterAssetsInputs _starterAssetsInputs;
    private void Awake()
    {
        VFXSwitch = FindObjectOfType<VFXSwitch>();
        _starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>();
        sliderValue = Min;
        buttonMaterial = GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        _starterAssetsInputs.ValueChange+=(ValueChangeShader);
    }

    private void OnDisable()
    {
        _starterAssetsInputs.ValueChange-=(ValueChangeShader);
    }

    public void MouseDown()
    {
        On = !On;
        if (On)
        {
            buttonMaterial.color = Color.green;
        }
        else
        {
            buttonMaterial.color = Color.red;
        }
        if (vfxType == Type.PP)
        {
            VFXSwitch.SwitchPP(shaderNumber);
        }

        if (vfxType == Type.ParticleEffect)
        {
            VFXSwitch.ToggleParticle(_visualEffect);
        }
    }

    private void ValueChangeShader(InputValue inputValue)
    {
        if (vfxType == Type.PP && _material!=null)
        {
            sliderValue += inputValue.Get<float>();
            sliderValue = Mathf.Clamp(sliderValue, Min, Max);
            _material.SetFloat(propertyName, sliderValue);

        }
    }
}
