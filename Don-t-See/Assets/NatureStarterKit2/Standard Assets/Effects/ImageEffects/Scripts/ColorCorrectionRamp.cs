<<<<<<< HEAD
using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Color Correction (Ramp)")]
    public class ColorCorrectionRamp : ImageEffectBase {
        public Texture  textureRamp;

        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination) {
            material.SetTexture ("_RampTex", textureRamp);
            Graphics.Blit (source, destination, material);
        }
    }
}
=======
using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Color Correction (Ramp)")]
    public class ColorCorrectionRamp : ImageEffectBase {
        public Texture  textureRamp;

        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination) {
            material.SetTexture ("_RampTex", textureRamp);
            Graphics.Blit (source, destination, material);
        }
    }
}
>>>>>>> a9fc26ff37d54631fb504f4b8c0c946830e7c50e
