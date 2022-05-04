using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayerStat : MonoBehaviour
{
    PlayerStatHolder psh= new PlayerStatHolder(0,3,25);
    public int Score = 0;
    public int Lives = 3;
    public int kidsToNextLevel;
    string scoreKey = "score";
    string livesKey = "lives";
    string kidKey = "kids";

    private void Awake()
    {
        
            Debug.Log("Awake: Score: " + Score + " Lives: " + Lives);
       
    }
    void Start()
    {
        Debug.Log("Start: Score: " + Score + " Lives: " + Lives);
    }
    public void UpdateStat( int score, int lives, int kidsToNextLevel)
    {
        Debug.Log("Start: Score: " + Score + " Lives: " + Lives);
        this.Score = score;
        this.Lives = lives;
        this.kidsToNextLevel = kidsToNextLevel;
        PlayerPrefs.SetInt(scoreKey, Score);
        PlayerPrefs.SetInt(livesKey, Lives);
        PlayerPrefs.SetInt(kidKey, kidsToNextLevel);

        //psh.storeInfo(score, lives, kidsToNextLevel);

    }
    public void retrieveInfo()
    {
        this.Score = psh.Score;
        this.Lives = psh.Lives;
        this.kidsToNextLevel = psh.KidsToNextLevel;
    }
}
