using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipes : MonoBehaviour
{
    public GameObject Pipe;//生成的管子
    private bool restarted;

    float t,tNow,x,y;//两个计时变量，两个计算坐标变量
    int i;//一个计数取名变量，之所以这样搞是为了方便复制和删除的操作


    // Use this for initialization
    void Start ()
    {
        t = Time.time;//游戏开始时，t取当前时间
        x = this.transform.localPosition.x+8;//水管开始生成的初始横坐标
        i = 0;//计数变量初始为0
        restarted = false;
	}



    // Update is called once per frame
    void Update ()
    {
        if (restarted == true) 
        {
            t = Time.time;//游戏开始时，t取当前时间
            x = GameObject.Find("Bird").transform.position.x + 10;//水管开始生成的初始横坐标
            i = 0;//计数变量初始为0
            restarted = false;
        }
        
        y = UnityEngine.Random.Range(3, 9);//随机计算水管中心的纵坐标以生成高低错落的水管
        tNow = Time.time;//每一帧取一下当前时间
        if(tNow - t >= 5)//如果当前时间与t的差值大于等于5秒，生成水管
        {
            x += 5;//新一根水管的横坐标比上一根偏右5
            GameObject Pipes=GameObject.Instantiate(Pipe,new Vector2 (x,y),Quaternion.identity);//在选定位置生成一对水管,旋转角度默认，并将其设置为水管集合的子物体
            Pipes.transform.SetParent(GameObject.Find("Pipes").transform);
            i++;
            Pipes.name = "p"+i;//给新生成物体命名为p+i
            t = Time.time;//计时器重置，开始新一轮计时

        }
        if (GameManager.state == GameManager.State.End)
        {
            restarted = true;

            GameObject.Find("PipeCreator").SetActive(false);//GetComponent<CreatePipes>().enabled = false;

        }
    }
}
