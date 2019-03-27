Basic Gauge Control V1.0.0
----------------------------

Package Contents:
1. GaugeControl Folder: Root of package
2. _SampleScenes: Contains a sample implementation of the gauge control for reference purposes
3. Images: Contains all images used in the control
4. Images\Gauges: Contains graphical components used in the display of the Gauge
5. Images\UI: Contains the png used to draw the gauge ranges (Slider Control image)
6. Prefabs: Contains the Prefab for the Gauge itsself
7. Scripts: Contains Scripts used in the Control
8. Scripts\Testing: Contains a test script that demonstrates how to change gauge configuration from code.
		Usage: - Implement a Gauge control called "Gauge" in the scene
			   - Place script on Empty GameObject in the scene
			   - Create a Button for each public method in the scene
			   - Bind each button to a method using the OnClick() event
			   - Now when you click the button, the gauge ranges and values change according to what you clicked.
			   
			   
How does the control work?
1. The Gauge Prefab needs to be placed on a canvas
	with some minor tweaks, the gauge can function in Screen Space Overlay, Screen Space Camera and World Space
2. Prefab Structure:
	Root (Gauge): Contains GaugeController Script. This script is used to configure gauge ranges (colours, rotation of ranges, values etc)
	Gauge\BackGround GameObject: used to display the gauge background. Changing this will change the gauge manifold
	Gauge\GaugeRanges: Parent GameObject hosting GaugeRange objects
	Gauge\GaugeRanges\GaugeRange1...6: This is a Slider Control that is configured to be circular and is used to draw the ranges on the gauge. 
									   GaugeRange controls are ordered in descending order and should be implemented in ascending order.
									   This means that the 1st range (1) is at the bottom of the hierarchy and is drawn on top of the other ranges etc.
									   This stacking causes a visual effect that makes it look like the ranges are right next to each other.
									   If more than 6 ranges are required, simply adding a Range7 here and adapting the GaugeController script's GaugeRanges property should suffice.
	Gauge\Needle: Contains the graphic used to display the needle. Replacing the image with another one will change the appearance of the needle. 
					Replacement needle graphics should be centered and pointing straight up for correct display.
	Gauge\Text: Used to display text within the gauge. Colour of the text is adjusted to match the current range the value of the gauge lies in.
3. Scripts:
	GaugeController.cs: This script controls the functioning of the Gauge
						Properties: Gauge Min Rotation: Indicates the starting point of the Gauge in degrees where 0 is the top (12 o' clock) position of the gauge e.g. -90 represents 9 o clock, 90 represents 3 o clock
									Gauge Max Rotation: Indicates the end point of the gauge in degrees with the same principle as Min Rotation.
									Gauge Ranges: A list of ranges defined for the gauge. Current limit is 6, but it can be extended.
										Colour: The colour of the range in question
										Start Value: The value at which the range in question starts
										End Value: The value at which the range in question ends
										Note: Please ensure the alpha value of a chosen colour is not 0. This will result in an invisible range.
									Gauge Back Ground: Refers to the image on the BackGround Game Object. This allows for the changing of this in code if necessary
									Gauge Needle: Refers to the Needle Game Object. This allows for the movement of the needle in code
									Gauge Text: Refers to the Text Game Object. This allows for the adjustment of the gauge text in code
									Gauge Value: The current value of the gauge
									Gauge Speed: The speed at which the needle will move to a new value should its value change.


Using the Sample Scene:
The Sample Scene was configured using an aspect ration of 16:9. If the apsect ration changes, minor configuration changes might be required to get the gauge aspect ratio to display correctly.
I recommend starting with an aspect ratio of 16:9 to get a feel for what is needed before changing screen resolution configurations

The Sample Scene contains 5 buttons and 3 sliders:
Buttons: The Red, Green, Red Green Blue, Temperature and Ph buttons are pre-configured configurations for the gauge, showing typical configuration for the gauge control.
Gauge Value Slider: Sliding this value changes the current value displayed by the gauge (The needle moves). 
					Needle movement is calculated relative to the Min and Max rotation and Min and Max Values of the current gauge configuration.
					E.g. if my min and max rotation of the gauge is -90 to 90 degrees, the needle can only move between those ranges.
					The position is then determined based on the value vs the min and max range of the current gauge ranges configured.
					This means that if my lowest range value is 0 and my highest range value is 180, with a rotation of -90 to 90 degrees, a value of 90 will have the needle point straight up.
Gauge Min Rotation Slider: Changing this value will change the position where the gauge ranges start e.g. a value of 0 will start the gauge ranges at 0 degrees or the top of the gauge.
						   If this value exceeds the Gauge Max rotation value, the range of the gauge will become invisible as there is less than 0 degrees from min to max.
Gauge Max Rotation Slider: Changing this value will change the position where the gauge ranges end e.g. a value of 90 will end the gauge ranges at 90 degrees (3 o clock).
						   If this value is less than the Gauge Min Rotation value, the gauge ranges become invisible as there is less than 0 degrees from min to max.
						   
A good idea of what all properties does can be obtained by running the sample scene and clicking on the different buttons to see different configurations.
Moving the sliders will clearly show the impact of each property. In this way, it is possible to play with the interface and configure a gauge to get a feel for what settings should be to achieve the desired effect.
									
						

	