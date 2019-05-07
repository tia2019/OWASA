using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIndicator : MonoBehaviour
{
    public Sprite redOn;
    public Sprite yellowOn;
  
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = redOn;
    }

    // Update is called once per frame
    public void redLight() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = redOn;
        return;
    }   

    public void yellowLight(){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = yellowOn;

            return;
    }
        



    void Update()
    {



    }
}

