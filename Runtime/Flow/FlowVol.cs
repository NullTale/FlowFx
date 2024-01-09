using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

//  FlowFx © NullTale - https://twitter.com/NullTale/
namespace VolFx
{
    [Serializable, VolumeComponentMenu("VolFx/Flow")]
    public sealed class FlowVol : VolumeComponent, IPostProcessComponent
    {
        public ClampedFloatParameter m_Fade   = new ClampedFloatParameter(0, 0, 1, false);
        public ClampedFloatParameter m_Strain = new ClampedFloatParameter(0, 0, 1, false);
        public FloatParameter        m_Angle  = new FloatParameter(0, false);
        public Vector3Parameter      m_Flow   = new Vector3Parameter(new Vector3(0, 0, 0), false);

        // =======================================================================
        public bool IsActive() => active && (m_Fade.value > 0f || m_Strain.value > 0f || m_Flow.value != Vector3.zero);
        public bool IsTileCompatible() => false;
    }
}