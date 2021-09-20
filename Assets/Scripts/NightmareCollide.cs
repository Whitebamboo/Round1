using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareCollide : MonoBehaviour
{
    public AudioClip[] nightmareSounds;
    public AudioSource audioSource;
    public Material fadingMaterial1;
    public Material fadingMaterial2;
    public Animator nightmareAC;
    public GameObject children;

    public bool isChanged;
    // Start is called before the first frame update
    void Start()
    {
        isChanged = false;
        audioSource = GetComponent<AudioSource>();
        if (gameObject.tag == "Nightmare")
        {
            nightmareAC = gameObject.GetComponent<Animator>();
        }
        if (gameObject.tag == "NightmareSec")
        {
            nightmareAC = gameObject.GetComponentInChildren<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainCharacter"))
        {
            nightmareAC.SetTrigger("Attack");
            audioSource.clip = nightmareSounds[0];
            audioSource.Play();
            if (gameObject.tag == "Nightmare")
            {
                StartCoroutine("dissolveOne");
            }
            if (gameObject.tag == "NightmareSec")
            {
                StartCoroutine("dissolveTwo");
            }
        }
    }

    private IEnumerator dissolveOne()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = fadingMaterial1;
        fadingMaterial1.SetFloat("_FadeStartTime", Time.time);
    }
    private IEnumerator dissolveTwo()
    {
        yield return new WaitForSeconds(1f);
        children.GetComponent<SkinnedMeshRenderer>().material = fadingMaterial1;
        fadingMaterial1.SetFloat("_FadeStartTime", Time.time);
    }

}
