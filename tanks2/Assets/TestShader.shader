Shader "Unlit/TestShader"
{
// 2 programs in shader. ShaderLab in which CG is embedded

// variables
	Properties
	{
	// appear in instructor
	 _MainTexture("Main Color (RGB) Hello!", 2D) = "white" {}
	 _Color("Kleur", Color) = (1, 1, 1, 1)

	 _DissolveTexture("Cheese", 2D) = "white" {}
	 _DissolveAmount("Cheese Cut Out Amount", Range(0, 1)) = 1

	 _ExtrudeAmount("Extrude Amount", float) = 0.3
	}

	SubShader{
	// passing data to the screen, similar to draw call
		Pass{
		// Open CG
		CGPROGRAM
		// for built the object
		#pragma vertex vertexFunction
		// to color the object
		#pragma fragment fragmentFunction

		#include "UnityCG.cginc"

		// Vertices
		// normal
		//color
		//uv
		// get data from object
		struct appdata{
		// dataFormat, variable name, what you poll
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
			float3 normal : NORMAL;
		};

		struct v2f{
		// sv so it works all the time
			float4 position : SV_POSITION;
			float2 uv : TEXCOORD0;
		};

		// properties from ShaderLab to CG
		float4 _Color;
		sampler2D _MainTexture;

		float _DissolveAmount;
		sampler2D _DissolveTexture;
		float _ExtrudeAmount;

		// struc that send to screen
		// built our object

		// vertex function
		// goes by all the pixels (for loop manner)
		v2f vertexFunction(appdata IN){
			v2f OUT;

			IN.vertex.xyz += IN.normal.xyz * _ExtrudeAmount; // time is float 4,  * sin(_Time.y)

			// model view projection, modified by dif type of camera
			OUT.position = mul(UNITY_MATRIX_MVP, IN.vertex);
			OUT.uv = IN.uv;


			return OUT;
		}

	


		//fragment
		//color it in!
		// goes all around the pixel and color it
		fixed4 fragmentFunction(v2f IN) : SV_Target{
		// take texture and wrap it around the object
			float4 textureColor = tex2D(_MainTexture, IN.uv);
			float4 dissolveColor = tex2D(_DissolveTexture, IN.uv);

			//kill the pixel output it value negative
			clip(dissolveColor.rgb - _DissolveAmount);

			return textureColor * _Color ;
		}

		ENDCG

		}

	}

}
