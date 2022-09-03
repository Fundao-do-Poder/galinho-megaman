using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPombo : MonoBehaviour
{
    [SerializeField]
    GameObject pomboprefab;

    int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        if (frames % 420 == 0)
        {
            Instantiate(pomboprefab, Camera.main.transform.position + new Vector3(7, Random.Range(0.5f, 2f), 1), Quaternion.identity);
        }
    }
}
