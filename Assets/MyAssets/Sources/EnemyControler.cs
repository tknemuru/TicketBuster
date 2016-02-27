using UnityEngine;
using System.Collections;

public class EnemyControler : MonoBehaviour
{
    /// <summary>
    /// 速度
    /// </summary>
    private float Speed = 0.7f;
    
    /// <summary>
    /// 爆発オブジェクト
    /// </summary>
    public GameObject Explosion;

    /// <summary>
    /// 停止する位置
    /// </summary>
    public int StopPosition { get; set; }

    /// <summary>
    /// マウスオーバ中かどうか
    /// </summary>
    private bool IsOnMouseOver { get; set; }

    // Use this for initialization
    public void Start()
    {
        this.IsOnMouseOver = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (this.transform.position.z > this.StopPosition)
        {
            this.transform.Translate(0, 0, 1 * Speed);
        }
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void OnGUI()
    {
        if (!this.IsOnMouseOver) { return; }

        GUI.Label(new Rect(300, 100, 200, 200), "Label Test");
    }

    public void OnMouseOver()
    {
        this.IsOnMouseOver = true;
    }

    public void OnMouseExit()
    {
        this.IsOnMouseOver = false;
    }
}
