using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosUreticiKod : MonoBehaviour
{

    float maxX;
    float minX;

    float Y;

    public GameObject BosSablon;

    float BosUretmaAraligi = 2.0f;
    float gecenSure = 0.0f;
    void Start()
    {
        maxX = GameObject.Find("BosUretmeSagSinir").transform.position.x;
        minX = GameObject.Find("BosUretmeSolSinir").transform.position.x;

        Y = GameObject.Find("BosUretmeSolSinir").transform.position.y;

    }

    void BosUret()
    {
        if (gecenSure > BosUretmaAraligi)
        {
            var Bos = Instantiate(BosSablon, transform);
            Bos.name = "BuyukBos";
            //yeniDusman.transform.SetParent(transform);
            //yeniDusman.transform.position=transform.position;

            float X = Random.Range(minX, maxX);

            Bos.transform.position = new Vector3(X, Y, 0.0f);

            //Dusmanlar.Add(yeniDusman);

            gecenSure = 0.0f;
        }

        gecenSure += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        BosUret();
    }
}
