using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAcao : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(LevelManager.playerinstance.transform.position.x
                , transform.position.y
                , transform.position.z), Time.smoothDeltaTime);  
    }

}
