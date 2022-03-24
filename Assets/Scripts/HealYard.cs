using UnityEngine;

public class HealYard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healItem;
    int limit;//How many times the player must hit power-up before activating it.

    // Update is called once per frame
    void Start()
    {

        limit = 5;
    }
    void Update()
    {
        healItem.transform.Rotate(new Vector3(0, 1, 0));
    }
    void OnCollisionEnter(Collision collider)
    {

        if (collider.collider.tag == "Water")//As the player hits the power up with water, decriment limit
        {
            limit--;
        }
        if (limit <= 0)//Once limit has been reached, heal yard by 50 and clear power up from field.
        {
            FindObjectOfType<GameManager>().HealYard(50);

            Destroy(healItem);
        }
    }
}
