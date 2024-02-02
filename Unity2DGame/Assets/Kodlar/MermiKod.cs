using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//using static UnityEditor.PlayerSettings;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class MermiKod : MonoBehaviour
{
    //[SerializeField] float hizCarpani = 10.0f;
    // Start is called before the first frame update



    

    Vector3 hizVektoru;

    //public GameObject patlamaSablon;

    Transform tra;
    GameObject mermiUretici;

    public GameObject patlamaSablon;

    public GameObject kucukBosSablon;





    public int upgradeVuruldu = 1;


    void Start()
    {
        
        hizVektoru.y = 20;

        

        mermiUretici = GameObject.Find("MermiUret");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "UstSinir")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.name == "Dusman")
        //{


        //    var yeniPatlama = Instantiate(patlamaSablon);
        //    yeniPatlama.transform.position = collision.gameObject.transform.position;

        //    Destroy(gameObject);
        //    Destroy(collision.gameObject);
        //}
        if (collision.name == "BuyukBos")
        {
            Destroy(gameObject);
            var pos = collision.gameObject.transform.position;

            Destroy(collision.gameObject);

            var solBos = Instantiate(kucukBosSablon);
            var sagBos = Instantiate(kucukBosSablon);
            solBos.name = "KucukBos";
            sagBos.name = "KucukBos";


            solBos.transform.position = pos + new Vector3(-0.2f, 0.0f, 0.0f);
            sagBos.transform.position = pos + new Vector3(0.2f, 0.0f, 0.0f);
            solBos.GetComponent<KucukBosKod>().yonAta(1.5f);
            sagBos.GetComponent<KucukBosKod>().yonAta(-1.5f);



            patlamaAnimasyon(pos);



        }

        if (collision.name == "KucukBos")
        {
            var pos = collision.gameObject.transform.position;

            Destroy(gameObject);

            Destroy(collision.gameObject);

            patlamaAnimasyon(pos);
        }

        if (collision.name == "UpgradeDusmanSablon")
        {
            var pos = collision.gameObject.transform.position;

            //GetComponent<OyuncuKod>().upgradeVuruldu = 0;
            upgradeVuruldu = 0;
            //upgradeSuresiText.text = upgradeSuresi.ToString();
            mermiUretici.GetComponent<MermiUreticiKod>().vuruldumu();
            Destroy(gameObject);
            Destroy(collision.gameObject);


        }


        if (collision.name == "Dusman")
        {
            Destroy(gameObject);
            
            collision.gameObject.GetComponent<DusmanKod>().DusmanVuruldumu();

            //Destroy(collision);
            

        }



        //Destroy(yeniPatlama);


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



    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += hizVektoru * Time.deltaTime;

    }

}

