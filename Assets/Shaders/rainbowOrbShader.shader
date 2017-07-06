Shader "Custom/rainbowOrbShader"
{
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            uniform float offset; 

            struct Input 
            {
                float4 _Time;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };


            v2f vert (float4 pos : POSITION, float2 uv : TEXCOORD0)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(pos);
                o.uv = uv;
                return o;
            }

            float3 rgb2hsb( float3 c ){
			    float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
			    float4 p = lerp(float4(c.bg, K.wz), 
			                 float4(c.gb, K.xy), 
			                 step(c.b, c.g));
			    float4 q = lerp(float4(p.xyw, c.r), 
			                 float4(c.r, p.yzx), 
			                 step(p.x, c.r));
			    float d = q.x - min(q.w, q.y);
			    float e = 1.0e-10;
			    return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), 
			                d / (q.x + e), 
			                q.x);
			}

			//  Function from Iñigo Quiles 
			//  https://www.shadertoy.com/view/MsS3Wc
			float3 hsb2rgb( float3 c ){
			    float3 myRgb = clamp(abs(fmod(c.x*6.0+float3(0.0,4.0,2.0),
			                             6.0)-3.0)-1.0, 
			                     0.0, 
			                     1.0 );
			    myRgb = myRgb*myRgb*(3.0-2.0*myRgb);
			    float3 ones = float3(1.0,1.0,1.0);
			    return c.z * lerp(ones, myRgb, c.y);
			}
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 position = i.uv;

				float3 color = hsb2rgb(float3(position.x+_Time.x,1.0,position.y));
				float3 color2 = float3(position.y,position.x+_Time.x,sin(_Time.y));
				float3 color3 = lerp(color,color2,.5);
                return float4(color3,1.0);
                
            }
            ENDCG
        }
    }
}
