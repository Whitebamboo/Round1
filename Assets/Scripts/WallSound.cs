using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSound : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onDrag()
    {
        audioSource.clip = sounds[0];
        audioSource.Play();

    }

    public void offDrag()
    {
        audioSource.clip = sounds[1];
        audioSource.Play();

    }
}
