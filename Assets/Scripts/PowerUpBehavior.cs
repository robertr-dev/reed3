
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject PowerUp;
    int limit;
    public GameObject powerUpMessage;
    
    // Update is called once per frame
    void Start()
    {

        limit = 5;
    }
    void Update()
    {
        PowerUp.transform.Rotate(new Vector3(0,1,0));//Sets the power up rotating 
    }
    void OnCollisionEnter(Collision collider)
    {
        
        if (collider.collider.tag == "Water")//As power up is being hit by water, decriment limit
        {
            limit--;
        }
        if(limit <= 0)//Once limit has been reached, increase player's lives
        {
            FindObjectOfType<movement2>().PowerUpHose();
            FindObjectOfType<DisplayPowerUp>().UpdatePowerLevel();

            Destroy(PowerUp);
        }
    }
}
