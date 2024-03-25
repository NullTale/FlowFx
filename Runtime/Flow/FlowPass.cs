using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

//  FlowFx © NullTale - https://twitter.com/NullTale/
namespace VolFx
{
    [ShaderName("Hidden/Vol/Flow")]
    public class FlowPass : VolFxProc.Pass
    {
        private static readonly int s_FlowTex = Shader.PropertyToID("_FlowTex");
        private static readonly int s_Weight  = Shader.PropertyToID("_Weight");
        private static readonly int s_Tiling  = Shader.PropertyToID("_Tiling");
        
        [Tooltip("Desired fps")]
        public float _fps = 60f;
        
        private RenderTargetFlip _flow;
        private bool             _clear;
        private float            _main;
        private float            _fade;
        private Vector2          _offsetUv;
        private float            _scaleUv;
        private float            _rotUv;
        private float            _lastDraw;
        
        private ProfilingSampler _sampler;
        
        // =======================================================================
        public override void Init()
        {
            _flow = new RenderTargetFlip(new RenderTarget().Allocate(new RenderTexture(Screen.width, Screen.height, GraphicsFormat.R8G8B8A8_UNorm, GraphicsFormat.None), $"{name}_a"),
                                         new RenderTarget().Allocate(new RenderTexture(Screen.width, Screen.height, GraphicsFormat.R8G8B8A8_UNorm, GraphicsFormat.None), $"{name}_b"));
            _sampler = new ProfilingSampler(name);
            _lastDraw = -1f;
        }

        public override bool Validate(Material mat)
        {
            var settings = Stack.GetComponent<FlowVol>();

            if (settings.IsActive() == false)
            {
                _clear = true;
                return false;
            }

            //var weight = 60f / (1f / Time.deltaTime);
            
            _main = 1f - settings.m_Fade.value;
            _fade = 1f - _main + settings.m_Strain.value * .5f;
            
            var flow  = settings.m_Flow.value; 
            _offsetUv = new Vector2(0.01f * flow.x, 0.01f * flow.y);
            _scaleUv  = 1f + 0.12f * flow.z;
            _rotUv    = settings.m_Angle.value * 0.01f;

            return true;
        }

        public override void Invoke(CommandBuffer cmd, RTHandle source, RTHandle dest, ScriptableRenderContext context, ref RenderingData renderingData)
        {
            _sampler.Begin(cmd);

            var desc = renderingData.cameraData.cameraTargetDescriptor;
            desc.colorFormat        = RenderTextureFormat.ARGB32;
            desc.depthStencilFormat = GraphicsFormat.None;
            
            _flow.Get(cmd, in desc);
            
            if (_clear)
            {
                Utils.Blit(cmd, source, _flow.From.Handle, _material, 1);
                Utils.Blit(cmd, _flow.From.Handle, dest, _material, 1);
                _sampler.End(cmd);
                _clear = false;
                
                _lastDraw = getDrawTime();
                return;
            }
            
            var drawTime = getDrawTime();
            if (drawTime - _lastDraw > 1f / _fps)
            {
                cmd.SetGlobalVector(s_Weight, new Vector4(_main, _fade));
                cmd.SetGlobalTexture(s_FlowTex, _flow.From.Handle.nameID);
                cmd.SetGlobalVector(s_Tiling, new Vector4(_offsetUv.x, _offsetUv.y, _scaleUv, _rotUv));
                Utils.Blit(cmd, source, _flow.To.Handle, _material);
                _flow.Flip();
                _lastDraw = drawTime;
            }
            
            cmd.SetGlobalTexture(s_FlowTex, _flow.From.Handle.nameID);
            Utils.Blit(cmd, source, dest, _material);

            _sampler.End(cmd);
            
            // -----------------------------------------------------------------------
            float getDrawTime()
            {
                var drawTime = Time.time;
#if UNITY_EDITOR
                if (Application.isPlaying == false)
                    drawTime = (float)UnityEditor.EditorApplication.timeSinceStartup;
#endif
                
                return drawTime;
            }
        }
    }
}