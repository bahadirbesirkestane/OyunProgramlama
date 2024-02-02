using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;


public class OyuncuKod : MonoBehaviour
{

    Vector3 hizVectoru;
    
    public float hizCarpani;

    float xMove;
    float yMove;

    

    [SerializeField] Rigidbody2D rb;

    

    public int upgradeVuruldu=1;
    public GameObject patlamaSablon;

    // Start is called before the first frame update
    void Start()
    {


        

        hizCarpani = 15.0f;

        hizVectoru.x = hizCarpani;

        rb = GetComponent<Rigidbody2D>();
    }
    void girisKontrol()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

    }

    void konumGuncelle()
    {
        hizVectoru.x = xMove * hizCarpani;
        hizVectoru.y = yMove * hizCarpani;

        rb.velocity = hizVectoru;



    }

    void konum()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {          
            hizVectoru.x = -hizCarpani;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            hizVectoru.x = hizCarpani;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            hizVectoru.x =0.0f;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            hizVectoru.x = 0.0f;
        }


        rb.velocity = hizVectoru;

    }

    void patlamaAnimasyon(Vector3 pos)
    {
        int parcacikSayisi = 5;
        float[] Xyonleri = new float[] { 1.0f, 0.95f, 0.87f, 0.55f, 0.14f };
        float[] Yyonleri = new float[] { 0.0f, 0.3f, 0.5f, 0.84f, 0.99f };
        float eksen = 1.0f;



        //ilk for daki 4, eksen sayýsýnýn 4 ü. 4 adet eksenimiz var.
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < Xyonleri.Length; j++)
            {
                var yeniPatlama = Instantiate(patlamaSablon);
                yeniPatlama.transform.position = pos;

                yeniPatlama.GetComponent<PatlamaKod>().yonAta(Xyonleri[j] * eksen, Yyonleri[j]);
            }

            eksen = -eksen;
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < parcacikSayisi; j++)
            {
                var yeniPatlama = Instantiate(patlamaSablon);
                yeniPatlama.transform.position = pos;

                yeniPatlama.GetComponent<PatlamaKod>().yonAta(Xyonleri[j] * eksen, -Yyonleri[j]);
            }

            eksen = -eksen;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "BuyukBos" || collision.name == "KucukBos" )
        {
            var pos=collision.transform.position;
            Destroy(collision.gameObject);
            patlamaAnimasyon(pos);
        }

        if(collision.name =="Dusman")
        {
            collision.gameObject.GetComponent<DusmanKod>().DusmanVuruldumu();
            var pos = collision.transform.position;
            
            patlamaAnimasyon(pos);
        }

        if(collision.name == "DusmanMermisiKlon")
        {
            var pos = collision.transform.position;
            Destroy(collision.gameObject);
            patlamaAnimasyon(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //girisKontrol();

        //konumGuncelle();
        konum();

    }
}
