using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;


public class Ball : MonoBehaviour
{
    GameManager gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ("G" == collision.gameObject.tag)
        {
            if(gm.timer < 30)
                gm.CreateBall();
            Destroy(gameObject);
        }
    }


}
