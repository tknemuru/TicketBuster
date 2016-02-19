using UnityEngine;
using System.Collections;

public class EnemyControler : MonoBehaviour
{
    private float SpeedZ = 0.7f;
    public GameObject Explosion;

    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        transform.Translate(0, 0, 1 * SpeedZ);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
