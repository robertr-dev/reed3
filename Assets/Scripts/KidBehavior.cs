using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROTOTYPE KID BEHAVIOR
public class KidBehavior : MonoBehaviour
{
    public GameObject Lawn;
    public Rigidbody rb;
    public Transform tr;
    public Vector3 destination;
    public bool onLawn = false;
    public int PUpDeterminant;//Value that determines a random item dropped once the kid has been defeated
    
    void Start()
    {
        destination = new Vector3(tr.position.x, 6, -45);
        PUpDeterminant = Random.Range(1,25);//Set randomly determined drop item
	    Debug.Log(destination);
    }
    // Update is called once per frame
    void Update()
    {
        //In the instance the kid object falls out the game area, destroy kid object. May want to expand this for instances
        //kids find themselves in an unreachable area.
        if (tr.position.y < -5)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().NumOfKids--;
        }

        Vector3 diff = new Vector3(0,0,0);

        if (onLawn)
        {
            if (tr.position.x >= 45)
                rb.velocity = Vector3.zero;
              //  rb.constraints = RigidbodyConstraints.FreezePositionX;
            if (tr.position.x <= -45)
                rb.velocity = Vector3.zero;

            //  rb.constraints = RigidbodyConstraints.FreezePositionX;
            if (tr.position.z >= 0)
                rb.velocity = Vector3.zero;

            // rb.constraints = RigidbodyConstraints.FreezePositionZ;
            if (tr.position.z <= -60)
                rb.velocity = Vector3.zero;

            // rb.constraints = RigidbodyConstraints.FreezePositionZ;


            //If kid hasn't reached their destination, continue toward destination.
            //or else randomly determine a new destination
            if (tr.position != destination)
            {
                diff = destination - tr.position;
                rb.AddForce(diff.x * 2000 * Time.deltaTime, 0, diff.z * 2000 * Time.deltaTime);
            }
            else
            {
                rb.velocity = -rb.velocity;
                destination = getRandomCooridinate();
            }
            // rb.constraints = RigidbodyConstraints.None;
        }


    }
    public Vector3 getRandomCooridinate()
    {
       //Return a random destination on the Lawn
        return new Vector3(Random.Range(-45,45), tr.transform.position.y, Random.Range(-50,0) );

    }
}
