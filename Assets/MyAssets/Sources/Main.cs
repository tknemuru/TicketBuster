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
    /// コンストラクタ
    /// </summary>
    public Main()
    {
        this.Fighters = new List<GameObject>();
        this.UserNameButtons = new List<GameObject>();
    }

	// Use this for initialization
	public void Start () {
        // TODO:戦闘機読み込み処理
        this.loadFighters();
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

    /// <summary>
    /// 戦闘機リストを読み込みます。
    /// </summary>
    /// <returns></returns>
    private void loadFighters()
    {
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
}
