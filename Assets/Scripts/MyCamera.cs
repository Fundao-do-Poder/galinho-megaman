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
            if (target.GetComponent<Animator>().GetBool("GROUNDED"))
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(target.transform.position.x +
                    rdb.velocity.x * 2
                    , target.transform.position.y + 1
                    , transform.position.z), Time.smoothDeltaTime);
            } else
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(target.transform.position.x +
                    rdb.velocity.x * 2
                    , target.transform.position.y
                    , transform.position.z), Time.smoothDeltaTime);
            }

            if (LevelManager.instance.scene_atual == "Fase_0")
            {

                if (LevelManager.instance.bossfight == true)
                {
                    transform.position = new Vector3(37.60f, -16.68f, transform.position.z);
                }
                else
                {
                    var pos = transform.position;
                    pos.x = Mathf.Clamp(transform.position.x, -1.25f, 37.75f);
                    transform.position = pos;
                }
            }

            if (LevelManager.instance.scene_atual == "Fase_1")
            {
                var pos = transform.position;
                pos.x = Mathf.Clamp(transform.position.x, -4.5f, 59f);
                transform.position = pos;
            }

            if (LevelManager.instance.scene_atual == "Fase_2")
            {
                var pos = transform.position;
                pos.x = Mathf.Clamp(transform.position.x, -7f, 170f);
                transform.position = pos;
            }

            if (LevelManager.instance.scene_atual == "Fase_2_5")
            {
                if (LevelManager.instance.unblock_midboss == false)
                {
                    transform.position = new Vector3(0f, -16.24f, transform.position.z);
                } else 
                {
                    var pos = transform.position;
                    pos.x = Mathf.Clamp(transform.position.x, -1.5f, 3.15f);
                    transform.position = pos;
                }
                
            }

            if (LevelManager.instance.scene_atual == "Fase_3")
            {
                var pos = transform.position;
                pos.x = Mathf.Clamp(transform.position.x, -6f, 168f);
                transform.position = pos;
            }




            /*
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
            }*/
            /*
            if (transform.position.y < -17f)
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(target.transform.position.x
                    , -17f
                    , transform.position.z), Time.smoothDeltaTime);
            }
            if (target.transform.position.y <= -19f)
            {
                if (LevelManager.instance.life > 0)         ////////////////////////////// mudar para o level manager/tilemap
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
            }*/
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
