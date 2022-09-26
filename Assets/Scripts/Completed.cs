using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Completed : MonoBehaviour
   
{
    [SerializeField]
    float tempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo++;
        Debug.Log("tempo");
        if (tempo >= 1000)
        {
            SceneManager.LoadScene("Titulo");
        }
    }
}
