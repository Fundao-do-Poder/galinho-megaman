using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BloqueioMidboss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.unblock_midboss)
        {
            GetComponent<TilemapCollider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}
