using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject water;
    public Transform waterTr;
    void Update()
    {
        if(waterTr.position.y < -5)
            Destroy(water);
    }
    // Update is called once per frame
    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "Lawn")
        {
           
            Destroy(water);
        }
        if (collider.collider.tag == "Ground")
        {

            Destroy(water);
        }
    }
}
