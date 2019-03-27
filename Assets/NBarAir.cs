using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class NBarAir : MonoBehaviour
{
    //x is really nitrogen levels huh
    
    // bool change;
    // float max;
   public Transform bar;
    // Start is called before the first frame update
    private void Start ()
    {
        bar = transform.Find("vbar");
        

        // change = false;
        // max = 1f;
        // x = 1f;

    }
     public void setSize(float sizeNormalized){
         // .75f is the height of the bar
        bar.localScale = new Vector3(sizeNormalized, .75f);
    }

    
    // Update is called once per frame
    // void Update()
    // {
        // temp = transform.localScale;
        // float xOld = temp.x;

        // if(change && xOld < max)
        // {
        //     if (xOld + x < max)
        //     {
        //         temp.x = xOld + x;

        //     }
        //     else
        //     {
        //         temp.x = max;
        //     }
        //     transform.localScale = temp;
        //     change = false;
        // }

    // }

    // public void AdjustScale (float newX)
    // {
    //     x = newX;
    //     change = true;
    // }
}
