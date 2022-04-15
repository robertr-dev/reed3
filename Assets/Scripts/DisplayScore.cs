using UnityEngine.UI;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{

    
	 public Text Score;
	 
	
	

	
    // Update is called once per frame
    void Update()
    {
        Score.color = new Color(0, 0, 1);
        Score.text = "Score: "+ FindObjectOfType<GameManager>().currScore.ToString();
	
	
    }

	
}
