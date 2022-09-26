using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaAcoAcao : MonoBehaviour
{
    [SerializeField]
    public GameObject explosaoprefab;

    [SerializeField]
    public ParticleSystem glow;

    public Sprite frame_1;
    public Sprite frame_2;

    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer++; }
        if (timer == 1)
        {
            GetComponent<SpriteRenderer>().sprite = frame_1;
        }

        if (timer == 64)
        {
            GetComponent<SpriteRenderer>().sprite = frame_2;
        }

        if (timer == 92)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tiro"))
        {
            if (collision.transform.localScale.x == 2)
            {
                timer++;
                for (int i = 0; i < 8; i++)
                {
                    var exp = Instantiate(explosaoprefab, new Vector3(transform.position.x + Random.Range(-0.25f, 0.25f), transform.position.y + Random.Range(-0.25f, 0.25f), transform.position.z), Quaternion.identity);
                    exp.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
                }


            }
            else
            {
                glow.Emit(15);
            }

            Destroy(collision.gameObject);


        }
    }
}
