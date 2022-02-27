using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidBehavior : MonoBehaviour
{
    public GameObject Plane;

    // Start is called before the first frame update
    public Rigidbody rb;
    public Transform tr;
    public Vector3 destination;
    public bool onLawn = false;
    public int PUpDeterminant;
    
    void Start()
    {
        destination = Plane.transform.position;
        PUpDeterminant = Random.Range(1,25);
    }
    // Update is called once per frame
    void Update()
    {
        if (tr.position.y < -5)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().NumOfKids--;
        }

        Vector3 diff = new Vector3(0,0,0);

        if (onLawn)
        {
            if (tr.position.x >= 45)
                rb.constraints = RigidbodyConstraints.FreezePositionX;
            if (tr.position.x <= -45)
                rb.constraints = RigidbodyConstraints.FreezePositionX;
            if (tr.position.z >= -5)
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
            if (tr.position.z <= -30)
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
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
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    public Vector3 getRandomCooridinate()
    {
       
        return new Vector3(Random.Range(-45,45), Plane.transform.position.y, Random.Range(-30,-5) );

    }
}
