using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRig : MonoBehaviour
{
    private Vector3 temp;
    public GameObject myGameObject;
    // Start is called before the first frame update
    public void Left()
    {
        if(myGameObject.GetComponent<Transform>().position.x > -45.0)
        {
            temp = new Vector3(-7.0f * Time.deltaTime, 0, 0);
            myGameObject.GetComponent<Transform>().position += temp;
        }
    }
    public void Right()
    {
        Debug.Log(myGameObject.GetComponent<Transform>().position.x);
        if (myGameObject.GetComponent<Transform>().position.x < 45.0){

            temp = new Vector3(7.0f * Time.deltaTime, 0, 0);
            myGameObject.GetComponent<Transform>().position += temp;
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
