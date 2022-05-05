using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour
{
    private const string highscoreURL = "http://rrdev.tech/highS/index.php";

    public string Name;
    public int score;
    public Text sc;
    private string h = "";
    private int length = 0;
    List<Score> scores = new List<Score>();

    public void RSC()
    {
        RetrieveScores();
        length = scores.Count;
         for (int i = 0; i < length; i++)
        {
            if(i >= 10)
            {
                break;
            }
            h += i + ".\t" + scores[i].name + "\t" + scores[i].score + "\n\n\n";
            
        }
        sc.text = h;
    }
    public List<Score> RetrieveScores()
    {
        
        StartCoroutine(DoRetrieveScores(scores));
        return scores;
    }

    public void PostScores()
    {
        StartCoroutine(DoPostScores(this.Name, this.score));
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
}

public struct Score
{
    public string name;
    public int score;
}