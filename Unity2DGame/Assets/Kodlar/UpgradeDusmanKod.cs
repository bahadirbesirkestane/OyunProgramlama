using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UpgradeDusmanKod : MonoBehaviour
{
    public GameObject UpgradeSuresiSablon;

    float saydamlik = 0.8f;
    float DusmanYoketmeAraligi = 0.5f;
    float yoketmeSuresi = 0.0f;

    int yasam;

    
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        
        yasam = 1;
        rb = GetComponent<Rigidbody2D>();
       
        //upgradeSuresiText = UpgradeSuresiSablon.GetComponent<TextMeshPro>();
        //upgradeSuresiText.text = "";

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.name== "MermiKlon")
    //    {
    //        yasam = 0;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 0.2f);

        if(saydamlik <= 0.0f)
        {
            Destroy(gameObject);
        }

        if (yoketmeSuresi >= DusmanYoketmeAraligi)
        {
            gameObject.GetComponent<SpriteRenderer>().color= new Color(1.0f, 1.0f, 1.0f, saydamlik);
            saydamlik -= 0.05f;

            yoketmeSuresi = 0.0f;

        }

        yoketmeSuresi += Time.deltaTime;

       
    }
}
