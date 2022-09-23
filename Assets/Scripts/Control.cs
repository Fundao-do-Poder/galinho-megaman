using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Control : MonoBehaviour
{
    float sentido = 0; // o nome desse sujeito eh campo, que eh uma variavel declarada no escopo da classe
    const float RAIO_JUMPABLE = 0.05f;
    int puloVezes = 1;
    int puloMax = 2; // somar
    bool noChao = false;

    [SerializeField]
    ParticleSystem fire;

    [SerializeField]
    float forcaPulo = 8f;

    Animator animator;
    Rigidbody2D rigidbody;

    [SerializeField]
    LayerMask layerMask;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
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
        if (context.ReadValue<float>() == 1)
        {
            animator.SetTrigger("FIRE");
            fire.Emit(1);
        }
    }

    public void Pular(CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && puloVezes <= puloMax)
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
        sentido = context.ReadValue<float>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage"))
        {
            LevelManager.instance.LowDamage();
            Destroy(collision.gameObject);
        }
    }
}
