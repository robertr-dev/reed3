using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
   public  Transform cam;
    public Transform subject;

    // Update is called once per frame
    void Update()
    {
        cam.position = subject.position + new Vector3(0,5,6);
        
    }
}
