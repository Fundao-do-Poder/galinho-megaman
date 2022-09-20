using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEggAcao : MonoBehaviour
{
    SpriteRenderer sr;

    public Sprite egg_1;
    public Sprite egg_2;
    public Sprite egg_3;
    public Sprite egg_4;
    public Sprite egg_5;
    public Sprite egg_6;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (LevelManager.instance.life)
        {
            case 1:
                sr.sprite = egg_6;
                break;
            case 2:
                sr.sprite = egg_5;
                break;
            case 3:
                sr.sprite = egg_4;
                break;
            case 4:
                sr.sprite = egg_3;
                break;
            case 5:
                sr.sprite = egg_2;
                break;
            case 6:
                sr.sprite = egg_1;
                break;
            default:
                sr.sprite = egg_6;
                break;
        }
    }
}
