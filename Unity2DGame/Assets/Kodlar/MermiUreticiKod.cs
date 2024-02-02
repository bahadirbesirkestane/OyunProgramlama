using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;

using UnityEngine;

public class MermiUreticiKod : MonoBehaviour
{
    public TextMeshProUGUI upgradeSuresiText;
    int upgradeSuresi = 5;
    float UpgradeEtmeAraligi = 1.0f;
    float TextSuresi = 0.0f;

    public GameObject mermiSablon;
    //public GameObject oyuncuSablon;
    //public GameObject UpgradeDusmanSablon;
    
    float mermiAtisAraligi = 0.2f;
    float mermiAtisZamani = 0.5f;

    Transform mermiCikis;
    Transform silah1;
    Transform silah2;

    public int evetvuruldu = 2;
    public bool vuruldu = false;
    // Start is called before the first frame update
    void Start()
    {
        upgradeSuresiText = GameObject.Find("/Canvas/UpgradeSuresi").GetComponent<TextMeshProUGUI>();
        upgradeSuresiText.text = "";

        mermiCikis = GameObject.Find("SilahUcu").transform;
        silah1 = GameObject.Find("Silah1").transform;
        silah2 = GameObject.Find("Silah2").transform;

    }

    public void vuruldumu()
    {
        evetvuruldu = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            
            

            //bool vuruldu = UpgradeDusmanSablon.GetComponent<UpgradeDusmanKod>().vurulduMu(" ");

            
            
            if (evetvuruldu == 0)
            {
                //if (TextSuresi >= UpgradeEtmeAraligi)
                //{
                //    upgradeSuresiText.text = upgradeSuresi.ToString();
                //    upgradeSuresi--;
                //    if (upgradeSuresi < 0)
                //    {
                //        evetvuruldu = 1;
                //        upgradeSuresi = 5;
                //    }

                //    TextSuresi = 0.0f;
                //}
                

                if (mermiAtisZamani >= mermiAtisAraligi)
                {
                    var yeniMermi1 = Instantiate(mermiSablon);
                    var yeniMermi2 = Instantiate(mermiSablon);

                    yeniMermi1.transform.position = silah1.transform.position;
                    yeniMermi2.transform.position = silah2.transform.position;


                    mermiAtisZamani = 0.0f;



                }

                
            }
            else
            {
                if (mermiAtisZamani >= mermiAtisAraligi)
                {
                    var yeniMermi = Instantiate(mermiSablon);
                    yeniMermi.name = "MermiKlon";
                    
                    yeniMermi.transform.position = mermiCikis.transform.position;
                    //vuruldu = yeniMermi.GetComponent<MermiKod>().evet;
                    //Mermiler.Add(yeniMermi);

                    mermiAtisZamani = 0.0f;

                    //vuruldu = yeniMermi.GetComponent<MermiKod>().vuruldu;

                }
            }

            

            mermiAtisZamani += Time.deltaTime;
        }


        if(evetvuruldu==0)
        {
            if (TextSuresi >= UpgradeEtmeAraligi)
            {
                upgradeSuresiText.text = upgradeSuresi.ToString();
                upgradeSuresi--;
                if (upgradeSuresi < 0)
                {
                    evetvuruldu = 1;
                    upgradeSuresi = 5;
                }

                TextSuresi = 0.0f;
            }

            TextSuresi += Time.deltaTime;
        }
    }
}
