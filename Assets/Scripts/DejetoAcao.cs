using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DejetoAcao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - 8 || 
            transform.position.x > Camera.main.transform.position.x + 8 ||
            transform.position.y < Camera.main.transform.position.y - 8 ||
            transform.position.y > Camera.main.transform.position.y + 8)
        {
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Chao"))
        {
            Destroy(gameObject);
        }
    }
}
