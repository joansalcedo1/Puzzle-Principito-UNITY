using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EmpezarJuego : MonoBehaviour
{
    public GameObject panelEmpezar;
    DateTime fechaHoraActual;
    public TextMeshProUGUI mostrarFecha;
    public bool p = true;
    // Start is called before the first frame update
    private void Start()
    {
        fechaHoraActual = DateTime.Now;
    }
    public void CambiarAEscena(string Escena)
    {
        Escena = "juego";
        SceneManager.LoadScene(Escena);
    }
    private void Update()
    {
        if (p) 
        {
            mostrarFecha.text= fechaHoraActual.ToString("dd/MM/yyyy");
        }
        
    }
    
    // Update is called once per frame

}
