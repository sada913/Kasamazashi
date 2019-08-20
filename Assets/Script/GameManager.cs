using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text time,Count;
    [SerializeField]
    public int timer = 30,count =-1;
    IDisposable Timer;
    [SerializeField]
    Button button;

    [Space]
    [SerializeField]
    Transform CreateBallPos;
    [SerializeField]
    GameObject ball;

    Ball ballCol;
    
    // Start is called before the first frame update
    void Start()
    {
        ballCol = ball.GetComponent<Ball>();
        time.text = timer.ToString();
        button.onClick.AsObservable().Subscribe(n =>
        {
            StartGame();
            button.gameObject.SetActive(false);
        });

    }


    public void StartGame()
    {
       CreateBall();
        Count.text = "";
       Timer = Observable.Interval(TimeSpan.FromSeconds(1f)).Subscribe(n =>
        {
            timer--;
            time.text = "残り時間 : " + timer.ToString();
            if(timer == 0)
            {
                time.text = "終了";
                Count.text = "落とした数 :" + count.ToString();
                Timer.Dispose();
                button.gameObject.SetActive(true);
                timer = 30;
                count = 0;
            }
        }).AddTo(gameObject);
    }

    public void CreateBall()
    {
        Instantiate(ball, CreateBallPos.position,CreateBallPos.rotation);
        count++;
    }


}
