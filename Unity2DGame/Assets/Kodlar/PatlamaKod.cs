using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaKod : MonoBehaviour
{
    float azalmaSuresi=0.2f;
    float azalmaSiniri = 0.0f;
    

    public float hizCarpani;
    Rigidbody2D rb;
    Vector3 hizVektoru;
    
    float saydamlik = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //renderer = GetComponent<SpriteRenderer>();
        hizCarpani = 10.0f;

        //renderer.color = new Color(1.0f, 1.0f, 1.0f,0.5f);
    }
    public void yonAta(float yonX,float yonY)
    {
        rb.velocity = new Vector3(yonX, yonY,0.0f) * hizCarpani;
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += hizVektoru * Time.deltaTime;

        if (saydamlik <= 0.0f)
        {
            Destroy(gameObject);
        }

        if (azalmaSiniri >= azalmaSuresi)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, saydamlik);
            saydamlik -= 0.2f;

            azalmaSiniri = 0.0f;

        }

        azalmaSiniri += Time.deltaTime;


    }
}
