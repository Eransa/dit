using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipes : MonoBehaviour
{
    public GameObject Pipe;//生成管子
    float t,tNow,x,y;//两个计时变量，两个计算坐标变量
    int i;//一个计数取名变量，之所以这样搞是为了方便复制和删除的操作


    // Use this for initialization
    void Start ()
    {
        t = Time.time;//游戏开始时，t取当前时间
        x = 5;//水管开始生成的初始横坐标
        i = 0;//计数变量初始为0
	}



    // Update is called once per frame
    void Update ()
    {
        
        
        y = UnityEngine.Random.Range(3, 12);//随机计算水管中心的纵坐标以生成高低错落的水管
        tNow = Time.time;//每一帧取一下当前时间
        if(tNow - t >= 5)//如果当前时间与t的差值大于等于5秒，生成水管
        {
            x += 5;//新一根水管的横坐标比上一根偏右5
            GameObject select = GameObject.Find("Original");//为了避免克隆体几何级数增长，通过查找物体名选择原始物体进行克隆
            GameObject Pipes=Transform.Instantiate(select,Pipe.transform.position=new Vector3(x, y, 0),transform.rotation);//在选定位置生成一对水管
            i++;
            Pipes.name = "p"+i;//给新生成物体命名为p+i
            t = Time.time;//计时器重置，开始新一轮计时

        }
        
    }
}
