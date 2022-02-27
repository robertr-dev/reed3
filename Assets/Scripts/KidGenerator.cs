using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidGenerator : MonoBehaviour
{
    public Transform generator;
    public GameObject kid;
    float timer;
    int nextGen;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        nextGen = Random.Range(10,20);
        FindObjectOfType<GameManager>().NumOfKids = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int numofKids = FindObjectOfType<GameManager>().NumOfKids;
        timer += Time.deltaTime;
        if(timer >= nextGen && numofKids <= 10)
        {
            Instantiate(kid, generator.position, Quaternion.identity);
            timer = 0;
            nextGen = Random.Range(5, 15);
            FindObjectOfType<GameManager>().NumOfKids++;
        }
    }
}
