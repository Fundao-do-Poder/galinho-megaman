using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinalScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rdb;

    float tempo;
    float tempo_stun;

    int run = 0;
    int run_dir = 0;

    [SerializeField]
    int life = 175;

    [SerializeField]
    public ParticleSystem dmg;

    [SerializeField]
    GameObject explosaoprefab;

    Animator animator;

    [SerializeField]
    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tempo++;
        if (tempo % 120 == 0)
        {
            if (transform.position.x < LevelManager.playerinstance.transform.position.x)
            {
                run_dir = 1;
            }
            if (transform.position.x > LevelManager.playerinstance.transform.position.x)
            {
                run_dir = 2;
            }
        }

        if (LevelManager.playerinstance != null && animator.GetBool("STUN") == false)
        {
            if (LevelManager.playerinstance.transform.position.y > transform.position.y &&
            LevelManager.playerinstance.transform.position.x > transform.position.x - 1 &&
            LevelManager.playerinstance.transform.position.x < transform.position.x + 1 &&
            transform.position.y <= -17)
            {
                Debug.Log("juliana meus oculso");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 12), ForceMode2D.Force);
            }
        }
        
        if (animator.GetBool("STUN") == false)
        {
            if (LevelManager.playerinstance != null)
            {
                if (LevelManager.playerinstance.transform.position.x < transform.position.x + 26 &&
                LevelManager.playerinstance.transform.position.x > transform.position.x - 26)
                {
                    if (run_dir == 1)
                    {
                        var vel = rdb.velocity;
                        vel.x = 1.75f;
                        rdb.velocity = vel;
                        transform.localScale = new Vector3(-1, 1, 1);
                    }

                    if (run_dir == 2)
                    {
                        var vel = rdb.velocity;
                        vel.x = -1.75f;
                        rdb.velocity = vel;
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            
            
        }

        if (tempo_stun >= 1)
        {
            tempo_stun++;
        }
        if (tempo_stun >= 60*11)
        {
            animator.SetBool("STUN", false);
            tempo_stun = 0;
        }
    }

    private void FixedUpdate()
    {
        //Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, layerMask);
        if (rdb.velocity.y <= 0.1f)
        {
            animator.SetBool("GROUNDED", true);
        } else
        {
            animator.SetBool("GROUNDED", false);
        }
        /*
        if (hit != null && (rdb.velocity.y <= 0.5f))
        {
            if (hit.CompareTag("Chao"))
            {
                animator.SetBool("GROUNDED", true);
            }
        }
        else
        {
            animator.SetBool("GROUNDED", false);
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tiro"))
        {
            rdb.velocity = Vector3.zero;
            if (collision.transform.localScale.x == 2)
            {
                if (animator.GetBool("STUN") == false)
                {
                    dmg.Emit(40);
                    life -= 4;
                    animator.SetBool("STUN", true);
                    tempo_stun++;
                } 
            }
            else
            {
                dmg.Emit(10);
                life -= 1;
            }

            Destroy(collision.gameObject);
            if (life <= 0)
            {
                dmg.Emit(90);
                for (int i = 0; i < 14; i++)
                {
                    var exp = Instantiate(explosaoprefab, new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f), transform.position.z), Quaternion.identity);
                    exp.gameObject.transform.localScale = new Vector3(6f, 6f, 1);
                }
                LevelManager.instance.bossfight = true;
                Destroy(gameObject);
            }
        }
    }
}
