using System.Collections;
using System.Collections.Generic;
using System;
using System.Timers;
using UnityEngine;

public class PBarAir : MonoBehaviour
{
    // Vector3 temp;
    // float x;
    // bool change;

    // bool pos, neg;
    

 
   public Transform bar;

    // Start is called before the first frame update
    private void Start ()
    {
        bar = transform.Find("Variable Bar");
    }

    public void setSize(float sizeNormalized){
        // .75f is the height of the bar
        bar.localScale = new Vector3(sizeNormalized, .75f);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     temp = transform.localScale;
    //     float xOld = temp.x;

    //     if (change && xOld > 0)
    //     {
    //         if (xOld - x > 0)
    //         {
    //             if(pos){
    //                 temp.x = xOld - x;
    //             }
    //         }
    //         else
    //         {
    //             temp.x = 0;
    //         }
    //         transform.localScale = temp;
    //         change = false;
    //     }

    // }

    // public void AdjustScale(float newX)
    // {
    //     if (newX > x){
    //         pos = true;
    //         neg = false;
    //     } else {
    //         neg = true;
    //         pos = false;
    //     }
    //     x = newX;
    //     change = true;
        
    // }
}
