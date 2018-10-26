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
    {
        Destroy(collision.gameObject, 3);//在3秒后清除水管物体，3秒时间差是为了避免水管还在游戏画面中时就被删除
    }
}
