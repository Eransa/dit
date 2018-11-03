using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePipes : MonoBehaviour {//删除冗余水管
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    private void OnTriggerEnter2D(Collider2D collision)//当水管进入用于删除的碰撞体时
    { if(collision.tag=="Pipe")
        Destroy(collision.gameObject,0);//清除水管物体
    }
}
