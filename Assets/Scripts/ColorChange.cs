using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public float alpha = .75f;
    public float r = 178f;
    public float g = 236f;
    public float b = 255f;
    

    void Start()
    {

        GetComponent<SpriteRenderer>().color = new Color(r, g, b, alpha);
        Debug.Log(GetComponent<SpriteRenderer>().color);

    }

     void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(r, g, b, alpha);
    }


}
