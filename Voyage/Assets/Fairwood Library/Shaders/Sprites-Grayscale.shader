Shader "Sprites/Grayscale"
{
	Properties
	{
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_Grayscale ("Grayscale", Range(0,1)) = 0
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				//float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				//fixed4 color    : COLOR;
				half2 texcoord  : TEXCOORD0;
			};
			
			float _Grayscale;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				//OUT.color = IN.color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f IN) : COLOR
			{
				float4 texCol = tex2D(_MainTex, IN.texcoord);
				//if (_Grayscale > 0.5)
				//{
				//	return texCol;
				//}
				float gray = (texCol.x + texCol.y + texCol.z) / 3;
			    float4 outp = texCol * (1-_Grayscale) + float4(gray, gray, gray, texCol.w) * _Grayscale;
			    return outp;
			}
			ENDCG
		}
	}
}
