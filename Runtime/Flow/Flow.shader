Shader "Hidden/Vol/Flow"
{
    HLSLINCLUDE
    
    struct vert_in
    {
        float4 pos : POSITION;
        float2 uv  : TEXCOORD0;
    };

    struct frag_in
    {
        float2 uv     : TEXCOORD0;
        float4 vertex : SV_POSITION;
    };
                
    frag_in vert(vert_in input)
    {
        frag_in output;
        output.vertex = input.pos;
        output.uv     = input.uv;
        
        return output;
    }
    
    ENDHLSL

	SubShader 
	{
        ZTest Always
        ZWrite Off
        ZClip false
        Cull Off
		
        Pass	// 0
		{
			name "Flow"
			
	        HLSLPROGRAM
	        
			#pragma vertex vert
			#pragma fragment frag
	        	        
	        sampler2D    _MainTex;
	        sampler2D    _FlowTex;
	        
	        float4		 _Weight;
	        float4		 _Tiling;
	        
            #define _offset _Tiling.xy
            #define _scale  _Tiling.z
            #define _rot    _Tiling.w

	        float2 rotate(float2 vec, float angle)
	        {
		        float c = cos(angle);
		        float s = sin(angle);
	        	
	        	return float2(dot(vec, float2(c, -s)), dot(vec, float2(s, c)));
	        }
	        
	        half4 frag(frag_in i) : SV_Target 
	        {	        
	            half4 col  = tex2D(_MainTex, i.uv);
	            half4 flow = tex2D(_FlowTex, frac(rotate(i.uv - float2(.5, .5), _Tiling.w) * _scale + float2(.5, .5) + _offset));
	  
				return clamp(col * _Weight.x + flow * _Weight.y, 0, 1);
	        }
			
			ENDHLSL
		}
		
        Pass	// 1
		{
			name "Blit"
			
	        HLSLPROGRAM
	        
			#pragma vertex vert
			#pragma fragment frag
	        	        
	        sampler2D    _MainTex;
	        	        
	        half4 frag(frag_in i) : SV_Target 
	        {
	            return tex2D(_MainTex, i.uv);
	        }
			
			ENDHLSL
		}
	}
}