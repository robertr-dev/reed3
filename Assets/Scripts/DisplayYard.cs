using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DisplayYard : MonoBehaviour
{
    //public TextMeshProUGUI Yard;
    public TextMesh Yard;
    //public Text Yard;

    // Update is called once per frame
    void Update()
    {
        Yard.color = new Color(0, 1, 0);
        Yard.text = "Yard: " + FindObjectOfType<GameManager>().yardHealth.ToString();
    }
}
