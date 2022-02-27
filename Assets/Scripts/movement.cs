using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform firePoint;
    public GameObject waterballPrefab;
    public Rigidbody rb;
    public Transform player;
    public Transform targetPos;
    public int targetVelocity = 50;
    public Vector3 startPos;
    private Vector3 initialVelocity;
    private int fireRate = 30; //
    private float lastFireTime;
    private float firePower = .2f; 
    [SerializeField] private Camera cam;
    public int powerUp = 1;

    void Start()
    {
       
     // player.rotation = Quaternion.Euler(target.position + new Vector3(0,90,0)) ;
        startPos = player.position;
        lastFireTime = 0;
        powerUp = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
        //player.Rotate(Input.mousePosition);
        if (Input.GetKey("w"))
        {
            
            rb.AddForce(50 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("e"))
        {
            rb.AddForce(-50 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (!Input.GetKey("w")&&!Input.GetKey("e"))
            rb.velocity = Vector3.zero;

        //targetPos.position = targetPos.position;
        
        
        


        if (Input.GetMouseButton(0) && lastFireTime > 1500*Time.deltaTime/fireRate)
        {
            fire();
        }

       
         Vector3 playerPos = player.position;
        if (playerPos.x >= 44.99f)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            player.position += new Vector3(-1,0,0);
        }
        if (playerPos.x <= -45.01f)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            player.position += new Vector3(1, 0, 0);
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit))
        {
           targetPos.position = rayCastHit.point;
            
        }
        player.LookAt(targetPos.position);

        lastFireTime += Time.deltaTime;
        if (lastFireTime >= 5)
            lastFireTime = 5;
        startPos = playerPos;
        
    }
    public void fire()
    {
        GameObject waterball = Instantiate(
            waterballPrefab,
            firePoint.position,
            Quaternion.identity);
        initialVelocity = (targetPos.position - firePoint.position)*firePower*powerUp;
        Rigidbody waterballRB = waterball.GetComponent<Rigidbody>();
        waterballRB.AddForce(initialVelocity, ForceMode.Impulse);
        lastFireTime =0;
       
    }
    public void PowerUpHose()
    {
        powerUp++;
        fireRate *= 2;
        if (powerUp >= 3)
            powerUp = 3;
        if (fireRate >= 120)
            fireRate = 120;
    }
}
