using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CreatePlayer(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (life == 0)
        {
            //GOAcao.instance.last_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("GameOver");
        }
        if (!playerinstance && life > 0)
        {
            CreatePlayer(false);
        }
        
    }
    void CreatePlayer(bool start)
    {
        playerinstance = Instantiate(playerprefab, respawn.transform.position, Quaternion.identity);
        mycamera.SetPlayer(playerinstance);
        if (start)
        {
            life = 6;
        }
    }
    /// <summary>
    /// Aplica pouco dano
    /// </summary>
    public void LowDamage()
    {
        life -= 1;
        if (life == 0)
        {
            //Destroy(playerinstance);
            SceneManager.LoadScene("GameOver");
        }
    }
}
