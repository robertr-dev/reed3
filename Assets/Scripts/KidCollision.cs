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
    private float damageInterval;
    void Start() 
    {
        health = 5;
        damageInterval = 0;
    }
    void Update()
    {
        if (health <= 0)
        {
            Vector3 initialVelocity = kid.GetComponent<Rigidbody>().velocity;
            
            FindObjectOfType<GameManager>().NumOfKids--;
            if (kb.PUpDeterminant % 24 == 0)
            {
             
                Instantiate(PowerUp, kid.transform.position, Quaternion.identity);
                Rigidbody PUpRB = PowerUp.GetComponent<Rigidbody>();
                PUpRB.AddForce(initialVelocity, ForceMode.Impulse);
            }
            else if (kb.PUpDeterminant % 21 == 0)
            {

                Instantiate(GrassFeed, kid.transform.position, Quaternion.identity);
                Rigidbody PUpRB = GrassFeed.GetComponent<Rigidbody>();
                PUpRB.AddForce(initialVelocity, ForceMode.Impulse);
            }
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
        if (collider.collider.tag == "Lawn")
        {
            if (!kb.onLawn)
            {
                kb.onLawn = true;
                kb.destination = kb.getRandomCooridinate();
            }
           
        }
        if (collider.collider.tag == "Water")
        {
            health--;
        } 
        
    }
    void OnCollisionStay(Collision collider)
    {
        if (collider.collider.tag == "Lawn")
        {
            damageInterval += Time.deltaTime;
            Debug.Log("On Lawn: " + damageInterval);
            if (damageInterval > 1)
            {

                FindObjectOfType<GameManager>().damageYard(1);
                damageInterval = 0;
            }
        }
    }
}
