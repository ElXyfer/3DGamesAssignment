// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Fixed Unlit"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white" {}
	}
	SubShader
	{
//		Tags { "RenderType"="Opaque" }
//		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			
			//#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 texcoord: TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 texcoord: TEXCOORD0;
			};

			fixed _Color;
			sampler2D _MainTex;

			
			v2f vert (appdata IN)
			{
				v2f OUT;
				OUT.pos = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				return OUT;

			}
			
			fixed4 frag (v2f IN) : COLOR
			{
				fixed4 texColor = tex2D(_MainTex, IN.texcoord);
				return texColor;
//				return _Color;
			}
			ENDCG
		}
	}
}
