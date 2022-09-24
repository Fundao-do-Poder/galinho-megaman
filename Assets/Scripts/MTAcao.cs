using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

public class MTAcao : MonoBehaviour
{

    public static MTAcao instance;
    public int MT_sel = 1;
    public float mudarMT;
    float tempo = 15;
    public float mt_timer = 0;
    public int MT_sel_final = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (MT_sel == 1)
        {
            var selec = getChildGameObject(gameObject, "Selections");
            selec.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -134.6f, 1);

            var yes = getChildGameObject(gameObject, "Yes");
            yes.GetComponent<Text>().color = Color.yellow;

            var no = getChildGameObject(gameObject, "No");
            no.GetComponent<Text>().color = Color.gray;
        }
        else if (MT_sel == 2)
        {
            var selec = getChildGameObject(gameObject, "Selections");
            selec.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -176.13f, 1);

            var no = getChildGameObject(gameObject, "No");
            no.GetComponent<Text>().color = Color.yellow;

            var yes = getChildGameObject(gameObject, "Yes");
            yes.GetComponent<Text>().color = Color.gray;
        }

        if (MT_sel_final == 1)
        {
            SceneManager.LoadScene("Fase_1");
        }
        if (MT_sel_final == 2)
        {
            Application.Quit();
        }
        //mt_timer = mt_timer + 0.25f;
        tempo--;
    }

    public void MT_Mudar(CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && tempo <= 0)
        {
            if (MT_sel == 1)
            {
                MT_sel = 2;
            }
            else if (MT_sel == 2)
            {
                MT_sel = 1;
            }
            tempo = 30;
            Debug.Log(MT_sel);
        }
        else if (context.ReadValue<float>() == -1 && tempo <= 0)
        {
            if (MT_sel == 1)
            {
                MT_sel = 2;
            }
            else if (MT_sel == 2)
            {
                MT_sel = 1;
            }
            tempo = 30;
            Debug.Log(MT_sel);
        }
    }

    public void MT_Entrar(CallbackContext context)
    {
        if (mt_timer == 0)
        {
            mt_timer = 1;
            MT_sel_final = MT_sel;
        }
    }

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
}
