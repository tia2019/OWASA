using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{

    [SerializeField] public NBarAir nitrogenbar1;
    [SerializeField] public NBarAir nitrogenbar2;
    [SerializeField] public NBarAir nitrogenbar3;
    [SerializeField] public NBarAir nitrogenbar4;


    [SerializeField] public PBarAir phosphorusbar1;
    [SerializeField] public PBarAir phosphorusbar2;
    [SerializeField] public PBarAir phosphorusbar4;

    [SerializeField] public PBarAir phosphorusbar3;

    public float sliderVal = 0f;
    private bool change = false;

    // full nbar is at 2.75f 
    // full pbar is at 2.91f
    float n = 2.75f;
    float p = 1f;
    float sliderp = 2.911f;


    
    // Start is called before the first frame update
    public void Start()
    {

        // preset tank bars
        nitrogenbar1.setSize(2.75f);
        
        phosphorusbar1.setSize(p);
        phosphorusbar2.setSize(p);
        phosphorusbar3.setSize(p);
        phosphorusbar4.setSize(p);

        // water flow brings in new nutrients
        FunctionPeriodic.Create(() => {
            // to-do: randomize water flow nutrients
                
            
        }, .001f);

        

        // rate function 
        FunctionPeriodic.Create(() => {
            // decrease nitrogen
              
            if(n>0f){
                // rate
                n -= .005f;
                nitrogenbar1.setSize(n);
                nitrogenbar3.setSize(n);
            }

            // increase phosphorus
            if(p<2.91f){
                p += .005f;
                phosphorusbar1.setSize(p);
                phosphorusbar3.setSize(p);

            }

        }, .001f);


        // rate by slider
        FunctionPeriodic.Create(() => {
            // sliderp is the rate for phosphorus decline
            if(sliderp>0f){
                sliderp -= .1f * sliderVal;
                Debug.Log("Rate of Phosphorus -- " + sliderp);
                phosphorusbar2.setSize(sliderp);
                phosphorusbar4.setSize(sliderp);
                
            }
        }, .001f);

    }

    public void setSliderValue(float value){
        if(value<0){
            value = value*(-1f);
        }
        sliderVal = value;
        Debug.Log("Slider value " + value);
        change = true;
    }
   

}
