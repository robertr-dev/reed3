using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    // Start is called before the first frame update
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome " + theName + " to the game";

        GameObject theplayerN = GameObject.Find("Scenes");
        HighScoreHandler name = theplayerN.GetComponent<HighScoreHandler>();
        name.name = theName;

        GameObject theplayerS = GameObject.Find("Scenes");
        HighScoreHandler score = theplayerS.GetComponent<HighScoreHandler>();
        //score.Score = score;


    }

}
