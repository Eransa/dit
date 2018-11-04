using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshGround : MonoBehaviour {

    public GameObject Ground;//刷新生成地面
    public GameObject Bird;
    float t, tNow,x;//定义两个计时变量，一个坐标变量
    private bool restarted;
    

	// Use this for initialization
	void Start ()
    {
        restarted = false;
        t = Time.time;//游戏开始时，t取当前时间
        x = 10;//地面开始生成时的横坐标
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(GameManager.state == GameManager.State.reReady && restarted == true)
        {
            restarted = false;
            t = Time.time;
            Ground.transform.position = new Vector2(Bird.transform.position.x, -9.5f);
            x = Bird.transform.position.x;
            //地面保留上次的横坐标
        }
        tNow = Time.time;//每一帧取一下当前时间
        if (tNow - t >= 4)//如果当前时间与t的差值大于等于20秒，刷新生成地面
        {
            x += 12;//新一地面的横坐标比上一根偏右20
            Ground.transform.position = new Vector2(x, -9.5f);//移动地面
            
            
            t = Time.time;//计时器归零
        }
        if(GameManager.state == GameManager.State.End)
        {
            restarted = true;
            GameObject.Find("GroundLong").GetComponent<RefreshGround>().enabled = false;
        }

    }
}
