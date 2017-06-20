Shader "Custom/DefaultTrippy"
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
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 position = i.uv;

                float c = 0;
                c += sin(position.x * cos( _Time.y / 15.0 ) * 80.0 ) + cos( position.y * cos( _Time.y / 15.0 ) * 10.0 );
				c += sin( position.y * sin( _Time.y / 10.0 ) * 40.0 ) + cos( position.x * sin(  _Time.y  / 25.0 ) * 40.0 );
				c += sin( position.x * sin(  _Time.y  / 5.0 ) * 10.0 ) + sin( position.y * sin( _Time.y / 35.0 ) * 80.0 );
				c *= sin( _Time.y / 10.0 ) * 0.5;

                float b = sin(c+_Time.y / 3.0 ) * 0.75;
                return float4(c,c*0.5,b,1.0);
                
            }
            ENDCG
        }
    }
}
