using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public TextMeshProUGUI panelFeedback;
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float maxLookAngle = 80f;
    public float jumpForce = 5f;
    public LayerMask LayerGround; // Define las capas que consideras como suelo
    public GameObject C, D, E, F, G, A, B, C4, D4, E4, F4, G4, A4, B4, C5;
    public GameObject Cshar, Dshar, Fshar, Gshar, Ashar, C4shar, D4shar, F4shar, G4shar, A4shar;
    public GameObject panelGanadorAC1, panelGanadorAC2, panelGanadorAC3;

    
    private AudioSource audioSourceCaja;
    private ActivarJuego activarJuegoVar;
    private ActivarJuego activarAcertijo3;
    private ActivarJuego activarAcertijo2;
    private ActivarSonido activarSonido;
    private float pitch = 0f;
    private float yaw = 0f;
    private bool isGrounded = true;
    private Rigidbody rb;
    private List<KeyCode> correctSequence = new List<KeyCode> { KeyCode.F, KeyCode.G, KeyCode.N, KeyCode.L };
    private List<KeyCode> userInputSequence = new List<KeyCode>();
    private Dictionary<KeyCode, (GameObject, string)> keyToNoteMap;
    void Start()
    {
        audioSourceCaja = GetComponent<AudioSource>();
        
        GameObject activarJuegoObject = GameObject.Find("Activar");
        GameObject activarJuegoObject2 = GameObject.Find("ActivarAC2");
        GameObject activarJuegoObject3 = GameObject.Find("ActivarAC3");
        rb = GetComponent<Rigidbody>();
        activarJuegoVar = activarJuegoObject.GetComponent<ActivarJuego>();
        activarAcertijo2 = activarJuegoObject2.GetComponent<ActivarJuego>();
        activarAcertijo3 = activarJuegoObject3.GetComponent<ActivarJuego>();
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor
        Cursor.visible = false;

        // Inicializar el diccionario con las teclas, objetos de AudioSource y etiquetas de texto
        keyToNoteMap = new Dictionary<KeyCode, (GameObject, string)>
        {
            { KeyCode.R, (C, "Do") },
            { KeyCode.Alpha5, (Cshar, "Do#") },
            { KeyCode.T, (D, "Re") },
            { KeyCode.Alpha6, (Dshar, "Re#") },
            { KeyCode.Y, (E, "Mi") },
            { KeyCode.U, (F, "Fa") },
            { KeyCode.Alpha8, (Fshar, "Fa#") },
            { KeyCode.I, (G, "Sol") },
            { KeyCode.Alpha9, (Gshar, "Sol#") },
            { KeyCode.O, (A, "La") },
            { KeyCode.Alpha0, (Ashar, "La#") },
            { KeyCode.P, (B, "Si") },
            
            { KeyCode.E, (C4, "Do(4)") },
            { KeyCode.C, (C4shar, "Do#(4)") },
            { KeyCode.F, (D4, "Re(4)") },  
            { KeyCode.V, (D4shar, "Re#(4)") },
            { KeyCode.G, (E4, "Mi(4)") },
            { KeyCode.B, (F4, "Fa(4)") },
            { KeyCode.H, (F4shar, "Fa#(4)") },
            { KeyCode.N, (G4, "Sol(4)") },
            { KeyCode.J, (G4shar, "Sol#(4)") },
            { KeyCode.M, (A4, "La(4)") },
            { KeyCode.K, (A4shar, "La#(4)") },
            { KeyCode.L, (B4, "Si(4)") },
            { KeyCode.Z, (C5, "Do(5)") },
            
        };
    }

    void Update()
    {
        
        // Movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement = transform.TransformDirection(movement) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Movimiento de la cámara
        yaw += Input.GetAxis("Mouse X") * lookSpeed;
        pitch -= Input.GetAxis("Mouse Y") * lookSpeed;
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Comprobar si está en el suelo
        isGrounded = Physics.CheckSphere(transform.position, 1f, LayerGround);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("salto");
        }

        //Revisar nota presionada 
        sonarNotall();

        if (activarJuegoVar.juegoActivo)
        {
            Debug.Log("juegoActivo es true");
            acertijo1();
        }
        else { panelGanadorAC1.SetActive(false); }
        if (activarAcertijo2.AC2Activo) 
        {
            acertijo2();   
        } else {panelGanadorAC2.SetActive(false); }
        //chekea lista de notas ingresadas por el usuario
       
        if (activarAcertijo3.AC3Activo) 
        {
            acertijo3();
        }
        else { panelGanadorAC3.SetActive(false); }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cuarto2"))
        {
            Debug.Log("Player en el cuarto2");
            //SetItemsActive(true);
        }
    }*/

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Cuarto2"))
        {
            Debug.Log("Player no esta en el cuarto2");
            //SetItemsActive(false);
        }
    }*/
   
    /*void SetItemsActive(bool isActive)
    {
        foreach (var entry in keyToNoteMap)
        {
            if (entry.Value.Item2.Contains("(4)"))
            {
                entry.Value.Item1.SetActive(isActive);
                //entry.Value.Item2.
            }
        }
    }*/

    public void acertijo1()
    {
        if (G.GetComponent<AudioSource>().isPlaying && C.GetComponent<AudioSource>().isPlaying)
        {
            audioSourceCaja.Play();
            panelGanadorAC1.SetActive(true);
            GameObject[] Cajas = GameObject.FindGameObjectsWithTag("Caja");
            foreach (GameObject Caja in Cajas)
            {
                Caja.SetActive(false);
            }
            //cajasAud.Play();

        }
    }
    public void acertijo2()
    {
        if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.M))
        {
            panelGanadorAC2.SetActive(true);
            Debug.Log("acertijo 2 completado");
            audioSourceCaja.Play();
            GameObject[] Cajas = GameObject.FindGameObjectsWithTag("Caja2");
            foreach (GameObject Caja in Cajas)
            {
                Caja.SetActive(false);
            }
            

        }
    }
    public void acertijo3()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            userInputSequence.Add(KeyCode.F);
            CheckSequence();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            userInputSequence.Add(KeyCode.G);
            CheckSequence();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            userInputSequence.Add(KeyCode.N);
            CheckSequence();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            userInputSequence.Add(KeyCode.L);
            CheckSequence();
        }
        
    }
    void CheckSequence()
    {
        // Verificar si la longitud de la secuencia del usuario es mayor que la secuencia correcta
        if (userInputSequence.Count > correctSequence.Count)
        {
            Debug.Log("reiniciar 1");
            // Reiniciar la secuencia del usuario si es incorrecta
            userInputSequence.Clear();
            return;
        }

        // Verificar si la secuencia del usuario coincide con la secuencia correcta hasta ahora
        for (int i = 0; i < userInputSequence.Count; i++)
        {
            if (userInputSequence[i] != correctSequence[i])
            {
                // Reiniciar la secuencia del usuario si es incorrecta
                Debug.Log("reiniciar 2");
                userInputSequence.Clear();
                return;
            }
        }

        // Verificar si la secuencia del usuario coincide completamente con la secuencia correcta
        if (userInputSequence.Count == correctSequence.Count)
        {
            // Mostrar el panel ganador
            panelGanadorAC3.SetActive(true);
            audioSourceCaja.Play();
            GameObject[] Cajas = GameObject.FindGameObjectsWithTag("Caja3");
            foreach (GameObject Caja in Cajas)
            {
                Caja.SetActive(false);
            }
            Debug.Log("¡Ganaste!");
        }
    }

    public void sonarNotall()
    {
        foreach (var entry in keyToNoteMap)
        {
            if (Input.GetKeyDown(entry.Key))
            {
                entry.Value.Item1.GetComponent<AudioSource>().Play();
                panelFeedback.text = entry.Value.Item2;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f); // Para visualizar la esfera de comprobación del suelo
    }
}
