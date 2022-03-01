
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject powerUp;
    int limit;
    public GameObject powerUpMessage;
    
    // Update is called once per frame
    void Start()
    {

        limit = 5;
    }
    void Update()
    {
        powerUp.transform.Rotate(new Vector3(0,1,0));
    }
    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "Water")
        {
            limit--;
        }
        if(limit <= 0)
        {
            FindObjectOfType<movement>().PowerUpHose();
            FindObjectOfType<DisplayPowerUp>().UpdatePowerLevel();
            Destroy(powerUp);
        }
    }
}
