using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject water;//Refers to the invisible waterball object that determines damage to kid
    public Transform waterTr;
    void Update()
    {
        //In the instance a waterball falls out of the game area, eliminate waterball object
        if(waterTr.position.y < -5)
            Destroy(water);
    }
    // Update is called once per frame
    void OnCollisionEnter(Collision collider)
    {
        //Destroy waterball when waterball has hit the lawn/ground
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
