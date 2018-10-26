using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipes : MonoBehaviour
{
    public GameObject Pipe;
    float t,CurrentTime,x;
    int i;


    // Use this for initialization
    void Start ()
    {
        t = Time.time;
        x = 5;

        i = 0;
        

	}



    // Update is called once per frame
    void Update ()
    {
        float y;
        
        y = UnityEngine.Random.Range(3, 12);
        CurrentTime = Time.time;
        if(CurrentTime - t >= 5)
        {
            x += 5;
            GameObject select = GameObject.Find("Original");
            GameObject Pipes=Transform.Instantiate(select,Pipe.transform.position=new Vector3(x, y, 0),transform.rotation);
            i++;
            Pipes.name = "p"+i;
            t = Time.time;

        }
        
    }
}
