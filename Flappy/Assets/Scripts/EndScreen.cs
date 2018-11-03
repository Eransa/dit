using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour {
    public GameObject AgainButton;
    public GameObject GameOver;
    public GameObject Scoreboard;
    public GameObject Score;
    public AudioSource die;
    //public GameObject Medal;
    private float t, i;
    private bool hasInited;
    
    //结束画面显示次序：GameOver由透明出现的同时跳一下，计分板从下方飞入，(在ScoreBoard脚本中）本次分数跳动显示，计分完成后后显示奖牌，奖牌显示后出现按钮

    private float GameOverJump(GameObject gameover,float i)
    {
        if (i <= 1 && i >= 0)
        {
            if (i > 0)//屏幕变白阶段
            {
                i -= 0.1f;
                gameover.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1-i);//透明度逐渐变低
                if (i >= 0.5f)
                    gameover.transform.Translate(new Vector2(0, 0.5f*i));
                else
                    gameover.transform.Translate(new Vector2(0, 0.5f*-i));
            }
        }
        return i;
    }

    // Use this for initialization
    void Start () {
        t = Time.time;
        i = 1;
        hasInited = true;
        die.Play(0);

	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.state == GameManager.State.End && hasInited == false)
        {
            t = Time.time;
            i = 1;
            hasInited = true;
            die.Play(0);
        }

        if( Time.time - t > 0.5f && Time.time - t <= 1)
            Score.SetActive(false);
        if (Time.time - t > 1 && Time.time-t<=2)
        {
            GameOver.SetActive(true);
            i = GameOverJump(GameOver, i);
        }
        if (Time.time - t > 2 && Time.time-t <3)
        {
            Scoreboard.SetActive(true);
            Scoreboard.transform.Translate(new Vector2(0, 8.0f * Time.deltaTime));
        }
        if (Time.time-t > 3)
            
            AgainButton.SetActive(true);

        if (GameManager.state == GameManager.State.reReady)
        {
            hasInited = false;
            GameOver.SetActive(false);

            GameOver.transform.localPosition = new Vector2(0, 3);
            Scoreboard.transform.localPosition = new Vector2(0, -7.86f);
        }
            

	}
}
