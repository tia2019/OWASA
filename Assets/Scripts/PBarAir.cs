using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PBarAir : MonoBehaviour
{
   public Transform bar;
    float airflow = 0f;
    float p = 0f;
    float toThisValue = 0f;

    // Start is called before the first frame update
    private void Start ()
    {
        bar = transform.Find("Variable Bar");
    }

    public void setSize(float sizeNormalized){
        
        toThisValue = sizeNormalized;
    }
    public float getSize()
    {
       return bar.localScale.x;
    }

    public void setAirflow (float slider)
    {
        airflow = slider;
    }

    public float getAirflow ()
    {
        return airflow;
    }

    void Update(){
        // .75f is the height of the bar
            bar.localScale = new Vector3(p, 0.75f);
            if(p<toThisValue) p += .01f;
            else if(p>toThisValue) p-= .01f;

    }   
}