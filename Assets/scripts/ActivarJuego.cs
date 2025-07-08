using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ActivarJuego : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelJuego, panelAc2, panelAc3;
    public bool juegoActivo= false, AC2Activo, AC3Activo = false;
  
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.CompareTag("Player") && CompareTag("Ac1"))
        {
         audioSource.Play();
         activarGame();
         panelJuego.SetActive(true);
         
        // dado.transform.position = this.aparicionDado.transform.position;
         Debug.Log("jugador ha entrado a ac1");
        } else if (collision.collider.CompareTag("Player") && CompareTag("Ac2"))
        {
            acertijo2AC();
            audioSource.Play();
            panelAc2.SetActive(true);
            //Debug.Log("jugador ha entrado a ac2");
        } else if (collision.collider.CompareTag("Player") && CompareTag("Ac3"))
        {
           acertijo3AC();
           audioSource.Play();
           panelAc3.SetActive(true);
            Debug.Log("jugador ha entrado a ac3");

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && CompareTag("Ac1"))
        {
            panelJuego.SetActive(false);
            desactivarGame();
            
        }
        if (collision.collider.CompareTag("Player") && CompareTag("Ac2"))
        {
            panelAc2.SetActive(false);
            acertijo2DesAC();
        }
        if (collision.collider.CompareTag("Player") && CompareTag("Ac3"))
        {
            panelAc3.SetActive(false);
            acertijo3DesAC();
        }
    }
    
    public bool activarGame() 
    {
        Debug.Log("Acertijo 1 Activado");
        juegoActivo = true;
        return juegoActivo;
    }
    public bool acertijo2AC() 
    {
        Debug.Log("Acertijo 2 Activado, convirtiendo en true");
        AC2Activo = true; 
        return AC2Activo;
    }
    public bool acertijo3AC() 
    {
        Debug.Log("Acertijo 3 Activado");
        AC3Activo = true;
        return AC3Activo;
    }
    public bool desactivarGame() 
    {
        Debug.Log("Acertijo 1 desactivado");
        juegoActivo = false;
        return juegoActivo;
    }
    public bool acertijo2DesAC() 
    {
        Debug.Log("Acertijo 2 desactivado");
        AC2Activo = false;
        return AC2Activo;
    }
    public bool acertijo3DesAC() 
    {
        Debug.Log("Acertijo 3 desactivado");
        AC3Activo = false;
        return AC3Activo;
    }
}
