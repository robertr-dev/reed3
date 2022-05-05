
using UnityEngine;

public class XtraLifeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject XtraLife;
    int limit;
    public GameObject XtraLifeMessage;
    
    // Update is called once per frame
    void Start()
    {

        limit = 5;
    }
    void Update()
    {
        XtraLife.transform.Rotate(new Vector3(0,1,0));//Sets the power up rotating 
    }
    void OnCollisionEnter(Collision collider)
    {
        
        if (collider.collider.tag == "Water")//As power up is being hit by water, decriment limit
        {
            limit--;
        }
        if(limit <= 0)//Once limit has been reached, increase player's lives
        {
            FindObjectOfType<GameManager>().Lives++;
	FindObjectOfType<DisplayLives>().UpdateLives();
            Destroy(XtraLife);
        }
    }
}
