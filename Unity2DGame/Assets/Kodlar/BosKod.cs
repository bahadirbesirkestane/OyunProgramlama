using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosKod : MonoBehaviour
{
    float hizCarpani;

    Rigidbody2D rb;
    Vector3 hizVektoru;

    int baslangicAcisi;
    int yon;
    float artisMiktari;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hizCarpani = 0.6f;

        int yon = Random.Range(0, 2);

        float y = -1.5f;
        float x = 2.0f;

        if (yon == 1)
        {
            x = -x;
        }

        rb.velocity = new Vector3(x, y, 0.0f) * hizCarpani;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "SolSinir" || collision.name == "SagSinir"
            || collision.name == "BuyukBos")
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
