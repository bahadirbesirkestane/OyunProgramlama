using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeDusmanUreticiKod : MonoBehaviour
{
    public GameObject UpgradeDusmanSablon;
    

    float sinirY;
    float sinirX;
    float DusmanUretmaAraligi = 20.0f;
    float gecenSure = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        var cameraObj = GameObject.Find("Main Camera");        
        var camera = cameraObj.GetComponent<Camera>();

        


        sinirY = camera.orthographicSize;
        sinirX = camera.orthographicSize * camera.aspect;

        
    }

    void UpgradeDusmanUret()
    {
        

        if (gecenSure>= DusmanUretmaAraligi)
        {
            var yeniDusman = Instantiate(UpgradeDusmanSablon,transform);
            yeniDusman.name = "UpgradeDusmanSablon";
            
            float X = Random.Range(-(sinirX-1.0f), sinirX-1.0f);
            float Y= Random.Range(-(sinirY-2.0f), sinirY-1.0f);

            yeniDusman.transform.position = new Vector3(X, Y, 0.0f);

            
            gecenSure = 0.0f;
        }


        

        gecenSure += Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        UpgradeDusmanUret();

       
    }
}
