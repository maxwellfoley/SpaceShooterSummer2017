Shader "Custom/SpaceShader"
{
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

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

			// Noise Shader Library for Unity - https://github.com/keijiro/NoiseShader
		
			float3 mod289(float3 x)
			{
			    return x - floor(x / 289.0) * 289.0;
			}

			float2 mod289(float2 x)
			{
			    return x - floor(x / 289.0) * 289.0;
			}

			float3 permute(float3 x)
			{
			    return mod289((x * 34.0 + 1.0) * x);
			}

			float3 taylorInvSqrt(float3 r)
			{
			    return 1.79284291400159 - 0.85373472095314 * r;
			}

			float snoise(float2 v)
			{
			    const float4 C = float4( 0.211324865405187,  // (3.0-sqrt(3.0))/6.0
			                             0.366025403784439,  // 0.5*(sqrt(3.0)-1.0)
			                            -0.577350269189626,  // -1.0 + 2.0 * C.x
			                             0.024390243902439); // 1.0 / 41.0
			    // First corner
			    float2 i  = floor(v + dot(v, C.yy));
			    float2 x0 = v -   i + dot(i, C.xx);

			    // Other corners
			    float2 i1;
			    i1.x = step(x0.y, x0.x);
			    i1.y = 1.0 - i1.x;

			    // x1 = x0 - i1  + 1.0 * C.xx;
			    // x2 = x0 - 1.0 + 2.0 * C.xx;
			    float2 x1 = x0 + C.xx - i1;
			    float2 x2 = x0 + C.zz;

			    // Permutations
			    i = mod289(i); // Avoid truncation effects in permutation
			    float3 p =
			      permute(permute(i.y + float3(0.0, i1.y, 1.0))
			                    + i.x + float3(0.0, i1.x, 1.0));

			    float3 m = max(0.5 - float3(dot(x0, x0), dot(x1, x1), dot(x2, x2)), 0.0);
			    m = m * m;
			    m = m * m;

			    // Gradients: 41 points uniformly over a line, mapped onto a diamond.
			    // The ring size 17*17 = 289 is close to a multiple of 41 (41*7 = 287)
			    float3 x = 2.0 * frac(p * C.www) - 1.0;
			    float3 h = abs(x) - 0.5;
			    float3 ox = floor(x + 0.5);
			    float3 a0 = x - ox;

			    // Normalise gradients implicitly by scaling m
			    m *= taylorInvSqrt(a0 * a0 + h * h);

			    // Compute final noise value at P
			    float3 g;
			    g.x = a0.x * x0.x + h.x * x0.y;
			    g.y = a0.y * x1.x + h.y * x1.y;
			    g.z = a0.z * x2.x + h.z * x2.y;
			    return 130.0 * dot(m, g);
			}

			float star(float2 p) {
				float val = snoise(p*100); 
				  				return smoothstep(0.80, 1.0, val);  

  //				return step(0.49, smoothstep(0.80, 1.0, val));  
			}
            fixed4 frag (v2f i) : SV_Target
            {
                float2 position = i.uv;


                //float c = 0;
                //c += sin(position.x * cos( _Time.y / 15.0 ) * 80.0 ) + cos( position.y * cos( _Time.y / 15.0 ) * 10.0 );
				//c += sin( position.y * sin( _Time.y / 10.0 ) * 40.0 ) + cos( position.x * sin(  _Time.y  / 25.0 ) * 40.0 );
				//c += sin( position.x * sin(  _Time.y  / 5.0 ) * 10.0 ) + sin( position.y * sin( _Time.y / 35.0 ) * 80.0 );
				//c *= sin( _Time.y / 10.0 ) * 0.5;

                //float b = sin(c+_Time.y / 3.0 ) * 0.75;

                float2 o = float2(0.0,_Time.x);

			     // star layers
			    float s1 = star(position + (o * 1.1));
			    float s2 = star(position + (o * 0.75) + float2(-20.0, 10.0));
			    float s3 = star(position + (o * 0.5) + float2(-75.0, 25.0));

			    float val = (s1 * 1.0 + s2 * 0.50 + s3 * 0.25) * 0.85;
			    float c=val;
			      
                return float4(c,c,c,1.0);
                
            }
            ENDCG
        }
    }
}
