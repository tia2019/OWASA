using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trigger4 : MonoBehaviour
{
    public event Action tank4event;
    Boolean triggered = false;
    // Start is called before the first frame update
    
    public void OnTriggerEnter2D(Collider2D other){
        triggered = true;
        // Debug.Log("Tank1 collided successful");
    }
    // Update is called once per frame
    void Update()
    {
     if(tank4event != null &&  triggered==true){
         tank4event();
     }   
    }
}
