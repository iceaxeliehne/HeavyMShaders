/*{
	"CREDIT": "by ISAAC",
	"CATEGORIES": [
		"Stylize"
	],
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "Colour_intensity",
			"TYPE": "float",
			"MIN": 0.0,
			"MAX": 50.0,
			"DEFAULT": 50.0
		},
		{
			"NAME": "Light_threshold",
			"TYPE": "float",
			"MIN": 0.0,
			"MAX": 1.0,
			"DEFAULT": 0.5
		}
	]
}*/



void main()
{

	vec4 color = IMG_THIS_PIXEL(inputImage);
	
	
	gl_FragColor = color;
}
