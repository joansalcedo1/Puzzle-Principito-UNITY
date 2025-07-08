using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversacionNPC3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelE;
    public GameObject panelConversacion;
    public GameObject conversacion1;
    public GameObject conversacion2;
    public TextMeshProUGUI textoConver2;
    private bool playerInRange = false;
    private int estadoConversacion = 0;
    DateTime fechaHoraActual;
    private void Start()
    {
        fechaHoraActual = DateTime.Now;
    }
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
                    textoConver2.text = "La princesa tuvo razón, me dijo que tu llegarías el "+ fechaHoraActual.ToString("dd/MM/yyyy a la HH:mm");
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
