using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroGalinhoAcao : MonoBehaviour
{
    Rigidbody2D rdb;
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

}
