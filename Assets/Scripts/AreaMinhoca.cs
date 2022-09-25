using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMinhoca : MonoBehaviour
{
    [SerializeField]
    GameObject minhocaavisoprefab;

    [SerializeField]
    LayerMask layerMask;

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
            Debug.Log("pisada");
            GameObject[] all_enemy = GameObject.FindGameObjectsWithTag("Enemy");
            int enemy_count = all_enemy.Length;
            Debug.Log(enemy_count);
            if (enemy_count == 0)
            {
                if (collision.gameObject.GetComponent<Animator>().GetBool("GROUNDED") && frames % 100 == 0)
                {
                    var player = LevelManager.playerinstance;
                    var position_new = new Vector3(player.transform.position.x + Random.Range(-2f, 2f), player.transform.position.y, 1);
                    Collider2D hit = Physics2D.OverlapCircle(position_new, 0.03f, layerMask);
                    if (hit != null)
                    {
                        if (hit.CompareTag("Chao"))
                        {
                            Instantiate(minhocaavisoprefab, position_new, Quaternion.identity);
                            Debug.Log("minhoca");
                        }
                    }
                }
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
