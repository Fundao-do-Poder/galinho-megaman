using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAcao : MonoBehaviour
{
    Color tmp;
    float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);

        if (LevelManager.instance.start_level == true)
        {
            tmp.a = Mathf.Lerp(tmp.a, 0, t);
            GetComponent<SpriteRenderer>().color = tmp;

            t += 0.2f * Time.deltaTime;

            if (tmp.a == 0f)
            {
                t = 0;
                LevelManager.instance.start_level = false;
            }
        }

        if (LevelManager.instance.end_level == true)
        {
            tmp.a = Mathf.Lerp(tmp.a, 1, t);
            GetComponent<SpriteRenderer>().color = tmp;

            t += 0.5f * Time.deltaTime;

            if (tmp.a >= 1.0f)
            {
                if (LevelManager.instance.scene_atual == "Fase_Intro")
                {
                    SceneManager.LoadScene("Fase_0");
                }
                if (LevelManager.instance.scene_atual == "Fase_0")
                {
                    SceneManager.LoadScene("Fase_1");
                }
                if (LevelManager.instance.scene_atual == "Fase_1")
                {
                    SceneManager.LoadScene("Fase_2");
                }
                if (LevelManager.instance.scene_atual == "Fase_2")
                {
                    SceneManager.LoadScene("Fase_2_5");
                }
                if (LevelManager.instance.scene_atual == "Fase_2_5")
                {
                    SceneManager.LoadScene("Fase_3");
                }
                if (LevelManager.instance.scene_atual == "Fase_3")
                {
                    SceneManager.LoadScene("GameCompleted");
                }
            }
        }
    }
}
