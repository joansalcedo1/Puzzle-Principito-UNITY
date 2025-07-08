using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject principito;
    public GameObject principitoAMostrar;
    
    private void OnTriggerEnter(Collider other)
    {
        principito.SetActive(false);

        principitoAMostrar.SetActive(true);

    }
}
