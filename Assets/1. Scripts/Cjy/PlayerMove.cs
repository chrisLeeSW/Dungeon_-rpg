using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public float speed;
    public Vector3 DesPoint;

    //싱글톤 Awake함수
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        //플레이어 움직이기
        transform.position = Vector3.MoveTowards(transform.position, DesPoint, speed);
    }
}
