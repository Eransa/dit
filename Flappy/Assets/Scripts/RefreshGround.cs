﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshGround : MonoBehaviour {

    public GameObject Ground;//刷新生成地面
    float t, tNow,x;//定义两个计时变量，一个坐标变量
    int i;//计数变量

	// Use this for initialization
	void Start ()
    {
        t = Time.time;//游戏开始时，t取当前时间
        x = 10;//地面开始生成时的横坐标
        i = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        tNow = Time.time;//每一帧取一下当前时间
        if (tNow - t >= 20)//如果当前时间与t的差值大于等于20秒，刷新生成地面
        {
            x += 20;//新一地面的横坐标比上一根偏右20
            GameObject select = GameObject.Find("g"+i);//查找上一轮生成的地面
            Destroy(select, 0);//摧毁上一轮生成的地面
            GameObject Refreshed=Transform.Instantiate(Ground, Ground.transform.position = new Vector3(x, -9.5f, 0), transform.rotation);//生成新地面
            i++;
            Refreshed.name = "g" + i;//给新地面命名
            t = Time.time;//计时器归零
        }

    }
}
