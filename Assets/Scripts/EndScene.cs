using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    
    GameHandler prevGH = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    double nlevel, plevel = 0f;

    void Update(){
        checkNutrients();
    }

    public void checkNutrients(){
        nlevel = GameHandler.nlevel;
        plevel = GameHandler.plevel;

        if(nlevel < 10 && plevel < 10){
            Debug.Log("FUCK YEAH YOU EARNED WATER CERTIFICATE YA FUCKKK");
        }
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("quit");
    }
    
}
