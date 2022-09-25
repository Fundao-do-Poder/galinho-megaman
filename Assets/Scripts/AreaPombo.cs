using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPombo : MonoBehaviour
{

    [SerializeField]
    GameObject pomboprefab;

    int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("pisadapombo");
            if (frames % 240 == 0)
            {
                var pombo = Instantiate(pomboprefab, Camera.main.transform.position + new Vector3(7, Random.Range(0.5f, 2f), 1), Quaternion.identity);
                frames = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (frames < 50)
            {
                frames = 0;
            }
        }
    }
}
