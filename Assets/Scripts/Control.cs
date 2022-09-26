using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Control : MonoBehaviour
{
    float sentido = 0; // o nome desse sujeito eh campo, que eh uma variavel declarada no escopo da classe
    const float RAIO_JUMPABLE = 0.05f;
    int puloVezes = 1;
    int puloMax = 2; // somar
    bool noChao = false;
    float tempo_shot = 0;
    float atirante;
    float charge_load;
    float tempo_vivo = 0;
    float tempo_vivo_t = 120;
    public Control instance;
    float tempo_dano = 0;

    double atirarStart;
    double atirarNow;
    bool atirarFinish;
    bool atirarPhase;

    [SerializeField]
    ParticleSystem fire;

    [SerializeField]
    ParticleSystem charge;

    [SerializeField]
    ParticleSystem dano;

    [SerializeField]
    float forcaPulo = 8f;

    Animator animator;
    Rigidbody2D rigidbody;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    GameObject tiroprefab;

    [SerializeField]
    GameObject explosaoprefab;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        instance = this;
    }
    private void Awake()
    {
        GameObject[] gObjetos = GameObject.FindGameObjectsWithTag("Player");
        if (gObjetos.Length > 1)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gObjetos[0].transform.GetChild(1).transform.position = gameObject.transform.position;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    void Update()
    {
        tempo_dano--;
        tempo_vivo++;
        //Debug.Log(tempo_vivo);
        Vector2 velAtual = rigidbody.velocity;
        velAtual.x = 2f * sentido;
        rigidbody.velocity = velAtual;
        animator.SetBool("GROUNDED", noChao);
        if (sentido != 0)
        {
            gameObject.transform.localScale = new Vector3(1f * sentido, 1f, 1f);
            animator.SetBool("WALKING", true);
        }
        else
        {
            animator.SetBool("WALKING", false);
        }
        tempo_shot++;

        // Verificação de tiro
        //TiroAction();
        
        if (LevelManager.instance.unblock_midboss || LevelManager.instance.scene_atual == "Fase_3")
        {
            if (atirante == 1)
            {
                if (atirarFinish)
                {
                    charge.Emit(1);
                    //fire.Emit(1);
                    //var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    //tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
                    //tiro.transform.localScale = new Vector3(1, 1, 1);
                    //atirarFinish = false;
                    //atirarFinish = false;
                }

            }
            if (atirarPhase)
            {
                if (atirarNow >= atirarStart + 0.5f)
                {
                    fire.Emit(1);


                    animator.SetTrigger("FIRE");
                    if (transform.localScale.x == 1)
                    {
                        //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
                        tiro.transform.localScale = new Vector3(2, 2, 1);
                    }
                    else if (transform.localScale.x == -1)
                    {
                        //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4f, ForceMode2D.Impulse);
                        tiro.transform.localScale = new Vector3(2, 2, 1);
                    }

                    atirarFinish = false;
                }
                else
                {
                    fire.Emit(1);


                    animator.SetTrigger("FIRE");
                    if (transform.localScale.x == 1)
                    {
                        //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
                    }
                    else if (transform.localScale.x == -1)
                    {
                        //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                        tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4f, ForceMode2D.Impulse);
                    }

                    atirarFinish = false;
                }
                atirarPhase = false;
            }
        } else
        {
            if (atirarPhase)
            {
                
                fire.Emit(1);

                animator.SetTrigger("FIRE");
                if (transform.localScale.x == 1)
                {
                    //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
                }
                else if (transform.localScale.x == -1)
                {
                    //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4f, ForceMode2D.Impulse);
                }

                atirarFinish = false;
                atirarPhase = false;
            }
        }
        
    }
   
    void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, RAIO_JUMPABLE, layerMask);
        // Debug.Log(rigidbody.velocity.y);
        if (hit != null && (rigidbody.velocity.y <= 0.5f || puloVezes == 0))
        {
            if (hit.CompareTag("Chao"))
            {
                noChao = true;
                animator.SetBool("JUMP", false);
                puloVezes = 0;
            }
            //else if (hit.CompareTag("ADVERSARIO"))
            //{
            //    Destroy(hit.gameObject);
            //    //hpbar.fillAmount += 0.2f;
            //}

        }
        else
        {
            noChao = false;
        }


    }

    public void Atirar(CallbackContext context)
    {
        if (tempo_vivo >= tempo_vivo_t)
        {
            atirarStart = context.startTime;
            atirarNow = context.time;
            atirarFinish = context.performed;
            atirarPhase = context.canceled;

            atirante = context.ReadValue<float>();
        }

        //Debug.Log(context.phase);

        //Debug.Log("startTime: " + context.startTime);
        //Debug.Log("time: " + context.time);
        /*
        if (context.ReadValue<float>() == 1 && tempo_shot >= 10)
        {
            
            animator.SetTrigger("FIRE");
            if (transform.localScale.x == 1)
            {
                //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
            }
            else if (transform.localScale.x == -1)
            {
                //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4f, ForceMode2D.Impulse);
            }
            tempo_shot = 0;
            fire.Emit(1);
            
        }
        */
    }

    public void Pular(CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && puloVezes <= puloMax && tempo_vivo >= tempo_vivo_t)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            animator.SetBool("JUMP", true);
            noChao = false;
            puloVezes += 1;
        }
    }

    public void Sentido(CallbackContext context)
    {
        if (tempo_vivo >= tempo_vivo_t)
        {
            sentido = context.ReadValue<float>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage"))
        {
            if (tempo_dano <= 0)
            {
                LevelManager.instance.LowDamage();
                if (animator.GetBool("GROUNDED"))
                {
                    if (collision.gameObject.transform.position.x < transform.position.x)
                    {
                        rigidbody.AddForce(new Vector2(16, 3), ForceMode2D.Force);
                    }
                    else
                    {
                        rigidbody.AddForce(new Vector2(-16, 3), ForceMode2D.Force);
                    }
                }
                Destroy(collision.gameObject);
                dano.Emit(30);
                tempo_dano = 60;
            }
            
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.collider.CompareTag("EnemyHit"))
        {
            if (tempo_dano <= 0)
            {
                LevelManager.instance.LowDamage();
                if (animator.GetBool("GROUNDED"))
                {
                    if (collision.gameObject.transform.position.x < transform.position.x)
                    {
                        rigidbody.AddForce(new Vector2(16, 3), ForceMode2D.Force);
                    }
                    else
                    {
                        rigidbody.AddForce(new Vector2(-16, 3), ForceMode2D.Force);
                    }
                }
                dano.Emit(30);
                tempo_dano = 120;
            }

        }
    }

    private void TiroAction()
    {
        if (atirante != 0 && tempo_shot >= 10)
        {
            while (atirante != 0)
            {
                charge_load++;
                if (charge_load >= 60)
                {
                    charge.Emit(1);
                }
            }
            if (charge_load >= 60)
            {
                animator.SetTrigger("FIRE");
                if (transform.localScale.x == 1)
                {
                    //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
                    tiro.transform.localScale = new Vector3(4, 4, 1);
                }
                else if (transform.localScale.x == -1)
                {
                    //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4f, ForceMode2D.Impulse);
                    tiro.transform.localScale = new Vector3(4, 4, 1);
                }
                tempo_shot = 0;
                fire.Emit(1);
            }
            else
            {
                animator.SetTrigger("FIRE");
                if (transform.localScale.x == 1)
                {
                    //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
                }
                else if (transform.localScale.x == -1)
                {
                    //Instantiate(explosaoprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    var tiro = Instantiate(tiroprefab, new Vector3(transform.position.x + (0.25f * transform.localScale.x), transform.position.y + 0.55f, transform.position.z), Quaternion.identity);
                    tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4f, ForceMode2D.Impulse);
                }
                tempo_shot = 0;
                fire.Emit(1);
            }
        }
        else
        {
            charge_load = 0;
        }
    }
}
