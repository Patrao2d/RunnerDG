Shader "Custom/DiffuseDistortion"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _DistTex("Distortion Texture", 2D) = "grey" {}
        _DistMask("Distortion Mask", 2D) = "white" {}
        _Speed("Distortion Speed", Float) = 1     
        _Color("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
		//_Intensity ("Deformer Intensity", Range(-1, 1)) = 0
    }
        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }
            Cull Off
            Lighting Off
            ZWrite Off
            Blend One OneMinusSrcAlpha
            CGPROGRAM
            #pragma surface surf Lambert vertex:vert nofog nolightmap nodynlightmap keepalpha noinstancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"
            #include "UnityCG.cginc"
            struct Input
            {
                float2 uv_MainTex;
                fixed4 color;
            };
            sampler2D _DistTex;
            sampler2D _DistMask;
            float _Speed;
			float _Intensity;

            void vert(inout appdata_full v, out Input o)
            {
                v.vertex = UnityFlipSprite(v.vertex, _Flip);
                #if defined(PIXELSNAP_ON)
                v.vertex = UnityPixelSnap(v.vertex);
                #endif
                UNITY_INITIALIZE_OUTPUT(Input, o);
                o.color = v.color * _Color * _RendererColor;
            }
            void surf(Input IN, inout SurfaceOutput o)
            {
                float2 distScroll = float2(_Time.x, _Time.x) * _Speed;
                fixed2 dist = (tex2D(_DistTex, IN.uv_MainTex + distScroll).rg - 0.5) * 2;
                fixed distMask = tex2D(_DistMask, IN.uv_MainTex)[0];
                fixed4 c = SampleSpriteTexture(IN.uv_MainTex + dist * distMask * 0.025) * IN.color;
                o.Albedo = c.rgb * c.a;
                o.Alpha = c.a;
            }
            ENDCG
        }
            Fallback "Transparent/VertexLit"
}