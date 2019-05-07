using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NBarAir : MonoBehaviour
{
    //x is really nitrogen levels huh
    float n = 0f;
    float toThisValue  = 0f;
   public Transform bar;
    // Start is called before the first frame update
    private void Start ()
    {
        bar = transform.Find("vbar");
    }
     public void setSize(float sizeNormalized){
         // .75f is the height of the bar
        //  FunctionPeriodic.Create(() => {
        //      if(n>=0f && n<2.75f){
        //      if(n>sizeNormalized){
        //          n -= .005f;
        //          bar.localScale = new Vector3(n, .75f);
        //      } else if(n<sizeNormalized){
        //          n += .005f;
        //          bar.localScale = new Vector3(n, .75f);
        //      }}
        //  }, 0.001f);
        if(sizeNormalized < 2.75f)
        toThisValue = sizeNormalized;    
    }

    public float getSize()
    {
       return n;
    }
    void Update(){
        bar.localScale = new Vector3(n, 0.75f);
        if(n<toThisValue) n += .01f;
        else if(n>toThisValue) n-= .01f;

        
    }

}