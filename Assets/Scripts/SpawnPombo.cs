using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPombo : MonoBehaviour
{
    [SerializeField]
    GameObject pomboprefab;

    [SerializeField]
    GameObject minhocaavisoprefab;

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
            var pombo = Instantiate(pomboprefab, Camera.main.transform.position + new Vector3(7, Random.Range(0.5f, 2f), 1), Quaternion.identity);
            //var mv = Instantiate(minhocaavisoprefab, LevelManager.playerinstance.transform.position + new Vector3(Random.Range(-4, 4), 1, 1), Quaternion.identity);
            var mv = Instantiate(minhocaavisoprefab, new Vector3(LevelManager.playerinstance.transform.position.x + Random.Range(-4, 4), -18.36f, 1), Quaternion.identity);
            //var mvpos = mv.transform.position;
            //mvpos.y = -18.36f;
        }
    }
}
