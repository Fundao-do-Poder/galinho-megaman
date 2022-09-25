using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteAcao : MonoBehaviour
{
    float tempo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && tempo > 30)
        {
            if (LevelManager.instance.life > 0)
            {
                LevelManager.instance.life = LevelManager.instance.life - 2;
                Destroy(LevelManager.playerinstance);
                tempo = 0;
            }
            else
            {
                LevelManager.instance.life = LevelManager.instance.life - 2;
                tempo = 0;
            }
        }
    }
}
