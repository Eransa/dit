using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToReady : MonoBehaviour {
    //用于初次启动时点击到准备画面
    public GameObject StartScreen;//开始界面
    public GameObject StartButton;//开始按钮，用来挂脚本的物体
    public GameObject ReadyScreen;//准备画面
    public GameObject Score;//分数
    public GameObject Blackout;//黑屏
    public GameObject Bird;//鸟
    public AudioSource swooshing;
    private float t,i;//透明化计时、计数
    

	// Use this for initialization
	void Start () {
        
        t = Time.time;//计时初始化
        i = 2;//计数初始化等待鼠标点击
        
    }
	
	// Update is called once per frame
	void Update () {
        if (i <= 1)//接收到点击就让开始屏幕变黑,在黑屏下完成激活,之后遮挡层变透明显出ready界面
        {
            while (Time.time - t > 0.03f)//每0.03s
            {
                
                if (i > 0)//屏幕变黑阶段
                {
                    i -= 0.1f;
                    Blackout.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1 - i);//黑屏透明度逐渐变低
                    if (i <= 0) i = 0;
                }
                else if(i==0.0f)//完全黑屏之后
                {
                    Score.SetActive(true);//激活计分
                    Bird.SetActive(true);//激活鸟
                    StartScreen.SetActive(false);//禁用开始界面
                    ReadyScreen.SetActive(true);//激活准备界面
                    i = -0.01f;
                    StartButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);//隐藏开始按钮
                }
                else
                {

                    i -= 0.1f;
                    Blackout.GetComponent<SpriteRenderer>().color = new Color(-i , -i , -i, 1 + i);//黑幕逐渐变亮变透明直至消失
                    if(i<=-1)
                    {
                        StartButton.SetActive(false);//禁用按钮,脚本结束
                        break;
                    }

                }
                t = Time.time;
            }
        }
	}

    private void OnMouseDown()
    {
        
        StartButton.transform.Translate(new Vector2(0.0f, -0.05f));//按钮按下效果
    }

    private void OnMouseUpAsButton()
    {
       
        StartButton.transform.Translate(new Vector2(0.0f, 0.05f));//按钮弹起效果
        swooshing.Play(0);
        GameManager.state = GameManager.State.Ready;//改变状态
        i = 1;//用于update中方法检测
        

        

    }
}
