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

    public Slider slider2;
    public Slider slider4;

    public Trigger1 trigger1;
    public Trigger2 trigger2;
    public Trigger3 trigger3;
    public Trigger4 trigger4;
    public static double plevel = 0f;
    public static double nlevel = 0f;
    public Text pLevelTxt = null;
    public Text nLevelTxt = null;
    public float sliderVal = 0f;
    private bool change = false;
    public LightIndicator light;
    // full nbar is at 2.75f 
    // full pbar is at 2.91f
    float n1, n3, p1, p2, p3, p4 = 0f;
    public float airflow1, airflow2 = 0f;
    float r, start = 0f;

    float timer = 3f;
    float delay = 3f;


    // Start is called before the first frame update
    public void Start()
    {
        DontDestroyOnLoad(this);
        
        r = Random.Range(0f, .5f);
        
        trigger1.tank1event += setN1;
        trigger1.tank1event += setP1;
    
        trigger2.tank2event += setN2;
        trigger2.tank2event += setP2;
        trigger2.tank2event += decreaseP2;
        
        trigger3.tank3event += decreaseN3;
        trigger3.tank3event += increaseP3;
        trigger3.tank3event += setP3;

        trigger4.tank4event += setN4;
        trigger4.tank4event += setP4;
        trigger4.tank4event += decreaseP4;

    }

    //Workig with Nitrogen
    public void setN1()
    {

        timer -= Time.deltaTime;
        if (n1 < 2.4f)
        {
            n1 += .0035f;
        }
        else
        {
            float dec = Random.Range(-.3f, .02f);
            if (dec > -.1) {
                light.redLight();
                }
            else {
                light.yellowLight();
            }
            n1 += dec;
        }
        nitrogenbar1.setSize(n1);
    }

    public void setN2()
    {

        nitrogenbar2.setSize(nitrogenbar1.getSize()*.8f);
    }

    public void setN3()
    {
        
        nitrogenbar3.setSize(nitrogenbar2.getSize()*.5f);
        n3 = nitrogenbar2.getSize();
        r = Random.Range(0f, .8f);
    }

    public void setN4()
    {
        nitrogenbar4.setSize(nitrogenbar3.getSize()*.27f); 
        nlevel = System.Math.Round((nitrogenbar4.getSize()/2.75f), 2);
        nLevelTxt.text = "N:" + nlevel*100f + "%";
    }

    float decn1 = 0f;
    public void decreaseN1()
    {
        
        if( n1 > 1)
        {
            decn1 = nitrogenbar1.getSize();
            decn1 -= .008f;
            nitrogenbar2.setSize(decn1);
        }
    }

    public void decreaseN3()
    {
       
        float decreaseRate = 0.1f;
        
        if(n3 < 2.3f){
            setN3();
            } else {
            n3 -= decreaseRate;
            nitrogenbar3.setSize(n3);
            Debug.Log(n3);
        }
       
    }


    //working with Phosphorus

    public void setP1()
    {

        if (p1 < 2.5)
        {
            p1 += .0035f;
        }
        else
        {
            p1 += Random.Range(-.2f, -.0025f);
        }

        if (p1 >= 2.97)
        {
            p1 += Random.Range(-.1f, .0035f);
        }
        phosphorusbar1.setSize(p1);
    }

    public void setP2()
    { 
            if(airflow1 == 0){
            p2 = phosphorusbar1.getSize();
        } else {
            p2 = phosphorusbar1.getSize()*airflow1;

        }
            phosphorusbar2.setSize(p2);  
    }
    public void setP3()
    { 
            phosphorusbar3.setSize(phosphorusbar2.getSize());
    }
     public void setP4()
    {
       if(airflow2 == 0){
            p4 = phosphorusbar3.getSize();
        } else {
            p4 = phosphorusbar3.getSize()*airflow2;
        }
        phosphorusbar4.setSize(p4);
        plevel = System.Math.Round((phosphorusbar4.getSize()/2.91f), 2);
        pLevelTxt.text = "P:" + plevel*100f + "%";
    }


       public void decreaseP2()
    {
        airflow1 = 1.01f-(slider2.value/0.05f);
 
    }

    
    public void increaseP3 ()
    {
        float size = phosphorusbar3.getSize();
        if(size>2 && size<2.91){    
            p3 += .001f;
            phosphorusbar3.setSize(size + p3);
        }
    }

   

    public void decreaseP4()
    {
        airflow2 = 1.01f-(slider4.value/0.05f);
   
        
    }

}

