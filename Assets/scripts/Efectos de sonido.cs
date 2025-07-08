using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efectosdesonido : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { AudioSource.Play(); }
    }
}
