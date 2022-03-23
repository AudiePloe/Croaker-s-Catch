Shader "Jettelly/Water"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DisTex("Distortion Texture", 2D) = "white" {}
        [Space(10)]
        _DisSpeed ("Distortion Speed", Range(-0.4, 0.4)) = 0.1
            _DisValue ("Distortion Value", Range(2,10)) = 3
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        // TEXTURE PASS ---------------------------------------------- 1
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _DisTex;
            float4 _MainTex_ST;
            float _DisSpeed;
            float _DisValue;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed distortion = tex2D(_DisTex, i.uv + (_Time * _DisSpeed)).r;
            i.uv += distortion / _DisValue;

                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog

                return col;
            }
            ENDCG
        }

        //DEPTH PASS ---------------------------------------- 2
                /*
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
            // apply fog

            return col;
        }
        ENDCG
    }*/

    }
}
