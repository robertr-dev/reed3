using UnityEngine.UI;
using UnityEngine;

public class DisplayLives : MonoBehaviour
{

    public Text Lives;
    private int Lf = 3;
    
    // Update is called once per frame
    void Update()
    {
        Lives.color = new Color(1,1,1);
        Lives.text = "Lives: " + Lf;
    }
    public void UpdateLives()
    {
        Lf = FindObjectOfType<GameManager>().Lives;
    }
}
