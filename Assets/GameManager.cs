using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public int NumOfKids = 0;
    public int currScore =0;
    public int time;
    public int Lives = 3;
    public int yardHealth;
    public int yardHealthMax = 300;
    public int powerUp2Time;
    public int powerUp3Time;
    public int kidLimit = 5;
    bool gameOver = false;
    public float restartDelay = 2f;
    public GameObject gameOverMessage;
    public int kidsDefeated = 0;
    public int kidsToNextLevel =25;
    public int generationRate = 1;
    public int toXtrLife = 10000;
    public string playersName = "";
    string scoreKey = "score";
    string livesKey = "lives";
    string kidKey = "kids";
    void Start()//Start of Wave 
    {
       
       // FindObjectOfType<HoldPlayerStat>().retrieveInfo();

        Lives = FindObjectOfType<HoldPlayerStat>().Lives;
        currScore = FindObjectOfType<HoldPlayerStat>().Score;
        kidsToNextLevel = FindObjectOfType<HoldPlayerStat>().kidsToNextLevel;
        FindObjectOfType<DisplayKidsStats>().kidsToNextLevel = kidsToNextLevel;
        toXtrLife = 10000 - currScore % 10000;
        kidsDefeated = 0;
        FindObjectOfType<DisplayLives>().UpdateLives();
        setUpLevel();
	
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
	if(toXtrLife<=0){
		toXtrLife += 10000;
		Lives++;
            FindObjectOfType<DisplayLives>().UpdateLives();
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
        
       

        if (Lives <= 0)
        {
            FindObjectOfType<HoldPlayerStat>().UpdateStat(currScore, Lives, kidsToNextLevel); 
            EndGame();
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (kidsDefeated < kidsToNextLevel)
        {
            
            Lives--;
            FindObjectOfType<HoldPlayerStat>().UpdateStat(currScore, Lives, kidsToNextLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        else if (kidsDefeated >= kidsToNextLevel && SceneManager.GetActiveScene().name == "Lv.6 Summer-ocalyspse Now!")
        {
            Lives--;
            FindObjectOfType<HoldPlayerStat>().UpdateStat(currScore, Lives, kidsToNextLevel);
            setUpLevel();
            SceneManager.LoadScene("Lv.1 Lawn Invaders");//We can change this later. For now if you beat the final level, you just restart the game
            
        }
        else
        {
            
            FindObjectOfType<HoldPlayerStat>().UpdateStat(currScore, Lives, kidsToNextLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            setUpLevel();
        }


    }
    public void setUpLevel()
    {
        
        NumOfKids = 0;
        kidsDefeated = 0;
        yardHealth = yardHealthMax;
        Debug.Log("Level Setup");
        if (SceneManager.GetActiveScene().name == "Lv.1 Lawn Invaders")
        {
            level = 1;
            kidLimit = 5;
            kidsToNextLevel = 25;
            generationRate = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.2 Hosefight at the Not O.K. Corral")
        {
            level = 2;
            kidLimit = 6;
            kidsToNextLevel = 35;
            generationRate = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.3 Invasion of the Yard Snatchers")
        {
            level = 3;
            kidLimit = 8;
            kidsToNextLevel = 45;
            generationRate = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Lv. 4 Night of the Living Brats")
        {
            level = 4;
            kidLimit = 10;
            kidsToNextLevel = 50;
            generationRate = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.5 Die Another Snow Day")
        {
            level = 5;
            kidLimit = 12;
            kidsToNextLevel = 75;
            generationRate = 4;
            yardHealthMax = 350;
            yardHealth = yardHealthMax;
        }
        else if (SceneManager.GetActiveScene().name == "Lv.6 Summer-ocalyspse Now!")
        {
            level = 6;
            kidLimit = 12;
            kidsToNextLevel = 100;
            generationRate = 5;
            yardHealthMax = 400;
            yardHealth = yardHealthMax;
        }
    }
    public int getKidsToNextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Lv.1 Lawn Invaders")
        {
            return 25;

        }
        else if (SceneManager.GetActiveScene().name == "Lv.2 Hosefight at the Not O.K. Corral")
        {
            return 35;

        }
        else if (SceneManager.GetActiveScene().name == "Lv.3 Invasion of the Yard Snatchers")
        {
            return 45;

        }
        else if (SceneManager.GetActiveScene().name == "Lv. 4 Night of the Living Brats")
        {
            return 50;

        }
        else if (SceneManager.GetActiveScene().name == "Lv.5 Die Another Snow Day")
        {
            return 75;

        }
        else if (SceneManager.GetActiveScene().name == "Lv.6 Summer-ocalyspse Now!")
        {
            return 100;

        }
        else
            return 1;
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
