using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    public SpriteRenderer lifeegg;
    public float life = 6;
    public GameObject respawn;
    public GameObject playerprefab;
    public static GameObject playerinstance;
    public MyCamera mycamera;

    // Use this for initialization
    void Start () {
        instance = this;
       
    }
	
	// Update is called once per frame
	void Update () {
        if (!playerinstance)
        {
            CreatePlayer();
        }
    }
    void CreatePlayer()
    {
        playerinstance = Instantiate(playerprefab, respawn.transform.position, Quaternion.identity);
        mycamera.SetPlayer(playerinstance);
        life = 6;
    }
    /// <summary>
    /// Aplica pouco dano
    /// </summary>
    public void LowDamage()
    {
        life -= 1;
        if (life == 0)
        {
            Destroy(playerinstance);
        }
    }
}
