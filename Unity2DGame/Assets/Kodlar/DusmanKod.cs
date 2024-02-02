using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKod : MonoBehaviour
{
    float azalmaSuresi = 0.3f;
    float azalmaSiniri = 0.0f;
    float saydamlik = -0.1f;

    public GameObject dusmanMermisiSablon;

    Transform silah1;
    Transform silah2;
    Transform temp;

    Transform dusmanGovde;
    Transform dusmanBurun;

    Vector3 hareketVektoru;
    float hizCarpani;
    Rigidbody2D rb;

    float mermiAtisAraligi = 1.0f;
    float mermiAtisZamani = 0.0f;

    float AsagiInmeAraligi = 0.7f;
    float AsagiInmeZamani = 0.0f;
    int i;

    float X;
    float Y;

    int sinir = 1;
    
    public int dusmanVuruldu = 2;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        hizCarpani = 0.6f;

        dusmanGovde = GameObject.Find("DusmanGovde").transform;
        dusmanBurun = GameObject.Find("DusmanBurun").transform;

        silah1 = GameObject.Find("DusmanSilah1").transform;
        silah2 = GameObject.Find("DusmanSilah2").transform;
        temp = silah1;

        rb = GetComponent<Rigidbody2D>();


        X = 5.0f;
        Y= 0.0f;

    }

    void DusmanHareket()
    {
        
    }

    public void DusmanVuruldumu()
    {
        dusmanVuruldu = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="SagSinir")
        {
            sinir = 1;
            X = 0.0f;
            Y = -4.0f;

            AsagiInmeZamani = 0.0f;
        }

        if (collision.name == "SolSinir")
        {
            sinir = 0;
            X = 0.0f;
            Y = -4.0f;

            AsagiInmeZamani = 0.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name=="AltSinir")
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        if (AsagiInmeZamani >= AsagiInmeAraligi && X == 0.0f)
        {
            if (sinir == 1)
            {
                X = -5.0f;
                Y = 0.0f;
            }
            else
            {
                X = 5.0f;
                Y = 0.0f;
            }

            AsagiInmeZamani = 0.0f;
        }

        AsagiInmeZamani += Time.deltaTime;

        hareketVektoru.x = X;
        hareketVektoru.y = Y;

        rb.velocity = hareketVektoru * hizCarpani;



        if (mermiAtisZamani >= mermiAtisAraligi && dusmanVuruldu != 0)
        {
            if (i == 1)
            {
                temp = silah1;
                i = 0;
            }
            else
            {
                temp = silah2;
                i = 1;
            }

            //deger = kosul ? true : false;

            var yeniMermi = Instantiate(dusmanMermisiSablon);
            yeniMermi.name = "DusmanMermisiKlon";

            yeniMermi.transform.position = temp.transform.position;



            mermiAtisZamani = 0.0f;



        }

        if (dusmanVuruldu == 0)
        {
            rb.velocity=new Vector3(0.0f, 0.0f, 0.0f);
            if (saydamlik<=-1.0f)
            {
                Destroy(gameObject);
            }
            //transform.position += hizVektoru * Time.deltaTime;
            dusmanGovde.transform.position += new Vector3(0.0f, 1.2f, 0.0f) * Time.deltaTime;
            dusmanBurun.transform.position += new Vector3(0.0f, -1.2f, 0.0f) * Time.deltaTime;
            silah1.transform.position += new Vector3(-1.0f, -1.0f, 0.0f) * Time.deltaTime;
            silah2.transform.position += new Vector3(1.0f, -1.0f, 0.0f) * Time.deltaTime;

            float donus = 2.5f;
            dusmanGovde.transform.Rotate(0.0f, 0.0f, donus);
            dusmanBurun.transform.Rotate(0.0f, 0.0f, donus);
            silah1.transform.Rotate(0.0f, 0.0f, donus);
            silah2.transform.Rotate(0.0f, 0.0f, donus);



            if (azalmaSiniri >= azalmaSuresi)
            {
                Color saydamlikAzalt = new Color(0.0f, 0.0f, 0.0f, saydamlik);
                dusmanGovde.GetComponent<SpriteRenderer>().color += saydamlikAzalt;
                dusmanBurun.GetComponent<SpriteRenderer>().color += saydamlikAzalt;
                silah1.GetComponent<SpriteRenderer>().color += saydamlikAzalt;
                silah2.GetComponent<SpriteRenderer>().color += saydamlikAzalt;

                saydamlik -= 0.04f;

                azalmaSiniri = 0.0f;

            }

            azalmaSiniri += Time.deltaTime;
        }
        mermiAtisZamani += Time.deltaTime;
    }
}
