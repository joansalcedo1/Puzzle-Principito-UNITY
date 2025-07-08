using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasarAfinal : MonoBehaviour
{
    // Start is called before the first frame update
    public void CambiarAEscena(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }
    private void OnTriggerEnter(Collider other)
    {
        CambiarAEscena("final");
    }
}
