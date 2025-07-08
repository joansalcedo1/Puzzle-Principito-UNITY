using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoDado : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource AudioSource;
    public LayerMask ground;
    bool isGrounded;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        ground = GetComponent<LayerMask>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = Physics.CheckSphere(transform.position, 1f, ground);
        if (isGrounded) 
        { 
            AudioSource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
