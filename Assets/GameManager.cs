using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int NumOfKids = 0;
    public int Score;
    public int time;
    public int yardHealth;
    public int yardHealthMax = 300;
    public int powerUp2Time;
    public int powerUp3Time;
    public int kidLimit = 10;
    bool gameOver = false;
    public float restartDelay = 2f;
    public GameObject gameOverMessage;
    public int kidsDefeated = 0;
    public int kidsToNextLevel;
    public int generationRate;
    
    void Start()//Start of Wave 
    {
        yardHealth = yardHealthMax;
        Score = 0;
        kidLimit = 0;
    }
    public void damageYard(int damage)
    {
        yardHealth -= damage;
        if (yardHealth <= 0)
        {
            yardHealth = 0;
            EndGame();
        }
    }
    public void increaseScore(int scoreIncrease)
    {
        Score += scoreIncrease;
    }
    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;

            Invoke("RestartLevel", restartDelay);
        }

    }
    public void HealYard(int heal)
    {
        yardHealth += heal;
        if (yardHealth >= yardHealthMax)
            yardHealth = yardHealthMax;
    }
    public void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(kidsDefeated < kidsToNextLevel)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if(kidsDefeated >= kidsToNextLevel && SceneManager.GetActiveScene().name == "Lv.6 Summer - ocalyspse Now!")
            SceneManager.LoadScene("Lv.1 Lawn Invaders");//We can change this later. For now if you beat the final level, you just restart the game
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void setUpLevel()
    {
        Score = 0;
        NumOfKids = 0;
        kidsDefeated = 0;
        yardHealth = yardHealthMax;

        if (SceneManager.GetActiveScene().name == "Lv.1 Lawn Invaders")
        {
            kidLimit = 5;
            kidsToNextLevel = 25;
            generationRate = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.2 Hosefight at the Not O.K. Corral")
        {
            kidLimit = 6;
            kidsToNextLevel = 35;
            generationRate = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.3 Invasion of the Yard Snatchers")
        {
            kidLimit = 8;
            kidsToNextLevel = 45;
            generationRate = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Lv. 4 Night of the Living Brats")
        {
            kidLimit = 10;
            kidsToNextLevel = 50;
            generationRate = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.5 Die Another Snow Day")
        {
            kidLimit = 12;
            kidsToNextLevel = 75;
            generationRate = 4;
            yardHealthMax = 350;
            yardHealth = yardHealthMax;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.6 Summer-ocalyspse Now!")
        {
            kidLimit = 12;
            kidsToNextLevel = 100;
            generationRate = 5;
            yardHealthMax = 400;
            yardHealth = yardHealthMax;
        }
    }
}
