using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayNight : MonoBehaviour
{
    public float time;
    public TimeSpan currenttime;
    public Light Sun;
    //public Text timetext;
    public int days;

    public float intensity;
    public Color day = new Color(80f, 94.1f, 100f);
    public Color night = new Color(0f, 14.1f, 20f);

    public int speed;

    // Update is called once per frame
    // void Start(){
    //     DontDestroyOnLoad(this);
    // }
    void Update()
    {

        ChangeTime();
        // triggerEndscene();
    }

    public void triggerEndscene(){
        if(RenderSettings.fogColor == night){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ChangeTime()
    {


        time += Time.deltaTime + speed;
        if (time > 65400)
        {
            days += 1;
            time = 0;
        }

       
        currenttime = TimeSpan.FromSeconds(time);
    //    string[] temptime = currenttime.ToString().Split(":"[0]);
     //   timetext.text = temptime[0] + ":" + temptime[1];

        Sun.transform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));
        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;

        }
        else
        {
            intensity = 1 - ((43200 - time) / 43200 * -1);
        }

        RenderSettings.fogColor = Color.Lerp(night, day, intensity * intensity);
        Sun.intensity = intensity;

    }
}
