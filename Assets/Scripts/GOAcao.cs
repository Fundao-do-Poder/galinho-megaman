using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

public class GOAcao : MonoBehaviour
{
    public static GOAcao instance;
    public int GO_sel = 1;
    public float mudar;
    float tempo = 15;
    public float ovo_timer = 0;
    public static Scene last_scene;
    public int GO_sel_final = 0;

    public Sprite yes_1;
    public Sprite yes_2;
    public Sprite yes_3;
    public Sprite yes_4;
    public Sprite yes_5;
    public Sprite yes_6;
    public Sprite yes_7;
    public Sprite yes_8;
    public Sprite yes_9;
    public Sprite yes_10;
    public Sprite yes_11;
    public Sprite yes_12;
    public Sprite yes_13;

    public Sprite no_1;
    public Sprite no_2;
    public Sprite no_3;
    public Sprite no_4;
    public Sprite no_5;
    public Sprite no_6;
    public Sprite no_7;
    public Sprite no_8;
    public Sprite no_9;
    public Sprite no_10;
    public Sprite no_11;
    public Sprite no_12;
    public Sprite no_13;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GO_sel > 2) { GO_sel = 1; }
        //if (GO_sel < 1) { GO_sel = 2; }
        //Mathf.Clamp(GO_sel, 1, 2);
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    if (ovo_timer == 0)
        //    {
        //        ovo_timer = 1;
        //        GO_sel_final = GO_sel;
        //    }
        //}
        if (ovo_timer == 0)
        {
            if (GO_sel == 1)
            {
                var selec = getChildGameObject(gameObject, "Selections");
                selec.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -134.6f, 1);

                var yes = getChildGameObject(gameObject, "Yes");
                yes.GetComponent<Text>().color = Color.yellow;

                var no = getChildGameObject(gameObject, "No");
                no.GetComponent<Text>().color = Color.gray;
            }
            else if (GO_sel == 2)
            {
                var selec = getChildGameObject(gameObject, "Selections");
                selec.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -176.13f, 1);

                var no = getChildGameObject(gameObject, "No");
                no.GetComponent<Text>().color = Color.yellow;

                var yes = getChildGameObject(gameObject, "Yes");
                yes.GetComponent<Text>().color = Color.gray;
            }
        } 
        else if (ovo_timer > 0)
        {
            if (GO_sel_final == 1)
            {
                var ovo = getChildGameObject(gameObject, "Ovo");
                const int ADD = 5;
                switch (ovo_timer)
                {
                    case 4 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_1;
                        break;
                    case 8 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_2;
                        break;

                    case 12 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_3;
                        break;

                    case 16 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_4;
                        break;

                    case 20 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_5;
                        break;

                    case 24 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_6;
                        break;

                    case 28 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_7;
                        break;

                    case 32 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_8;
                        break;

                    case 36 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_9;
                        break;

                    case 40 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_10;
                        break;

                    case 44 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_11;
                        break;

                    case 48 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_12;
                        break;

                    case 52 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_13;
                        break;

                    /// REPETE ULTIMO

                    case 56 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_12;
                        break;

                    case 60 * ADD:

                        ovo.GetComponent<Image>().sprite = yes_13;
                        break;

                    ///

                    case 64 * ADD:

                        SceneManager.LoadScene(LevelManager.instance.scene_atual);
                        break;
                }
            }

            if (GO_sel_final == 2)
            {
                var ovo = getChildGameObject(gameObject, "Ovo");
                const int ADD = 6;
                switch (ovo_timer)
                {
                    case 4 * ADD:

                        ovo.GetComponent<Image>().sprite = no_1;
                        break;
                    case 8 * ADD:

                        ovo.GetComponent<Image>().sprite = no_2;
                        break;

                    case 12 * ADD:

                        ovo.GetComponent<Image>().sprite = no_3;
                        break;

                    case 16 * ADD:

                        ovo.GetComponent<Image>().sprite = no_4;
                        break;

                    case 20 * ADD:

                        ovo.GetComponent<Image>().sprite = no_5;
                        break;

                    case 24 * ADD:

                        ovo.GetComponent<Image>().sprite = no_6;
                        break;

                    case 28 * ADD:

                        ovo.GetComponent<Image>().sprite = no_7;
                        break;

                    case 32 * ADD:

                        ovo.GetComponent<Image>().sprite = no_8;
                        break;

                    case 36 * ADD:

                        ovo.GetComponent<Image>().sprite = no_9;
                        break;

                    case 40 * ADD:

                        ovo.GetComponent<Image>().sprite = no_10;
                        break;

                    case 44 * ADD:

                        ovo.GetComponent<Image>().sprite = no_11;
                        break;

                    case 48 * ADD:

                        ovo.GetComponent<Image>().sprite = no_12;
                        break;

                    case 52 * ADD:

                        ovo.GetComponent<Image>().sprite = no_13;
                        break;

                    /// REPETE ULTIMO

                    case 56 * ADD:

                        ovo.GetComponent<Image>().sprite = no_12;
                        break;

                    case 60 * ADD:

                        ovo.GetComponent<Image>().sprite = no_13;
                        break;

                    ///

                    case 64 * ADD:

                        SceneManager.LoadScene("Menu");
                        break;
                }
            }
            ovo_timer = ovo_timer + 0.25f;
            
        }
        

        tempo--;

        
    }

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    public void Mudar(CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && tempo <= 0)
        {
            if (GO_sel == 1)
            {
                GO_sel = 2;
            }
            else if (GO_sel == 2)
            {
                GO_sel = 1;
            }
            tempo = 30;
            Debug.Log(GO_sel);
        } 
        else if (context.ReadValue<float>() == -1 && tempo <= 0)
        {
            if (GO_sel == 1)
            {
                GO_sel = 2;
            }
            else if (GO_sel == 2)
            {
                GO_sel = 1;
            }
            tempo = 30;
            Debug.Log(GO_sel);
        }
    }

    public void Entrar(CallbackContext context)
    {
        if (ovo_timer == 0)
        {
            ovo_timer = 1;
            GO_sel_final = GO_sel;
        }
    }
 }
