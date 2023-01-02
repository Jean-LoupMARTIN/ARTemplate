﻿Shader "FastShadowReceiver/Projector/Multiply Diffuse x ShadowMask Without Falloff" {
	Properties {
		[NoScaleOffset] _ShadowTex ("Cookie", 2D) = "gray" {}
		_ClipScale ("Near Clip Sharpness", Float) = 100
		_Alpha ("Shadow Darkness", Range (0, 1)) = 1.0
		_Ambient ("Ambient", Range (0.01, 1)) = 0.3
		_ShadowMaskSelector ("Shadowmask Channel", Vector) = (1,0,0,0) 
		_Offset ("Offset", Range (-10, 0)) = -1.0
		_OffsetSlope ("Offset Slope Factor", Range (-1, 0)) = -1.0
	}
	Subshader {
		Tags {"Queue"="Transparent-1" "IgnoreProjector"="True"}
		Pass {
			ZWrite Off
			Fog { Color (1, 1, 1) }
			ColorMask RGB
			Blend DstColor Zero
			Offset [_OffsetSlope], [_Offset]
 
			HLSLPROGRAM
			#pragma vertex fsr_vert_projector_diffuse_nearclip_lightmap
			#pragma fragment fsr_frag_projector_shadow_alpha_nearclip_shadowmask
			#pragma shader_feature_local _ FSR_PROJECTOR_FOR_LWRP
			#pragma multi_compile_local _ FSR_RECEIVER 
			#pragma multi_compile_fog
			#pragma multi_compile_instancing
			#define FSR_USE_CLIPSCALE
			#define FSR_USE_ALPHA
			#define FSR_USE_AMBIENT
			#define FSR_USE_SHADOWMASK
			#define FSR_USE_LIGHTMAP_ST
			#include "FastShadowReceiver.cginc"
			ENDHLSL
		}
	}
	Fallback "FastShadowReceiver/Projector/Multiply Diffuse Without Falloff"
	CustomEditor "FastShadowReceiver.ProjectorShaderGUI"
}
