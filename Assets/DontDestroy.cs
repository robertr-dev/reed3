using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    
   
    // Start is called before the first frame update
    private void Awake()
    {
        //for(int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        //{
            if(Object.FindObjectsOfType<DontDestroy>().Length > 1)
                    Destroy(gameObject);

        // }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
