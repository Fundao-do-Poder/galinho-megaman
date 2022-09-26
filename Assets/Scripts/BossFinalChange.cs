using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinalChange : MonoBehaviour
{
    int tempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.bossfight == true)
        {
            tempo++;
            if (tempo >= 330)
            {
                transform.position = new Vector3(147.5009f, -15.755f);
            }
            
        }
    }
}
