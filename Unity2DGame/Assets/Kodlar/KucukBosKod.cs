using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukBosKod : MonoBehaviour
{
    public Rigidbody2D rb;

    public float hizCarpani;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hizCarpani = 0.6f;


    }

    public void yonAta(float yon)
    {
        rb.velocity = new Vector3(yon, -1.5f, 0.0f) * hizCarpani;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "SolSinir" || collision.name == "SagSinir"
            || collision.name == "KucukBos")
        {
            var hiz = rb.velocity;

            hiz.x = -hiz.x;

            rb.velocity = hiz;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "AltSinir")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
