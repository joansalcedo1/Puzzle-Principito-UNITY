using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { AudioSource.Play(); }
        if (AudioSource.isPlaying && Input.GetKeyDown(KeyCode.Q)) { AudioSource.Stop(); }
    }
}
