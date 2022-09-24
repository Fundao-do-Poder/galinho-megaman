using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomboAcao : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rdb;

    [SerializeField]
    GameObject dejetoprefab;

    [SerializeField]
    GameObject explosaoprefab;

    GameObject target = LevelManager.playerinstance;
    float tempo;

    public PomboAcao instance;

    int life = 1;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rdb.AddForce(Vector2.left * 1f, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Debug.Log(target.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - 8)
        {
            Destroy(gameObject);
        }

        if (target != null)
        {
            if (transform.position.x < target.transform.position.x + 2 && transform.position.x > target.transform.position.x - 2 && tempo < 60 * 8)
            {
                rdb.velocity = Vector3.zero;
                tempo++;

                //transform.position = Vector3.Lerp(transform.position,
                //new Vector3(target.transform.position.x +
                //rdb.velocity.x * 2
                //, target.transform.position.y + 1.5f + Random.Range(-2f, 2f)
                //, transform.position.z), 0.02f);
                var pos = transform.position;
                pos.x = Mathf.Lerp(transform.position.x, target.transform.position.x, 0.0275f);
                pos.y = Mathf.Lerp(transform.position.y, target.transform.position.y + 1.5f + Random.Range(-2f, 2f), 0.002f);
                transform.position = pos;
                if (pos.x < target.transform.position.x)
                {
                    transform.localScale = new Vector3(-1.5f, 1.5f, 1);
                }
                else if (pos.x > target.transform.position.x)
                {
                    transform.localScale = new Vector3(1.5f, 1.5f, 1);
                }
                if (tempo == 60 * 6)
                {
                    var dejeto = Instantiate(dejetoprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    dejeto.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 0.1f, ForceMode2D.Impulse);
                }

            }
        }
        if (tempo >= 1 && !target)
        {
            tempo++;
        }
        
        if (tempo == 60 * 8)
        {
            rdb.velocity = Vector3.zero;
            rdb.AddForce(Vector2.left * 1f, ForceMode2D.Impulse);
        }
        if (rdb.velocity.x > 0f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        } else if (rdb.velocity.x < 0f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }

        if (life <= 0)
        {
            Instantiate(explosaoprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tiro"))
        {
            life--;
            Destroy(collision.gameObject);
            for (int i = 0; i<3; i++)
            {
                var exp = Instantiate(explosaoprefab, new Vector3(transform.position.x + Random.Range(-0.25f, 0.25f), transform.position.y + Random.Range(-0.25f, 0.25f), transform.position.z), Quaternion.identity);
                exp.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
            }
            
        }
    }
}
