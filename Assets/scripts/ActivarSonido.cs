using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivarSonido : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    public TextMeshProUGUI notaT;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PlaySound();
            notaT.text = gameObject.name;
            
        }
    }
    public void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            
        }
    }
}
