/*{
	"CREDIT": "by ISAAC",
	"CATEGORIES": [
		"Stylize"
	],
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		}
	]
}*/

void main(){

  vec4 colour = IMG_THIS_PIXEL(inputImage);
  float mySat = 1.5;
  //adjust colour
		if (colour.r > 0.5){
			colour.r *= (mySat + colour.r);
		} else {
			colour.r *= colour.r;
		}
		if (colour.g > 0.5){
			colour.g *= (mySat + colour.g);
		} else {
			colour.g *= colour.g;
		}
		if (colour.b > 0.5){
			colour.b *= (mySat + colour.b);
		} else {
			colour.b *= colour.b;
		}
		float myWhiteLimit = 1.0;
		float myWhiteSample = dot(vec4(1.0, 1.0, 1.0, 0.0), colour.rgba);
		//if (length(vec3(gl_FragColor.rgb)) >  myWhiteLimit){
		if (myWhiteSample >  myWhiteLimit){
			//float dimmer = (length(colour.rgb) -  myWhiteLimit);
			float dimmer = (myWhiteSample -  myWhiteLimit);
			//float perc = (value - min1) / (max1 - min1);
			float perc = (dimmer) / (3.0 - myWhiteLimit);
			//float value = perc * (max2 - min2) + min2;
			//float value = perc * (1.0 - min2) + min2;
			//dimmer = map(dimmer, 0.0, 3.0 - myWhiteLimit, 0.0, 1.0);
			colour.rgb *= 1.0 - perc; // 1.0 - (dimmer * ( dimmer));
			//gl_FragColor.rgb *= 0.3;
		}


 

	gl_FragColor = colour;
}
