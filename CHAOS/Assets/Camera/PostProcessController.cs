using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessController : MonoBehaviour
{
    private VolumeProfile prof;
    private LensDistortion lensDist;
    private ChromaticAberration chromAb;

    private void Start()
    {
        prof = GetComponent<Volume>().profile;

        prof.TryGet<LensDistortion>(out lensDist);
        prof.TryGet<ChromaticAberration>(out chromAb);
    }

    public void SetLensDistortion(float val)
    {
        lensDist.intensity.value = val;
    }

    public void SetChromaticAb(float val)
    {
        chromAb.intensity.value = val;
    }
}
