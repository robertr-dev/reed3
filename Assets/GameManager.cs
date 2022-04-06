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
        if(SceneManager.GetActiveScene().name == "ProtoType1")
            SceneManager.LoadScene("ProtoType2");
        if (SceneManager.GetActiveScene().name == "ProtoType2")
            Application.Quit();

    }
}
