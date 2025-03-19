Shader "Custom/AA_LineRenderer"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Thickness ("Thickness", Range(0.3, 1.2)) = 0.5 // 라인의 전체 두께
        _Smoothness ("Smoothness", Range(0.001, 1)) = 0.02 // 경계 부드러움
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _Thickness;
            float _Smoothness;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Color;

                // 선의 중심에서 거리 계산 (양쪽 모두 고려)
                float dist = abs(i.uv.y - 0.5) * 2.0; // 0~1 범위로 정규화
                float edge = smoothstep(_Thickness, _Thickness - _Smoothness, dist);

                col.a *= edge; // 부드러운 테두리 적용

                return col;
            }
            ENDCG
        }
    }
}
