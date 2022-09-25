using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinhocaAcao : MonoBehaviour
{
    [SerializeField]
    GameObject dejetoprefab;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    GameObject explosaoprefab;

    float tempo = 0;
    int life = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (LevelManager.playerinstance.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else if (LevelManager.playerinstance.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        tempo++;
        if (tempo == 60 * 4)
        {
            var dejeto = Instantiate(dejetoprefab, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z), Quaternion.identity);
            dejeto.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            if (transform.localScale.x > 0)
            {
                dejeto.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 2, ForceMode2D.Impulse);
                //dejeto.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            }
            else if (transform.localScale.x < 0)
            {
                dejeto.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 2, ForceMode2D.Impulse);
                //dejeto.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
            }

            //dejeto.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        }
        if (tempo > 60 * 6)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.03f, layerMask);
        // Debug.Log(rigidbody.velocity.y);
        if (hit == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tiro"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            for (int i = 0; i < 3; i++)
            {
                var exp = Instantiate(explosaoprefab, new Vector3(transform.position.x + Random.Range(-0.25f, 0.25f), transform.position.y + Random.Range(-0.25f, 0.25f), transform.position.z), Quaternion.identity);
                exp.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
            }

        }
    }
}
