using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform firePoint;//Part of the hose water will shoot from
    public GameObject waterballPrefab;//Invisble object fired from hose which determines the damage to kid
    public Rigidbody rb;//Hose's rigidbody component
    public Transform player;//Hose's transform component
    public Transform targetPos;//Invisible object that follows mouse and sets which way the hose will face
    public int targetVelocity = 50;
    public Vector3 startPos;
    private Vector3 initialVelocity;//Initial velocity of waterball
    private int fireRate = 30; //Rate waterball is fired
    private float lastFireTime;//Time elapsed since the last waterball was fired
    private float firePower = .2f; //Force of waterball
    [SerializeField] private Camera cam;
    public int powerUp = 1;//Hose's power level
    public ParticleSystem waterjetPrefab;//Water jet the player sees when hose is fired
  


    void Start()
    {
       
        startPos = player.position;
        lastFireTime = 0;
        powerUp = 1;
        FindObjectOfType<GameManager>().setUpLevel();
       waterjetPrefab.GetComponent<Transform>().position = firePoint.position;//Ensure water jet is aligned to fire point
        

    }
    // Update is called once per frame
    void Update()
    {
        targetPos.LookAt(cam.GetComponent<Transform>().position);
        //Press "w" to move left, "e" to move right
        if (Input.GetKey("w"))
        {
            rb.constraints = RigidbodyConstraints.None;//Allow hose to move.

            rb.AddForce(500 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);//
        }
        else if (Input.GetKey("e"))
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(-500 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else
        {
            //If "w" or "e" are not being pressed, freeze hose in position. 
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;

        }

        if (Input.GetMouseButton(0))
        {

            waterjetPrefab.Play();//Fire water jet, which the player will see.
            //Water balls are the invisible objects in the water jet that will determine damage to the kids.
            //A water ball will be fired at a certain rate determined by lastFireTime and fireRate
            if (lastFireTime > 1500 * Time.deltaTime / fireRate)
                fire();
        }
        else
        {
            waterjetPrefab.Stop();//Halt water jet
        }
        //The following keeps the player within a certain bounds by freezing the player's position when those bounds have been reached
         Vector3 playerPos = player.position;
        if (playerPos.x >= 44.99f)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            player.position += new Vector3(-1,0,0);//Pops the player out of the bounded position so player does not get stuck.
        }
        if (playerPos.x <= -45.01f)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            player.position += new Vector3(1, 0, 0);
        }
        //The following determines which way the hose will face using Raycast
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit))
        {
           targetPos.position = rayCastHit.point;
            
        }
        player.LookAt(targetPos.position);

        lastFireTime += Time.deltaTime;//Update the time elapsed since the last waterball has been fired.
        if (lastFireTime >= 5)
            lastFireTime = 5;
        startPos = playerPos;
        
    }
    public void fire()
    {
        //When it is time to fire a waterball, generate a new waterball object and determine the velocity of the waterball
       GameObject waterball = Instantiate(
            waterballPrefab, 
            firePoint.position,
            Quaternion.identity);
        initialVelocity = (targetPos.position - firePoint.position)*firePower*powerUp;//Adjust velocity vector depending on the target's position
       Rigidbody waterballRB = waterball.GetComponent<Rigidbody>();
       waterballRB.AddForce(initialVelocity, ForceMode.Impulse);
        var main = waterjetPrefab.main;//determine the velocity of the watejet the player will see.
        main.startSpeed = initialVelocity.magnitude;
        lastFireTime =0;
         
    }
    public void PowerUpHose()
    {
        //Update power level and adjust water force and appearance of the water jet.
        powerUp++;
        fireRate *= 2;
        waterjetPrefab.GetComponent<PowerWaterJet>().checkPowerLv();
        if (powerUp >= 3)
            powerUp = 3;
        if (fireRate >= 120)
            fireRate = 120;
    }
}
