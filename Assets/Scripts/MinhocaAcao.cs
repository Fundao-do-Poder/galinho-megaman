using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinhocaAcao : MonoBehaviour
{
    [SerializeField]
    GameObject dejetoprefab;

    float tempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo++;
        if (tempo == 60 * 4)
        {
            var dejeto = Instantiate(dejetoprefab, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z), Quaternion.identity);
            dejeto.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            if (LevelManager.playerinstance.transform.position.x < transform.position.x)
            {
                dejeto.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 2, ForceMode2D.Impulse);
                //dejeto.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            }
            else if (LevelManager.playerinstance.transform.position.x > transform.position.x)
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

        if (LevelManager.playerinstance.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else if (LevelManager.playerinstance.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }
}
