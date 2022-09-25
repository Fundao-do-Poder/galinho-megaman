using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaAcao : MonoBehaviour
{
    [SerializeField]
    public GameObject explosaoprefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
