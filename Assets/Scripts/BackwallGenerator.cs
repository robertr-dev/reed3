using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class BackwallGenerator : MonoBehaviour
{
    public Transform wall;
    public GameObject kid;
    GameObject lawn;
    double wall_to_lawn_dist;
    double wall_minX, wall_maxX;
    double frontYardZ;
    int kidLimit = 5;
    Vector3 kid_destination;
    float timer;
    //TODO: need to pass current level
    public int current_level = 1;
    int counter = 0;
    public int lane_count = 0;
    List<int> LaneTracker = new List<int>();
    const float KidScale = 5.054357F;
    System.Random rnd;
    const float LaneOffset = 0.5F * KidScale;
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        current_level = FindObjectOfType<GameManager>().level; 
        rnd = new System.Random();
        timer = 0;
        //kidLimit = 20;
        kidLimit = FindObjectOfType<GameManager>().kidLimit;
        lawn = GameObject.Find("Lawn");
        frontYardZ = Math.Abs(lawn.transform.position.z - 0.5 * lawn.transform.lossyScale.z);
        wall_minX = lawn.transform.position.x - 0.5 * lawn.transform.lossyScale.x;
        wall_minX += 2;
        wall_maxX = lawn.transform.position.x + 0.5 * lawn.transform.lossyScale.x;
        wall_maxX -= 2;
        lane_count = (int)Math.Floor((wall_maxX - wall_minX) / KidScale);
        //Debug.Log(wall_maxX - wall_minX);
        //Debug.Log(lane_count);
        wall = GameObject.Find("backWall").transform;
        FindObjectOfType<GameManager>().NumOfKids = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int numofKids = FindObjectOfType<GameManager>().NumOfKids;
        //Debug.Log(numofKids + " / " + kidLimit);
        if (timer >= (15 / current_level) && numofKids < kidLimit && !paused)
        {
            
            int roll = rnd.Next(0, 100);
            Debug.Log("Roll: " + roll); ;
            if (roll <= 2)
            {
                //WallMarch();
            }else if(roll > 2 && roll <= 5)
            {
               // ArrowHead();
            }else if(roll > 5 && roll <= 8)
            {
                Sprinters();
            }
            else
            {
                //Debug.Log("option: " + roll);
                Vector3 gen_pos = new Vector3();
                gen_pos.z = wall.position.z + KidScale;
                gen_pos.y = KidScale + 1;
                bool lane_found = false;
                int lane_num = 0;
                while (!lane_found)
                {
                    lane_num = rnd.Next(0, lane_count);
                    if (LaneTracker.Contains(lane_num)) continue;
                    if (LaneTracker.Count < 3)
                    {
                        LaneTracker.Add(lane_num);
                        lane_found = true;
                    }
                    else
                    {
                        LaneTracker.RemoveAt(0);
                        LaneTracker.Add(lane_num);
                        lane_found = true;
                    }
                }

                gen_pos.x = (float)wall_minX + (lane_num * KidScale) + LaneOffset;
                float ran_speed = UnityEngine.Random.Range(0.1F, (float)current_level/20);////////////
                //Debug.Log("ran_speed: " + ran_speed);
                GameObject clone = Instantiate(kid, gen_pos, Quaternion.identity);
                clone.GetComponent<KidMovement>().speed = ran_speed;
                timer = 0;
                
            }
        }
    }

    async void WallMarch()
    {
        while (FindObjectOfType<GameManager>().NumOfKids != 0)
        {
            try
            {
                await Task.Delay(5000); ;//keep looping
            }
            catch (Exception e) { }
        }
        Debug.Log("WallMarch() invoked");
        paused = true;
        try{ 
        await Task.Delay(5000);
       
        for(int i = 0; i < lane_count; ++i)
        {
                Debug.Log("Enter WallMarch loop" );
                Vector3 gen_pos = new Vector3();
            gen_pos.z = wall.position.z + KidScale;
            gen_pos.y = KidScale + 1;
            gen_pos.x = (float)wall_minX + (i * KidScale) + LaneOffset;
            GameObject clone = Instantiate(kid, gen_pos, Quaternion.identity);
            clone.GetComponent<KidMovement>().speed = (float)current_level / 20;/////////
            

        }
        try
        {
            await Task.Delay(10000);
       
        
        timer = 0;
        paused = false;
            }
            catch (Exception e) { }
        }
        catch (Exception e) { }

    }

    async void ArrowHead()
    {
        while (FindObjectOfType < GameManager>().NumOfKids != 0)
        {
            try
            {
                await Task.Delay(5000); ;//keep looping
            }
            catch (Exception e) { }
        }
        Debug.Log("ArrowHead() invoked");
        paused = true;
        try
        {
            await Task.Delay(5000);
       
        int ct = 1;
        int m = lane_count / 2;
        int m_u = m - 1;
        int m_v = m + 1;
        Vector3 gen_pos = new Vector3();
        gen_pos.z = wall.position.z + KidScale;
        gen_pos.y = KidScale + 1;
        gen_pos.x = (float)wall_minX + (m * KidScale) + LaneOffset;
        GameObject clone = Instantiate(kid, gen_pos, Quaternion.identity);
        clone.GetComponent<KidMovement>().speed = (float)current_level / 20;//////////
        
        while(m_u > -1 && m_v < lane_count)
        {
            try
            {
                await Task.Delay(1000);
               Debug.Log("Enter Arrow loop" + m_u + "  " + m_v);
            gen_pos.z = wall.position.z + KidScale;
            gen_pos.y = KidScale + 1;
            gen_pos.x = (float)wall_minX + (m_u * KidScale) + LaneOffset;
            clone = Instantiate(kid, gen_pos, Quaternion.identity);
            clone.GetComponent<KidMovement>().speed = (float)current_level / 10;/////////
            gen_pos.z = wall.position.z + KidScale;
            gen_pos.y = KidScale + 1;
            gen_pos.x = (float)wall_minX + (m_v * KidScale) + LaneOffset;
            clone = Instantiate(kid, gen_pos, Quaternion.identity);
            clone.GetComponent<KidMovement>().speed = (float)current_level / 10;/////////////
            --m_u;
            ++m_v;
            ct += 2;
                    if (ct > 10)
                        break;
                }
                catch (Exception) { } //
        }
            try
            {
                await Task.Delay(10000);
            
        
        paused = false;
        timer = 0;
            }
            catch (Exception e) { }
        }
        catch (Exception e) { }//
    }

    async void Sprinters()
    {
        while (FindObjectOfType < GameManager>().NumOfKids >= kidLimit - current_level)
        {
            try
            {
                await Task.Delay(5000); ;//keep looping
            }
            catch (Exception e) { }
        }
        Debug.Log("Sprinters() invoked");
        paused = true;
            try
            {
                await Task.Delay(5000);
           
        for (int i = 0; i < current_level; ++i)
        {
                Debug.Log("Enter Sprinter loop");
                bool lane_found = false;
            int j = 0;
            int attempts = 0;
            while (!lane_found)
            {
                if (attempts > 10) LaneTracker.Clear();
                j = rnd.Next(0, lane_count);
                if (LaneTracker.Contains(j)) {
                    ++attempts;
                    continue;
                }
                lane_found = true;
            }
            Vector3 gen_pos = new Vector3();
            gen_pos.z = wall.position.z + KidScale;
            gen_pos.y = KidScale + 1;
            gen_pos.x = (float)wall_minX + (j * KidScale) + LaneOffset;
            GameObject clone = Instantiate(kid, gen_pos, Quaternion.identity);
            clone.GetComponent<KidMovement>().speed = (float)current_level * 1.0f;/////////////
                try
                {
                    await Task.Delay(2000);
                }
                catch (Exception e){ };
        }//for-loop
            try
            {
                await Task.Delay(10000);
            
        
        paused = false;
        timer = 0;
            }
            catch (Exception e) { }//
        }
        catch (Exception e) { } //
    }

}
