using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroGalinhoAcao : MonoBehaviour
{
    Rigidbody2D rdb;

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
        if (transform.position.x < Camera.main.transform.position.x - 8 ||
            transform.position.x > Camera.main.transform.position.x + 8 ||
            transform.position.y < Camera.main.transform.position.y - 8 ||
            transform.position.y > Camera.main.transform.position.y + 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Chao"))
        {
            var exp = Instantiate(explosaoprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            exp.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
            Destroy(gameObject);
        }
    }

}
