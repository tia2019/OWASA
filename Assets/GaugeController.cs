using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

[Serializable]

public class GaugeRange
{
	public Color Colour;		//Colour of the range on the gauge
	public float StartValue;    //Minimum value of the range on the gauge
	public float EndValue;      //Maximum value of the range on the gauge
}
public class GaugeController : MonoBehaviour
{
    public float GaugeMinRotation;      //Maximum rotation of the needle on the gauge
    public float GaugeMaxRotation;      //Minimum rotation of the needle on the gauge
    public List<GaugeRange> GaugeRanges;//Ranges of values to be used in the gauge
    public RawImage GaugeBackGround;    //Image representing the gauge background
    public RawImage GaugeNeedle;        //Image representing the gauge needle
    public Text GaugeText;              //Text used to display the current gauge value

    public float GaugeValue = 0f;            //Value the gauge is displaying
    public float GaugeSpeed;            //Speed at which the needle should move to a new value
    public float Tank2Slider = 0f;
    public float Tank4Slider = 0f;
    public bool start;
    public float max = 50;


    private float _needleInterpolation; //This is the variable used to facilitate smooth needle animation when it is moving
    private float _scaleMinValue;       //This is the minimum value in our Gauge
    private float _scaleMaxValue;       //This is the maximum value in our Gauge
    private float _scaleRange;          //This is the range of values in our gauge

    private Slider[] _gaugeRangeSliders;

    // Use this for initialization
    void Start ()
    {
        ////set the min value of the scale to something ridiculous (if it starts at 0 and our scale starts at e.g. 5, it will stay at 0
        //_scaleMinValue = 999999f;
        //_scaleMaxValue = -999999f;

        //CalculateGaugeRanges(GaugeRanges);
        //CalibrateGaugeLegends();
        Tank2Slider = 0f;
        Tank4Slider = 0f;
        start = true;
        SetGauge(0f);
        Debug.Log(GetGauge());



        ReSetGauge();
    }
    public void SetGauge(float newamount)
    {
        GaugeValue = newamount;
    }

    public float GetGauge()
    {
        return GaugeValue;
    }
    public void ReSetGauge()
    {
        //set the min value of the scale to something ridiculous (if it starts at 0 and our scale starts at e.g. 5, it will stay at 0
        _scaleMinValue = 0f;
        _scaleMaxValue = 0f;

        CalculateGaugeRanges(GaugeRanges);
        CalibrateGaugeLegends();
    }

    public void SetTankRate(float newRate){

    }

	public void SetGaugeTank2Value(float newValue)
    {
        Debug.Log(GetGauge());
    
        float addToGauge =  (max * newValue);
        float subToGauge =  (max * newValue);

        if (newValue > Tank2Slider)
        {
            Debug.Log(newValue);
            if (addToGauge < max)
            {

                GaugeValue = addToGauge;
            }
            else
            {
                GaugeValue = max;
            }
        }
        else if(newValue < Tank2Slider)
        {
            if (subToGauge > 0)
            {
                GaugeValue = subToGauge;
            }
            else
            {
                GaugeValue = 0;
            }
        }


        Tank2Slider = newValue;
    }

  

public void SetGaugeTank4Value(float newValue)
    {
        Debug.Log(GetGauge());
    
        float addToGauge =  (max * newValue);
        float subToGauge =  (max * newValue);

        if (newValue > Tank4Slider)
        {
            Debug.Log(newValue);
            if (addToGauge < max)
            {

                GaugeValue = addToGauge;
            }
            else
            {
                GaugeValue = max;
            }
        }
        else if(newValue < Tank4Slider)
        {
            if (subToGauge > 0)
            {
                GaugeValue = subToGauge;
            }
            else
            {
                GaugeValue = 0;
            }
        }


        Tank4Slider = newValue;
    }
    public void SetGaugeMinRotation(float newValue)
	{
		GaugeMinRotation = newValue;
		ReSetGauge();
	}

	public void SetGaugeMaxRotation(float newValue)
	{
		GaugeMaxRotation = newValue;
		ReSetGauge();
	}


