using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    [SerializeField] private AudioClip[] helpSound;
    [SerializeField] private AudioClip[] attactSound;
    [SerializeField] private AudioClip[] whatIsThat;

    [SerializeField] private AudioSource helpAudioSource;
    [SerializeField] private AudioSource attactAudioSource;
    [SerializeField] private AudioSource WITAudioSource;
    [SerializeField] private AudioSource screamingAudioSource;
    [SerializeField] private AudioSource winAudioSource;
    [SerializeField] private AudioSource pullGateAudioSource;
    [SerializeField] private AudioSource slideDoorAudioSource;
    [SerializeField] private AudioSource MazeBaseAudioSource;
    [SerializeField] private AudioSource playWinBGMAudioSource;
    [SerializeField] private AudioSource playLoseBGMAudioSource;
    [SerializeField] private AudioSource playLoseSFXAudioSource;

    public static SoundManage Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void PlayAttackedSound()
    {
        if (Player.currentHealth == 60)
        {
            Debug.Log("sound 1");
            attactAudioSource.clip = attactSound[0];
        }
        else if (Player.currentHealth == 30)
        {
            Debug.Log("sound 2");
            attactAudioSource.clip = attactSound[1];
        }
        attactAudioSource.Play();
    }

    public void StopAttackedSound()
    {
        attactAudioSource.Stop();
    }

    public void PlayHelpSound()
    {
        int randomIndex = Random.Range(0, helpSound.Length);
        helpAudioSource.clip = helpSound[randomIndex];
        helpAudioSource.Play();
    }

    public void PlayWITSound()
    {
        WITAudioSource.clip = whatIsThat[0];
        WITAudioSource.Play();
    }

    public void PlayWITSound2()
    {
        WITAudioSource.clip = whatIsThat[1];
        WITAudioSource.Play();
    }

    public void PlayScreamingSound()
    {
        screamingAudioSource.Play();
    }

    public void PlayWinGameSound()
    {
        winAudioSource.Play();
    }

    public void PlayPullGateSound()
    {
        pullGateAudioSource.Play();
    }

    public void PlaySlideDoorSound()
    {
        slideDoorAudioSource.Play();
    }

    public void StopMazeBaseBGM()
    {
        MazeBaseAudioSource.Stop();
    }    
    
    public void PlayWinBGM()
    {
        playWinBGMAudioSource.Play();
    }

    public void PlayLoseBGM()
    {
        playLoseBGMAudioSource.Play();
    }

    public void PlayLoseSFX()
    {
        playLoseSFXAudioSource.Play();
    }
}
