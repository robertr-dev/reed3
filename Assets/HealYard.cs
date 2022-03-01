using UnityEngine;

public class HealYard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healItem;
    int limit;

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
        if (collider.collider.tag == "Water")
        {
            limit--;
        }
        if (limit <= 0)
        {
            FindObjectOfType<GameManager>().HealYard(50);

            Destroy(healItem);
        }
    }
}
