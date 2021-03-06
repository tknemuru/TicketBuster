﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarfighterControler : MonoBehaviour {
    private const float SpeedX = 1;
    private const float SpeedZ = 1;

    public GameObject Bullet;

    private float IntervalTime { get; set; }
    private float EnemyIntervalTime { get; set; }

	// Use this for initialization
	public void Start () {
        this.IntervalTime = 0.0f;
        this.EnemyIntervalTime = 0.0f;
	}
	
	// Update is called once per frame
	public void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey("up"))
        {
            transform.Translate(0, 0, vertical * SpeedZ);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0, 0, vertical * SpeedZ);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(horizontal * SpeedX, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(horizontal * SpeedX, 0, 0);
        }

        this.IntervalTime += Time.deltaTime;
        if (Input.GetKey("space"))
        {
            if (this.IntervalTime >= 0.1f)
            {
                this.IntervalTime = 0.0f;
                Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }

        //Quaternion quat = Quaternion.Euler(0, 180, 0);
        //EnemyIntervalTime += Time.deltaTime;
        //if (EnemyIntervalTime >= 4.0f)
        //{
        //    EnemyIntervalTime = 0;
        //    var enemy = ()Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z + 200), quat);
        //    enemy.
        //    this.Enemys.Add();
        //}
	}
}
