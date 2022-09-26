using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalinhaLoucaAcao : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rdb;

    GameObject target = LevelManager.playerinstance;
    float tempo;
    int run = 0;
    int run_dir = 0;

    [SerializeField]
    int life = 40;

    [SerializeField]
    public ParticleSystem dmg;

    [SerializeField]
    GameObject explosaoprefab;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo % 120 == 0)
        {
            if (transform.position.x < target.transform.position.x)
            {
                run_dir = 1;
            }
            if (transform.position.x > target.transform.position.x)
            {
                run_dir = 2;
            }
        }

        if (run_dir == 1)
        {
            rdb.AddForce(Vector3.right * 2f, ForceMode2D.Impulse);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (run_dir == 2)
        {
            rdb.AddForce(Vector3.left * 2f, ForceMode2D.Impulse);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tiro"))
        {
            rdb.velocity = Vector3.zero;
            life--;
            Destroy(collision.gameObject);
            dmg.Emit(15);
            if (life <= 0)
            {
                //                        LevelManager.instance.unblock_midboss = true;
                dmg.Emit(60);
                for (int i = 0; i < 14; i++)
                {
                    var exp = Instantiate(explosaoprefab, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z), Quaternion.identity);
                    exp.gameObject.transform.localScale = new Vector3(4f, 4f, 1);
                }
                Destroy(gameObject);
            }
        }
    }
}
