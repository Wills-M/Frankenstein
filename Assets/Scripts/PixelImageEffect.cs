﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PixelImageEffect : MonoBehaviour
{

    [SerializeField]
    public Material imageEffectMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, imageEffectMaterial);
    }

}
