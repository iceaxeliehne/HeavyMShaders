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
			"DEFAULT": 0.0
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

	vec4 colour = IMG_THIS_PIXEL(inputImage);

 	// get average value of rgb channels
	float sumOfValues = colour.r + colour.g + colour.b;
	float averageValue = sumOfValues / 3.0;
	// for each channel move by difference to average
	float avColMultiplyer = Colour_intensity;
	colour.r += (colour.r - averageValue) * avColMultiplyer;
	colour.g += (colour.g - averageValue) * avColMultiplyer;
	colour.b += (colour.b - averageValue) * avColMultiplyer;


   	// tackle the white values
	float myThreshold = Light_threshold;
	float valueSpread = max(colour.r, max(colour.g, colour.b)) - min(colour.r, min(colour.g, colour.b));
	float myPerc = valueSpread / myThreshold;

  	myPerc = 1.0 - myPerc;
	myPerc *= myPerc;
	if (valueSpread < myThreshold) {
		colour.r = colour.r - (myPerc * colour.r);
		colour.g = colour.g - (myPerc * colour.g);
		colour.b = colour.b - (myPerc * colour.b);
	}

	
	gl_FragColor = colour;
}
