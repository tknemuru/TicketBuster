using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Preview : MonoBehaviour {
    /// <summary>
    /// 戦闘機
    /// </summary>
    public GameObject StarFighter;

    /// <summary>
    /// 敵
    /// </summary>
    public GameObject Enemy;

    private float EnemyIntervalTime { get; set; }

    private List<GameObject> Enemys { get; set; }

    private GameObject TargetEnemy { get; set; }

    private GameObject Fighter { get; set; }

	// Use this for initialization
	public void Start () {
        this.EnemyIntervalTime = 0.0f;
        this.Fighter = (GameObject)Instantiate(StarFighter, new Vector3(0.0f, 2.86f, -6.0f), Quaternion.identity);
        this.Enemys = new List<GameObject>();
        // TODO 敵の読み込み
        Quaternion quat = Quaternion.Euler(0, 180, 0);
        var enemy = (GameObject)Instantiate(Enemy, new Vector3(transform.position.x + 6, transform.position.y + 10, transform.position.z + 200), quat);
        this.Enemys.Add(enemy);
        this.TargetEnemy = enemy;
	}
	
	// Update is called once per frame
	public void Update () {
        //Quaternion quat = Quaternion.Euler(0, 180, 0);
        //EnemyIntervalTime += Time.deltaTime;
        //if (EnemyIntervalTime >= 4.0f)
        //{
        //    EnemyIntervalTime = 0;
        //    var enemy = (GameObject)Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z + 200), quat);
        //}
        this.MoveStarFighter(this.Fighter, this.TargetEnemy);
	}

    private void MoveStarFighter(GameObject fighter, GameObject enemy)
    {
        var subVector = enemy.transform.position - fighter.transform.position;
        var needMoveX = (Math.Abs(subVector.x) > 1);
        var needMoveY = (Math.Abs(subVector.y) > 1);
        var needMoveZ = false;
        var x = needMoveX ? subVector.x.CompareTo(0.0f) : 0.0f;
        var y = needMoveY ? subVector.y.CompareTo(0.0f) : 0.0f;
        var z = needMoveZ ? subVector.z.CompareTo(0.0f) : 0.0f;
        var p = fighter.transform.position;
        fighter.transform.position = new Vector3(p.x + x, p.y + y, p.z + z);
    }
}
