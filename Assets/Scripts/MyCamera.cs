using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    [SerializeField]
    GameObject target;
    Rigidbody2D rdb;
	
	
	void LateUpdate () {
        if (target)
        {
            //if (target.transform.position.y > -19f && target.transform.position.y < transform.position.y)
            //{
            //    transform.position = Vector3.Lerp(transform.position,
            //    new Vector3(target.transform.position.x +
            //    rdb.velocity.x * 2
            //    , target.transform.position.y - 1.5f
            //    , transform.position.z), Time.smoothDeltaTime);
            //
            //    //transform.position = Vector3.Lerp(transform.position,
            //    //new Vector3(target.transform.position.x
            //    //, transform.position.y - 1.5f
            //    //, transform.position.z), 1);
            //}
            if (target.transform.position.y > -19f)
            {
                
                if (transform.position.y >= -17f || target.transform.position.y >= -16)
                {
                    transform.position = Vector3.Lerp(transform.position,
                    new Vector3(target.transform.position.x +
                    rdb.velocity.x * 2
                    , target.transform.position.y
                    , transform.position.z), Time.smoothDeltaTime);
                } else
                {
                    transform.position = Vector3.Lerp(transform.position,
                    new Vector3(target.transform.position.x +
                    rdb.velocity.x * 2
                    , transform.position.y
                    , transform.position.z), Time.smoothDeltaTime);
                }
            }
            if (transform.position.y < -17f)
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(target.transform.position.x
                    , -17f
                    , transform.position.z), Time.smoothDeltaTime);
            }
            if (target.transform.position.y <= -19f)
            {
                if (LevelManager.instance.life > 0)
                {
                    LevelManager.instance.life = LevelManager.instance.life - 2;
                    Destroy(LevelManager.playerinstance);
                } 
                else
                {
                    LevelManager.instance.life = LevelManager.instance.life - 2;
                }
                
                transform.position = Vector3.Lerp(transform.position,
                new Vector3(target.transform.position.x +
                rdb.velocity.x * 2
                , -16.81205f
                , transform.position.z), Time.smoothDeltaTime);
            }
        }
	}
    /// <summary>
    /// Seta o jogador na camera
    /// </summary>
    /// <param name="tgt">jogador</param>
    public void SetPlayer(GameObject tgt)
    {
        target = tgt;
        rdb = target.GetComponent<Rigidbody2D>();
    }
}
