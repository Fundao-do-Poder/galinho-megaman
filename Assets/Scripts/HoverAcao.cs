using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class HoverAcao : EventTrigger, IPointerClickHandler
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetarYes(BaseEventData data)
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (GOAcao.instance.ovo_timer == 0)
            {
                if (GOAcao.instance.GO_sel_final == 0)
                {
                    GOAcao.instance.GO_sel = 1;
                }
            }
        } else
        {
            if (MTAcao.instance.mt_timer == 0)
            {
                if (MTAcao.instance.MT_sel_final == 0)
                {
                    MTAcao.instance.MT_sel = 1;
                }
            }
        }
        
        
    }
    public static void SetarNo(BaseEventData data)
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (GOAcao.instance.ovo_timer == 0)
            {
                if (GOAcao.instance.GO_sel_final == 0)
                {
                    GOAcao.instance.GO_sel = 2;
                }
            }
        } else
        {
            if (MTAcao.instance.mt_timer == 0)
            {
                if (MTAcao.instance.MT_sel_final == 0)
                {
                    MTAcao.instance.MT_sel = 2;
                }
            }
        }
        
    }

    public static void SetarVai()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (GOAcao.instance.ovo_timer == 0)
            {
                GOAcao.instance.ovo_timer = 1;
                GOAcao.instance.GO_sel_final = GOAcao.instance.GO_sel;
            }
        } else
        {
            if (MTAcao.instance.mt_timer == 0)
            {
                MTAcao.instance.mt_timer = 1;
                MTAcao.instance.MT_sel_final = MTAcao.instance.MT_sel;
            }
        }
        
    }
}
