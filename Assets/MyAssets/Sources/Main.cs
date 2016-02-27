using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {
    /// <summary>
    /// 戦闘機
    /// </summary>
    public GameObject StarFighter;
    
    /// <summary>
    /// キャンバス
    /// </summary>
    public Canvas Canvas;
    
    /// <summary>
    /// ユーザ名ボタン
    /// </summary>
    public GameObject UserNameButton;

    /// <summary>
    /// 敵
    /// </summary>
    public GameObject Enemy;

    /// <summary>
    /// ユーザ名ボタンの位置
    /// </summary>
    private const int UserNameButtonPosition = 146;

    /// <summary>
    /// 戦闘機配置位置の間隔
    /// </summary>
    private const int PositionInterval = 30;

    /// <summary>
    /// 戦闘機リスト
    /// </summary>
    private List<GameObject> Fighters { get; set; }

    /// <summary>
    /// ユーザ名ボタンリスト
    /// </summary>
    private List<GameObject> UserNameButtons { get; set; }

    /// <summary>
    /// 敵リスト
    /// </summary>
    private List<GameObject> Enemys { get; set; }

	// Use this for initialization
	public void Start () {
        // TODO:戦闘機読み込み処理
        this.LoadFighters();

        // TODO:敵読み込み処理
        this.LoadEnemys();
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

    /// <summary>
    /// 戦闘機を読み込みます。
    /// </summary>
    /// <returns></returns>
    private void LoadFighters()
    {
        this.Fighters = new List<GameObject>();
        this.UserNameButtons = new List<GameObject>();

        for (var i = 0; i < 5; i++)
        {
            var fighter = Instantiate(StarFighter);
            fighter.transform.position = new Vector3(fighter.transform.position.x, (fighter.transform.position.y - (PositionInterval * i)), fighter.transform.position.z);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(fighter.transform.position);
            var button = (GameObject)Instantiate(UserNameButton, new Vector3(fighter.transform.position.x + UserNameButtonPosition, screenPos.y, fighter.transform.position.z), Quaternion.identity);
            button.transform.SetParent(Canvas.transform);
            this.Fighters.Add(fighter);
            this.UserNameButtons.Add(button);
        }
    }

    /// <summary>
    /// 敵を読み込みます。
    /// </summary>
    private void LoadEnemys()
    {
        this.Enemys = new List<GameObject>();

        Quaternion quat = Quaternion.Euler(0, 180, 0);
        var i = 0;

        foreach (GameObject fighter in this.Fighters)
        {
            //Vector3 screenPos = Camera.main.WorldToScreenPoint(fighter.transform.position);
            //var enemy = (GameObject)Instantiate(Enemy, new Vector3(fighter.transform.position.x, screenPos.y - (1 * i), fighter.transform.position.z + 200), quat);
            var enemy = Instantiate(Enemy);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            enemy.transform.position = new Vector3(fighter.transform.position.x, fighter.transform.position.y + 3, fighter.transform.position.z + 200);
            var controller = enemy.GetComponent<EnemyControler>();
            controller.StopPosition = 300;
            this.Enemys.Add(enemy);
            i++;
        }
    }
}
