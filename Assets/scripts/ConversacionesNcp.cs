using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversacionesNcp : MonoBehaviour
{
    public GameObject panelE;
    public GameObject panelConversacion;
    public GameObject conversacion1;
    public GameObject conversacion2;

    private bool playerInRange = false;
    private int estadoConversacion = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            panelE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            panelE.SetActive(false);
            panelConversacion.SetActive(false);
            conversacion1.SetActive(false);
            conversacion2.SetActive(false);
            estadoConversacion = 0;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.X))
        {
            switch (estadoConversacion)
            {
                case 0:
                    panelE.SetActive(false);
                    panelConversacion.SetActive(true);
                    conversacion1.SetActive(true);
                    estadoConversacion++;
                    break;
                case 1:
                    conversacion1.SetActive(false);
                    conversacion2.SetActive(true);
                    estadoConversacion++;
                    break;
                case 2:
                    conversacion2.SetActive(false);
                    panelConversacion.SetActive(false);
                    estadoConversacion = 0;
                    break;
            }
        }
    }
}
