using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
    /// 選択中のユーザID
    /// </summary>
    public static string SelectedUserId;

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
    private Dictionary<string, GameObject> Fighters { get; set; }

    /// <summary>
    /// ユーザ名ボタンリスト
    /// </summary>
    private Dictionary<string, GameObject> UserNameButtons { get; set; }

    /// <summary>
    /// 敵リスト
    /// </summary>
    private Dictionary<string, List<GameObject>> Enemys { get; set; }

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
        this.Fighters = new Dictionary<string, GameObject>();
        this.UserNameButtons = new Dictionary<string, GameObject>();

        // TODO:データ取得
        var userIds = new List<string> {"101", "102", "103", "104", "105"};
        var i = 0;

        foreach (var id in userIds)
        {
            var fighter = Instantiate(StarFighter);
            fighter.transform.position = new Vector3(fighter.transform.position.x, (fighter.transform.position.y - (PositionInterval * i)), fighter.transform.position.z);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(fighter.transform.position);
            var button = (GameObject)Instantiate(UserNameButton, new Vector3(fighter.transform.position.x + UserNameButtonPosition, screenPos.y, fighter.transform.position.z), Quaternion.identity);
            button.transform.SetParent(Canvas.transform);
            var controller = button.GetComponent<UserNameButtonController>();
            controller.UserId = id;
            this.Fighters.Add(id, fighter);
            this.UserNameButtons.Add(id, button);
            i++;
        }
    }

    /// <summary>
    /// 敵を読み込みます。
    /// </summary>
    private void LoadEnemys()
    {
        this.Enemys = new Dictionary<string, List<GameObject>>();
        Quaternion quat = Quaternion.Euler(0, 180, 0);

        // TODO:データ取得
        var tickets = new List<string> { "101", "102", "103", "104", "105", "101", "101", "101", "102" };

        foreach (var fighterKeyValue in this.Fighters)
        {
            var myTickets = tickets.Where(t => t == fighterKeyValue.Key);
            var stopPosition = 100;
            foreach (var ticket in myTickets)
            {
                var enemy = Instantiate(Enemy);
                Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
                enemy.transform.position = new Vector3(fighterKeyValue.Value.transform.position.x
                    , fighterKeyValue.Value.transform.position.y + 3
                    , fighterKeyValue.Value.transform.position.z + 360 + stopPosition);
                var controller = enemy.GetComponent<EnemyControler>();
                controller.StopPosition = stopPosition;

                if (!this.Enemys.ContainsKey(ticket))
                {
                    this.Enemys.Add(ticket, new List<GameObject>());
                }
                this.Enemys[ticket].Add(enemy);
                stopPosition += 20;
            }
        }
    }
}
