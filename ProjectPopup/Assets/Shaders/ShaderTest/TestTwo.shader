Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ColorA("Color A",Color)= (1,1,1,1)
        _ColorB("Color B",Color)=(1,1,1,1)
        _ColorStart("Color Start" , Range(0,1))= 0
        _ColorEnd("Color End" , Range(0,1))= 1
    }
    SubShader
    {
        //subshaderTags
        Tags { "RenderType"="Opaque" }
        LOD 100
        //pass tags
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            #define TAU 6.28318530718
            
           float4 _ColorA;
           float4 _ColorB;
           float _ColorStart;
           float _ColorEnd;

            struct appdata //MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;// local space normal direction
                float4 uv0 : TEXCOORD0;
                
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal :TEXCOORD0;
                float2 uv : TEXCOORD1;
            };
            

            Interpolators vert (appdata v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normals;
                o.uv = v.uv0;
                return o;
            }

            float InverseLerp(float a , float b , float v)
            {
                return (v-a)/(b-a);
            }
            fixed4 frag (Interpolators i) : SV_Target
            {
                float xoffset = cos(i.uv.y* TAU * 8)*0.01;
                //float t = abs(frac(i,uv.x*5)*2-1); //Triangle Wave
                //return t;

                float t = cos((i.uv.x + xoffset - _Time.y * 0.1f )*TAU *5)*0.5+ 0.5;
                t *= i.uv.x; 
                return t;
                
                
            }
            ENDCG
        }
    }
}
