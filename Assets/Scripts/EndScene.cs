using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public Text myText;
    // double nlevel, plevel = 0f;
    // public GameHandler = prevGH;

    // void Start(){
    //     GameHandler prevGH = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    // }

    public void PlayAgain(){
        Debug.Log("Attempting to play again");
        SceneManager.LoadScene("OWASA");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("quit");
    }
    void Update(){
        checkNutrients();
    }

    public void checkNutrients(){
        double nlevel = GameHandler.nlevel;
        double plevel = GameHandler.plevel;
        // myText.text = nlevel.ToString();
        if(nlevel < .1f && plevel < .1f){
            myText.text = "Nitrogen: " + (nlevel*100).ToString() + "% Phosphorus:" + (plevel*100).ToString() + "% \n Congratulations you earned your Water Environmentalist Certificate! You now know how OWASA takes care of our water for us! OWASA is proud of you.";
            // Debug.Log("FUCK YEAH YOU EARNED WATER CERTIFICATE YA FUCKKK");
        } else {
            myText.text = "Nitrogen: " + (nlevel*100).ToString() + "% Phosphorus:" + (plevel*100).ToString() + "% \n Oh no! The resulting nutrient levels were not below 10%! Fishes from nearby streams are struggling to live with saturated nutrients in their pond! Play again to help the fishes survive!";
            // Debug.Log(nlevel + plevel);
        }
    }

    
    
}
