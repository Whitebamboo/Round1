using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneMusic : MonoBehaviour
{
    public AudioSource loseBgm;
    public AudioSource loseSFX;

    void Start()
    {
        if(!Player.winStatus)
        {
            loseBgm.Play();
            loseSFX.Play();
        }
    }
}
