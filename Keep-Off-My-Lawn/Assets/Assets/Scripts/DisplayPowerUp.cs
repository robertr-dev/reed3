using UnityEngine.UI;
using UnityEngine;

public class DisplayPowerUp : MonoBehaviour
{

    public Text PowerLv;
    private int pLv = 1;
    
    // Update is called once per frame
    void Update()
    {
        PowerLv.color = new Color(1, 0, 0);
        PowerLv.text = "Power Lv: " + pLv;
    }
    public void UpdatePowerLevel()
    {
        pLv = FindObjectOfType<movement>().powerUp;
    }
}
