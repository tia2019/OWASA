using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    [SerializeField] public NBarAir nitrogenbar1;
    [SerializeField] public NBarAir nitrogenbar2;
    [SerializeField] public NBarAir nitrogenbar3;
    [SerializeField] public NBarAir nitrogenbar4;


    [SerializeField] public PBarAir phosphorusbar1;
    [SerializeField] public PBarAir phosphorusbar2;
    [SerializeField] public PBarAir phosphorusbar3;
    [SerializeField] public PBarAir phosphorusbar4;

    public float plevel = 0f;
    public float nlevel = 0f;
    public Text pLevelTxt = null;
    public Text nLevelTxt = null;
    public float sliderVal = 0f;
    private bool change = false;

    // full nbar is at 2.75f 
    // full pbar is at 2.91f
    float n1, p1, p2, p3, p4 = 0;
    float n3 = 1;
    float r, start = 0;




    // Start is called before the first frame update
    public void Start()
    {
        r = Random.Range(0f, .5f);

    }

    private void Update()
    {
        InvokeRepeating("setN1", 0f, 5f);
        InvokeRepeating("setP1", 0f, 5f);
        InvokeRepeating("decreaseN1", 7f, 6f);

        InvokeRepeating("setN2", 15f, 3f);
        Invoke("setP2", 15f);
        InvokeRepeating("decreaseP2", 15f, 80f);

        InvokeRepeating("setN3", 30f, 18f);
        Invoke("setP3", 30f);
        InvokeRepeating("decreaseN3", 33f, 6f);
        InvokeRepeating("increasingP3", 33f, 5f);

        InvokeRepeating("setN4", 48f, 3f);
        Invoke("setP4", 48f);
        InvokeRepeating("decreaseP4", 48f, 10f);
        
    }


    //Workig with Nitrogen
    public void setN1()
    {
        if (n1 < 2.75)
        {
            nitrogenbar1.setSize(n1);
            n1 += .0035f;
        }
    }

    public void setN2()
    {

        nitrogenbar2.setSize(nitrogenbar1.getSize());
    }

    public void setN3()
    {
        nitrogenbar3.setSize(nitrogenbar2.getSize());
        r = Random.Range(0f, .8f);

    }

    public void setN4()
    {
        bool error = true;
        if (!error)
        {
            nitrogenbar4.setSize(nitrogenbar3.getSize()); //IDK WHY BAR 4 ISNT WORKING
        }
        nlevel = nitrogenbar4.getSize();
    }

    public void decreaseN1()
    {

        if( n1 > 1)
        {
            nitrogenbar1.setSize(n1);
            n1 -= .008f;
        }
    }

    public void decreaseN3()
    {

        if (n3 > r)
        {
            nitrogenbar3.setSize(n3);
            n3 -= .004f;
        }
        else
        {
            n3 = n1;
        }


    }


    //working with Phosphorus

    public void setP1()
    {

        if (p1 < 2.9)
        {
            phosphorusbar1.setSize(p1);
            p1 += .0035f;
        }
    }

    public void setP2()
    {
        if (start == 0f)
        {
            Debug.Log("Tank 2 started");
            phosphorusbar2.setSize(phosphorusbar1.getSize());
            start++;
        }
    }

    public void decreaseP2()
    {

        float size = phosphorusbar2.getSize();
        float airflow = phosphorusbar2.getAirflow();
        //todo work on chaging speed of decreease
        if (p2 <= airflow)
        {

            p2 += airflow * .0001f;
        }
        else
        {
            p2 -= airflow *.0001f;
        }

        if (size - p2 > 1)
        {
            size -= p2;
            phosphorusbar2.setSize(size);
        }
        else
        {
            while (size < 1.8)
            {
                size += .00001f;
                phosphorusbar2.setSize(size);
            }
        }
    }

    public void setP3()
    {
        if (start == 1)
        {
            Debug.Log("Tank 3 started");
            phosphorusbar3.setSize(phosphorusbar2.getSize());
            start++;
        }
       
    }

    public void increasingP3 ()
    {
        float size = phosphorusbar3.getSize();
        p3 = .001f;
        if (p3 + size < 2.6)
        {
            phosphorusbar3.setSize(size + p3);
        }
        else
        {
            phosphorusbar3.setSize(2.5f);
        }
    }

    public void setP4()
    {
        if (start == 2)
        {
            phosphorusbar4.setSize(phosphorusbar3.getSize());
            start++;
        }
;

    }

    public void decreaseP4()
    {
        if (start == 2)
        {
            Debug.Log("Set p4 is called");
            start++;
        }
        float size = phosphorusbar4.getSize();
        float airflow = phosphorusbar4.getAirflow();
        if (p4 <= airflow)
        {
            p4 += airflow * .0001f;
        }
        else
        {
            p4 -= airflow * .0001f;
        }

        if (size - p4 > .2)
        {
            size -= p4;
            phosphorusbar4.setSize(size);
        }
        else
        {
            while (size < 1)
            {
                size += .001f;
                phosphorusbar4.setSize(size);
            }
        }
        plevel = phosphorusbar4.getSize();
        pLevelTxt.text = "P:" + plevel.ToString();
        nlevel = nitrogenbar3.getSize();
        nLevelTxt.text = "N:" + nlevel.ToString();
    }




}

