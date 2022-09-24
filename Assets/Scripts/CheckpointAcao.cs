using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAcao : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelManager.instance.respawn.transform.position = transform.position;
            if (animator.GetBool("Passou") == false)
            {
                animator.SetBool("Passou", true);
            }
        }
    }
}
