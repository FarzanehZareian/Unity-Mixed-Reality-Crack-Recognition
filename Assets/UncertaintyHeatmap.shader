Shader "Unlit/UncertaintyHeatmap"
{
    Properties
    {
        _MainTex("Uncertainty", 2D) = "black" {}
    }

        SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            ZTest Always Cull Off ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;

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

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float u = tex2D(_MainTex, i.uv).r; // probability / confidence

                float3 color;
                color.b = saturate(1.0 - u * 2.0);
                color.g = saturate(1.0 - abs(u - 0.5) * 2.0);
                color.r = saturate(u * 2.0);

                return float4(color, 1.0);
            }

        ENDCG
    }
    }
}
