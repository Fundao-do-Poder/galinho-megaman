using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraZeroAcao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.bossfight == true)
        {
            GetComponent<Collider2D>().enabled = true;
        } else
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