	/// <summary>
	/// This configures and rotates the require gauge range legends to align with the configuration of our gauge
	/// It also hides the legends we are not using
	/// </summary>
	private void CalibrateGaugeLegends()
    {
        _gaugeRangeSliders = GetComponentsInChildren<Slider>();

        float rangePosition;    //The position that our range ends in. Since our range is 360degrees, this represents the value the legend should have
        float gaugeRotation = GaugeMinRotation * -1;

        //if we have a negative value, we need to convert that to its equivalent value out of 360
        if (gaugeRotation < 0)
        {
            gaugeRotation = 360 + gaugeRotation;
        }

        //Calibrate ranges we are using for rotation, colour, values
        for (int i = 0; i < GaugeRanges.Count; i++)
        {
            rangePosition = CalculateGaugeposition(GaugeRanges[i].EndValue, _scaleRange, GaugeMinRotation, GaugeMaxRotation);

            _gaugeRangeSliders[_gaugeRangeSliders.Length - i - 1].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, gaugeRotation));
            _gaugeRangeSliders[_gaugeRangeSliders.Length - i - 1].GetComponentInChildren<Image>().color = GaugeRanges[i].Colour;
            _gaugeRangeSliders[_gaugeRangeSliders.Length - i - 1].value = rangePosition - GaugeMinRotation;
        }

        //Hide ranges we are not using (All ranges have the slider control, so count them and deduct from our ranges configured)
        for (int i = 0; i < (GetComponentsInChildren<Slider>().Length- GaugeRanges.Count); i++)
        {
            _gaugeRangeSliders[i].GetComponentInChildren<Image>().color = Color.clear;
        }
    }

	/// <summary>
	/// Converts supplied Hex values to a colour object. This is used if the GaugeRange object is changed to receive hex values instead of colour types
	/// Note that if GaugeRange is changed to receive hex values, where the colour is implemented, this method should be used to convert the value to a colour object.
	/// </summary>
	/// <param name="hex">The hex value representing the desired colour</param>
	/// <returns>Color type</returns>
    private Color HexToColor(string hex)
    {
        hex = hex.Replace("0x", ""); //in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", ""); //in case the string is formatted #FFFFFF
        float a = 255f; //assume fully visible unless specified in hex
        float r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
        float g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
        float b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
        }

        Color newColor = new Color(r, g, b, a);
        //return new Color(r, g, b, a);

        return newColor;
    }


    // Update is called once per frame
    void Update ()
    {
        MoveNeedle(GaugeValue);
    }

    /// <summary>
    /// Positions our gauge needle at the right location and colour the text based on the ranges we have
    /// </summary>
    /// <param name="flGaugeValue">The value to be displayed on the gauge</param>
    private void MoveNeedle(float flGaugeValue)
    {
        GaugeText.text = flGaugeValue.ToString(CultureInfo.CurrentCulture);

        //Get the range we are in out of our list of ranges
        var ourRange = GaugeRanges.FirstOrDefault(x => x.StartValue <= flGaugeValue && x.EndValue >= flGaugeValue);

	    GaugeRange gaugeRange = ourRange;
        if (gaugeRange != null)
        {
            //If we are in a range, show that range's colour
            GaugeText.color = gaugeRange.Colour;
        }
        else
        {
            //If we are not in a range, default to white
            GaugeText.color = Color.white;
        }

        //calculate the gauge position based on our ranges configured for that gauge
        float gaugePosition = CalculateGaugeposition(GaugeValue, _scaleRange, GaugeMinRotation, GaugeMaxRotation);

        if (GaugeNeedle.transform.rotation != Quaternion.Euler(0f,0f, gaugePosition) )
        {
            _needleInterpolation += Time.deltaTime * GaugeSpeed;

            Vector3 newRotation = new Vector3();
            newRotation.x = 0f;
            newRotation.y = 0f;
            //newRotation.z = GaugeValue;
            newRotation.z = -Mathf.Lerp(GaugeNeedle.transform.rotation.z, gaugePosition, _needleInterpolation);

            GaugeNeedle.transform.rotation = Quaternion.Euler(newRotation);
        }
        else
        {
            _needleInterpolation = 0f;
        }
    }

    /// <summary>
    /// Used to Calculate the Min and Max values on the gauge as well as the centre position of the scale and the range of the scale
    /// </summary>
    /// <param name="gaugeRanges">A list of the ranges to be used on the gauge. This is what determines the ranges etc calculated by this method</param>
    private void CalculateGaugeRanges(List<GaugeRange> gaugeRanges)
    {

        //get the smallest and largest value over our ranges
        foreach (GaugeRange currentRange in gaugeRanges)
        {
            if (_scaleMinValue > currentRange.StartValue)
            {
                _scaleMinValue = currentRange.StartValue;
            }
            if (_scaleMaxValue < currentRange.EndValue)
            {
                _scaleMaxValue = currentRange.EndValue;
            }
        }

        //get the middle of our range (this will represent 0 degrees rotation for the needle)

        //get the range of values in our range
        _scaleRange = _scaleMaxValue - _scaleMinValue;
    }

    /// <summary>
    /// Used to calculate the position on the gauge for a specific value based on current known values of a gauge
    /// This is also used to determine where the scales should be drawn on the gauge
    /// </summary>
    /// <param name="gaugeValue">The value whose position is to be determined</param>
    /// <param name="scaleRange">The range of the scale on the gauge</param>
    /// <param name="gaugeMinRotation">The minimum rotation allowed on the gauge (minimum position)</param>
    /// <param name="gaugeMaxRotation">The maximum rotation allowed on the gauge (maximum position)</param>
    /// <returns></returns>
    private float CalculateGaugeposition(float gaugeValue, float scaleRange, float gaugeMinRotation, float gaugeMaxRotation)
    {
        //float gaugePosition = ((gaugeValue / scaleRange) * ((gaugeMaxRotation - gaugeMinRotation))) + gaugeMinRotation;
        float gaugePosition = (((gaugeValue - _scaleMinValue)/ scaleRange) * ((gaugeMaxRotation - gaugeMinRotation))) + gaugeMinRotation;
        return gaugePosition;
    }

}

