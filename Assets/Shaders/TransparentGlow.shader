Shader "Custom/TransparentGlow"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glow ("Glow Color", Color) = (1,1,1,1)
        _GlowPower ("Glow Power", Range(0.5,8.0)) = 3.0
    }
    SubShader
    {
        Tags { 
            "Queue" = "Transparent"
            "Rendertype" = "Transparent"
            "ForceNoShadowCasting" = "True"
        }

        CGPROGRAM
        #pragma surface surf Lambert alpha:fade
        #pragma multi_compile_fwdbase nolightmap nodirlightmap novertexlight
        #include "UnityCG.cginc" 
        #include "UnityLightingCommon.cginc" 
        #include "Lighting.cginc"
        #include "AutoLight.cginc"

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldPos;
        };

        float4 _Glow;
        float _GlowPower;

        void surf (Input IN, inout SurfaceOutput o)
        {
            half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal) + (sin(_Time.z)/2));

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = max(pow(rim, _GlowPower), 0.2);
            o.Emission = _Glow.rgb * pow(rim, _GlowPower) * 10;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
