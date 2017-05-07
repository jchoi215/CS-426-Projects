using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceController : Photon.MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("playerObject"))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
