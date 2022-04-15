using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public int NumOfKids = 0;
    public int currScore;
    public int time;
    public int Lives;
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
    public int toXtrLife;
    void Start()//Start of Wave 
    {
        yardHealth = yardHealthMax;
	toXtrLife = 0;
        currScore = 0;
        kidLimit = 0;
	Lives = 3;
    }
    public void damageYard(int damage)
    {
        yardHealth -= damage;
        if (yardHealth <= 0)
        {
            yardHealth = 0;
	   
            Invoke("RestartLevel", restartDelay);
        }
    }
    public void increaseScore(int scoreIncrease)
    {
        currScore += scoreIncrease;
	toXtrLife -= scoreIncrease;
	if(toXtrLife>=0){
		toXtrLife += 10000;
		Lives++;
	}
	FindObjectOfType<DisplayKidsStats>().kidsDefeated = kidsDefeated;
	
    }
    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;

            
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
	Lives--;
	if (Lives <= 0)
		EndGame();
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

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
/*private const string highscoreURL = "http://rrdev.tech/highS/index.php";

    public List<Score> RetrieveScores()
    {
        List<Score> scores = new List<Score>();
        StartCoroutine(DoRetrieveScores(scores));
        return scores;
    }

    public void PostScores(string name, int score)
    {
        StartCoroutine(DoPostScores(name, score));
    }

    IEnumerator DoRetrieveScores(List<Score> scores)
    {
        WWWForm form = new WWWForm();
        form.AddField("retrieve_leaderboard", "true");

        using (UnityWebRequest www = UnityWebRequest.Post(highscoreURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Successfully retrieved scores!");
                string contents = www.downloadHandler.text;
                using (StringReader reader = new StringReader(contents))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Score entry = new Score();
                        entry.name = line;
                        try
                        {
                            entry.score = Int32.Parse(reader.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Invalid score: " + e);
                            continue;
                        }

                        scores.Add(entry);
                    }
                }
            }
        }
    }

    IEnumerator DoPostScores(string name, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("post_leaderboard", "true");
        form.AddField("name", name);
        form.AddField("score", score);

        using (UnityWebRequest www = UnityWebRequest.Post(highscoreURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Successfully posted score!");
            }
        }
    }


public struct Score
{
    public string name;
    public int score;
}
*/
}
