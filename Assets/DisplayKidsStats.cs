using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayKidsStats : MonoBehaviour
{
public Text kidsStat;
public int kidsDefeated;
int kidsToNextLevel;
    void Start(){
	kidsToNextLevel  = FindObjectOfType<GameManager>().kidsToNextLevel;
	}

    // Update is called once per frame
    void Update()
    {
        kidsStat.color = new Color(1,1,0);
	kidsStat.text = kidsDefeated + "/" + kidsToNextLevel;
    }
}
