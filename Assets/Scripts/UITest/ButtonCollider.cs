using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum ButtonType
{
    START,
    QUIT,
    //RESTART,
    PAUSE_TOGGLE,
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H,
    I,
    J,
    K,
    L,
    M,
    N,
    O,
    P,
    Q,
    R,
    S,
    T,
    U,
    V,
    W,
    X,
    Y,
    Z,
    DELETE,
    BACK,
    HIGHSCORE
}

public class ButtonCollider : MonoBehaviour
{
    // Externals
    public GameObject buttonObject;
    public ButtonType type;
    public GameObject pauseMenuUI;
    public InputField input;
  

    // Internals
    private SteamVR_LaserPointer laserPointer;
    private string comparisonString { get { return buttonObject.name; } }
    

    void Awake()
    {
        laserPointer = FindObjectOfType<SteamVR_LaserPointer>(); 
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
        if (type == ButtonType.PAUSE_TOGGLE)
        {
            try
            {
                if (pauseMenuUI ?? true)
                    pauseMenuUI.SetActive(false);
            }
            catch (System.Exception)
            {

            }
        }
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == comparisonString)
        {
            Debug.Log("Cube was clicked");
            switch (type)
            {
                
                case ButtonType.A:
                    if (input.text.Length != 10)
                    {
                        input.text += "A";
                    }
                break;
                case ButtonType.B:
                    if (input.text.Length != 10)
                    {
                        input.text += "B";
                    }
                break;
                case ButtonType.C:
                    if (input.text.Length != 10)
                    {
                        input.text += "C";
                    }
                    break;
                case ButtonType.D:
                    if (input.text.Length != 10)
                    {
                        input.text += "D";
                    }
                    break;
                case ButtonType.E:
                    if (input.text.Length != 10)
                    {
                        input.text += "E";
                    }
                    break;
                case ButtonType.F:
                    if (input.text.Length != 10)
                    {
                        input.text += "F";
                    }
                    break;
                case ButtonType.G:
                    if (input.text.Length != 10)
                    {
                        input.text += "G";
                    }
                    break;
                case ButtonType.H:
                    if (input.text.Length != 10)
                    {
                        input.text += "H";
                    }
                    break;
                case ButtonType.I:
                    if (input.text.Length != 10)
                    {
                        input.text += "I";
                    }
                    break;
                case ButtonType.K:
                    if (input.text.Length != 10)
                    {
                        input.text += "J";
                    }
                    break;
                case ButtonType.J:
                    if (input.text.Length != 10)
                    {
                        input.text += "K";
                    }
                    break;
                case ButtonType.L:
                    if (input.text.Length != 10)
                    {
                        input.text += "L";
                    }
                    break;
                case ButtonType.M:
                    if (input.text.Length != 10)
                    {
                        input.text += "M";
                    }
                    break;
                case ButtonType.N:
                    if (input.text.Length != 10)
                    {
                        input.text += "N";
                    }
                    break;
                case ButtonType.O:
                    if (input.text.Length != 10)
                    {
                        input.text += "O";
                    }
                    break;
                case ButtonType.P:
                    if (input.text.Length != 10)
                    {
                        input.text += "P";
                    }
                    break;
                case ButtonType.Q:
                    if (input.text.Length != 10)
                    {
                        input.text += "Q";
                    }
                    break;
                case ButtonType.R:
                    if (input.text.Length != 10)
                    {
                        input.text += "R";
                    }
                    break;
                case ButtonType.S:
                    if (input.text.Length != 10)
                    {
                        input.text += "S";
                    }
                    break;
                case ButtonType.T:
                    if (input.text.Length != 10)
                    {
                        input.text += "T";
                    }
                    break;
                case ButtonType.U:
                    if (input.text.Length != 10)
                    {
                        input.text += "U";
                    }
                    break;
                case ButtonType.V:
                    if (input.text.Length != 10)
                    {
                        input.text += "V";
                    }
                    break;
                case ButtonType.W:
                    if (input.text.Length != 10)
                    {
                        input.text += "W";
                    }
                    break;
                case ButtonType.X:
                    if (input.text.Length != 10)
                    {
                        input.text += "X";
                    }
                    break;
                case ButtonType.Y:
                    if (input.text.Length != 10)
                    {
                        input.text += "Y";
                    }
                    break;
                case ButtonType.Z:
                    if (input.text.Length != 10)
                    {
                        input.text += "Z";
                    }
                    break;
               
            
                case ButtonType.DELETE:
                    if (input.text.Length != 0)
                    {
                        input.text = input.text.Remove(input.text.Length - 1);
                    }
                break;
                case ButtonType.BACK:
                    SceneManager.LoadScene(0);
                    break;
                case ButtonType.HIGHSCORE:
                    
                    
                    SceneManager.LoadScene(7);
                    break;
                case ButtonType.START:
                    if (input.text.Length != 0) {
                        FindObjectOfType<HighScoreHandler>().Name = input.text;
                        SceneManager.LoadScene(1);
                    }
                    break;
                case ButtonType.QUIT:
                    if (SceneManager.GetActiveScene().buildIndex != 0)
                    {
                        SceneManager.LoadScene(0);
                        input.text = "";
                        FindObjectOfType<HighScoreHandler>().Name = input.text;
                    }
                    else
                    {
                        Application.Quit();
                    }
                    break;
               /* case ButtonType.RESTART:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;
               */
                case ButtonType.PAUSE_TOGGLE:
                    try
                    {
                        if (pauseMenuUI ?? true)
                            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
                        
                    }
                    catch (System.Exception)
                    {
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == comparisonString)
        {
            Debug.Log("Cube was hovered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == comparisonString)
        {
            Debug.Log("Cube was exited");
        }
    }
}
