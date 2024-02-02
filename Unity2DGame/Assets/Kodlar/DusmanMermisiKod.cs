using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanMermisiKod : MonoBehaviour
{
    Vector3 hizVektoru;
    // Start is called before the first frame update
    void Start()
    {
        hizVektoru.y = -10;
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
        transform.position += hizVektoru * Time.deltaTime;
    }
}
