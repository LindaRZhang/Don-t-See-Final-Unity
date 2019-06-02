<<<<<<< HEAD
using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Sepia Tone")]
    public class SepiaTone : ImageEffectBase
	{
        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination)
		{
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
    [AddComponentMenu("Image Effects/Color Adjustments/Sepia Tone")]
    public class SepiaTone : ImageEffectBase
	{
        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination)
		{
            Graphics.Blit (source, destination, material);
        }
    }
}
>>>>>>> a9fc26ff37d54631fb504f4b8c0c946830e7c50e
