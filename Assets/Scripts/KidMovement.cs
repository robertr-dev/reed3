using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMovement : MonoBehaviour
{
    public float speed;
    bool jumped;

    // Start is called before the first frame update
    void Start()
    {
        jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.GetComponent<KidBehavior>().onLawn)
        {
            transform.position += new Vector3(0, 0, speed);
        }else if (!jumped)
        {
            jumped = true;
            this.GetComponent<KidBehavior>().rb.AddForce(0, 3000, 8000);
        }
    }
}
