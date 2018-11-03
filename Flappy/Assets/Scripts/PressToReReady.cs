using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToReReady : MonoBehaviour
{
    //用于游戏结束后点击回到准备画面
    public GameObject EndScreen;//结束画面
    public GameObject AgainButton;//重玩按钮
    public GameObject ReadyScreen;//准备画面
    public GameObject Score;//分数
    public GameObject Blackout;//黑幕
    public GameObject Bird;//鸟
    public Rigidbody2D bird;//鸟的刚体
    public AudioSource swooshing;
    private float t, i;//透明化计时、计数
    private bool isInited;//是否初始化,由于要重复使用多次,每次激活都要调用一下

    void Init()//初始化
    {
 
        AgainButton.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        t = Time.time;
        i = 2;
        isInited = true;
    }

    // Use this for initialization
    void Start()
    {
        //由于要调用多次，start里只留下用于第一次初始化的代码
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        if (isInited == false)//重复激活时初始化
        {
            Init();
        }
        if (i <= 1)
        {
            while (Time.time - t > 0.03f)
            {

                if (i > 0)
                {
                    i -= 0.1f;
                    Blackout.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1 - i);
                    if (i <= 0) i = 0;
                }
                else if (i == 0.0f)
                {
                    GameManager.score = 0;
                    Bird.SetActive(false);
                    Bird.transform.localPosition = new Vector2(-2.04f, 0.35f);
                    bird.velocity = new Vector2(0, 0);
                    Bird.transform.rotation = new Quaternion();
                    Bird.GetComponent<FlyBird>().enabled = false;
                    Bird.GetComponent<PlengBird>().enabled = true;
                    Score.SetActive(true);
                    Bird.SetActive(true);
                    EndScreen.SetActive(false);
                    ReadyScreen.SetActive(true);
                    i = -0.01f;
                    AgainButton.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                }
                else
                {

                    i -= 0.1f;
                    Blackout.GetComponent<SpriteRenderer>().color = new Color(-i, -i, -i, 1 + i);
                    if (i <= -1)
                    {
                        
                        Blackout.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                        //i = -2;
                        isInited = false;
                        AgainButton.SetActive(false);
                        break;
                    }

                }
                t = Time.time;
            }
        }
    }

    private void OnMouseDown()
    {

        AgainButton.transform.Translate(new Vector2(0.0f, -0.05f));
    }

    private void OnMouseUpAsButton()
    {

        AgainButton.transform.Translate(new Vector2(0.0f, 0.05f));
        swooshing.Play(0);
        GameManager.state = GameManager.State.reReady;
        //让开始屏幕变黑，变黑后遮挡层变透明
        i = 1;




    }
}
