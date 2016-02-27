using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	public void Start () {
        this.EnemyIntervalTime = 0.0f;
        var fighter = (GameObject)Instantiate(StarFighter, new Vector3(0.0f, 2.86f, -6.0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	public void Update () {
        Quaternion quat = Quaternion.Euler(0, 180, 0);
        EnemyIntervalTime += Time.deltaTime;
        if (EnemyIntervalTime >= 4.0f)
        {
            EnemyIntervalTime = 0;
            var enemy = (GameObject)Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z + 200), quat);
        }
	}
}
