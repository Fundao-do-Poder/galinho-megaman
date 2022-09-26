using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidbossAcao : MonoBehaviour
{
    [SerializeField]
    GameObject dejetoprefab;

    int life = 50;
    Vector3 position_1 = new Vector3(3, -16.98417f, 1);
    Vector3 position_2 = new Vector3(-3, -16.98417f, 1);
    float tempo = 0;
    int shot_count = 0;

    [SerializeField]
    public ParticleSystem dmg;

    [SerializeField]
    GameObject explosaoprefab;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, position_1, 1 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        tempo++;
        if (tempo <= 500*2)
        {
            transform.position = Vector3.MoveTowards(transform.position, position_1, 1 * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
            if (transform.position == position_1)
            {
                GetComponent<Animator>().SetBool("WALKING", false);
                transform.localScale = new Vector3(-1, 1, 1);
            } else
            {
                GetComponent<Animator>().SetBool("WALKING", true);
            }
        }
        if (tempo >= 500*2)
        {
            transform.position = Vector3.MoveTowards(transform.position, position_2, 1 * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
            if (transform.position == position_2)
            {
                GetComponent<Animator>().SetBool("WALKING", false);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                GetComponent<Animator>().SetBool("WALKING", true);
            }
        }
        if (tempo >= 1000*2)
        {
            tempo = 0;
        }
        if (shot_count <= 6 && tempo % 30 == 0)
        {
            if (transform.localScale.x == 1)
            {
                var dejeto = Instantiate(dejetoprefab, new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z), Quaternion.identity);
                dejeto.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 2f, ForceMode2D.Impulse);
                dejeto.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            } 
            else
            {
                var dejeto = Instantiate(dejetoprefab, new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z), Quaternion.identity);
                dejeto.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 2f, ForceMode2D.Impulse);
                dejeto.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            }
            shot_count++;
        }
        if (tempo % 400 == 0)
        {
            shot_count = 0;
        }

        //if (GetComponent<Rigidbody2D>().velocity.x > 1)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //if (GetComponent<Rigidbody2D>().velocity.x < 1)
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}

        //if (GetComponent<Rigidbody2D>().velocity.x >= 0.1f || GetComponent<Rigidbody2D>().velocity.x <= -0.1f)
        //{
        //    GetComponent<Animator>().SetBool("WALKING", true);
        //} else
        //{
        //    GetComponent<Animator>().SetBool("WALKING", false);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tiro"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            life--;
            Destroy(collision.gameObject);
            dmg.Emit(15);
            if (life <= 0)
            {
                LevelManager.instance.unblock_midboss = true;
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
