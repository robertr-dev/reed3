using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int NumOfKids;
    public int Score;
    public int time;
    public int yardHealth;
    public int powerUp2Time;
    public int powerUp3Time;
    bool gameOver = false;
    public float restartDelay = 2f;
    public GameObject gameOverMessage;
    void Start()//Start of Wave 
    {
        yardHealth = 300;
        Score = 0;
    }
    public void damageYard(int damage)
    {
        yardHealth -= damage;
        if (yardHealth <= 0)
        {
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
    public void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name == "ProtoType1")
            SceneManager.LoadScene("ProtoType2");
        if (SceneManager.GetActiveScene().name == "ProtoType2")
            Application.Quit();

    }
}
