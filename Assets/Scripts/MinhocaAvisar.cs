using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinhocaAvisar : MonoBehaviour
{
    [SerializeField]
    GameObject minhocaprefab;

    [SerializeField]
    LayerMask layerMask;

    float tempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo++;
        if (tempo > 60*7)
        {
            Instantiate(minhocaprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
        var mv = transform.position;
        mv.y = -18.36f;
    }

    private void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.03f, layerMask);
        // Debug.Log(rigidbody.velocity.y);
        if (hit == null)
        {
            Destroy(gameObject);
        }
    }
}
