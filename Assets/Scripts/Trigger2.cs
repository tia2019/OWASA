using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trigger2 : MonoBehaviour
{
    public event Action tank2event;
    Boolean triggered = false;
    // Start is called before the first frame update
    
    public void OnTriggerEnter2D(Collider2D other){
        triggered = true;
        // Debug.Log("Tank1 collided successful");
    }
    // Update is called once per frame
    void Update()
    {
     if(tank2event != null &&  triggered==true){
         tank2event();
     }   
    }
}
