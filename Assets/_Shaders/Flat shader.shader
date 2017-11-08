Shader "GLSL flat shader" {
SubShader {
  Pass {
     GLSLPROGRAM

     <a href="/search?Search=%23extension&Mode=like">#extension</a> GL_EXT_gpu_shader4 : require
     flat varying vec4 color;

     struct v2f {
		...
		float3 worldPos: TEXCOORD1;
		...
	};

	v2f vert(appdata_full v)
{
	v2f o;
	o.worldPos = mul(_Object2World, v.vertex);
	...
}

fixed4 frag(v2f i): SV_Target
{
	float3 x = ddx(i.worldPos);
	float3 y = ddy(i.worldPos);

	float3 norm = -normalize(cross(x,y));
	...
}
     <a href="/search?Search=%23ifdef&Mode=like">#ifdef</a> VERTEX
     void main()
     {
        
        gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
        color = gl_ModelViewProjectionMatrix * vec4(gl_Normal, 1.0);
     }
     <a href="/search?Search=%23endif&Mode=like">#endif</a>

     <a href="/search?Search=%23ifdef&Mode=like">#ifdef</a> FRAGMENT
     void main()
     {
        gl_FragColor = color; // set the output fragment color
     }
     <a href="/search?Search=%23endif&Mode=like">#endif</a>

     ENDGLSL
  }
  }
}