using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Variable Bar");
        // bar.localScale = new Vector3(.6f, 1f);
    }

    public void setSize(float sizeNormalized){
        bar.localScale = new Vector3(sizeNormalized, .5f);
    }

}
