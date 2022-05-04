using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHolder 
{
   
    public int Score = 0;
    public int Lives = 3;
    public int KidsToNextLevel;
    
    public PlayerStatHolder(int Score, int Lives, int KidsToNextLevel)
    {
       
        this.Score = Score;
        this.Lives = Lives;
        this.KidsToNextLevel = KidsToNextLevel;
    }
    public void storeInfo (int Score, int Lives, int KidsToNextLevel)
    {
       
        this.Score = Score;
        this.Lives = Lives;
        this.KidsToNextLevel = KidsToNextLevel;

    }
    // Start is called before the first frame update

   
   
}
