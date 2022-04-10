using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidCollision : MonoBehaviour
{
    public GameObject kid;
    public int health;
    public KidBehavior kb;
    public GameObject PowerUp;
    public GameObject GrassFeed;
    private float damageInterval;//Time elapsed since damage was last done to the lawn
    void Start() 
    {
        health = 5;
        damageInterval = 0;
    }
    void Update()
    {
        if (health <= 0)//If kid has been defeated
        {
            Vector3 initialVelocity = kid.GetComponent<Rigidbody>().velocity;
            Debug.Log(FindObjectOfType<GameManager>().NumOfKids);
            FindObjectOfType<GameManager>().NumOfKids--;//Adjust number of kids currently in game
            FindObjectOfType<GameManager>().kidsDefeated++;
            if (FindObjectOfType<GameManager>().kidsDefeated >= 100)
                FindObjectOfType<GameManager>().EndGame();
            //If kid's power up determinant value is a multiple of 24, drop PowerUp
            if (kb.PUpDeterminant % 24 == 0)
            {
             
                Instantiate(PowerUp, kid.transform.position, Quaternion.identity);
                Rigidbody PUpRB = PowerUp.GetComponent<Rigidbody>();
                PUpRB.AddForce(initialVelocity, ForceMode.Impulse);
            }
            //If kid's power up determinant value is a multiple of 21, drop Grass Feed (heal item)
            else if (kb.PUpDeterminant % 21 == 0)
            {

                Instantiate(GrassFeed, kid.transform.position, Quaternion.identity);
                Rigidbody PUpRB = GrassFeed.GetComponent<Rigidbody>();
                PUpRB.AddForce(initialVelocity, ForceMode.Impulse);
            }
            //Increase score by 300 if the kid has not reached the lawn yet, or 100 otherwise.
            if (!kb.onLawn)
            {
                FindObjectOfType<GameManager>().increaseScore(300);

            }
            else
            {
                FindObjectOfType<GameManager>().increaseScore(100);
            }
            Destroy(kid);
        }
    }
    void OnCollisionEnter(Collision collider)
    {
        //Once the kid reaches the lawn, set kid onLawn value to true and set kid's destination to a random spot on the lawn
        if (collider.collider.tag == "Lawn")
        {
            if (!kb.onLawn)
            {
                kb.onLawn = true;
                kb.destination = kb.getRandomCooridinate();
            }
           
        }
        //When the kid is hit by water, decriment health
        if (collider.collider.tag == "Water")
        {
            health--;
        } 
        
    }
    void OnCollisionStay(Collision collider)
    {
        //For every second the kid is on the lawn, decriment the lawn's health by 1. 
        if (collider.collider.tag == "Lawn")
        {
            damageInterval += Time.deltaTime;
            if (damageInterval > 1)
            {

                FindObjectOfType<GameManager>().damageYard(1);
                damageInterval = 0;
            }
        }
    }
}
