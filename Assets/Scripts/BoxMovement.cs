using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoxMovement : MonoBehaviour
{
    public GameObject destination1;
    /*    public GameObject destination2;*/

    public AudioClip[] footSteps;
    public AudioSource audioSource;
    public float distanceToP1;
    public float distanceToP2;
    NavMeshAgent agent;
    // Start is called before the first frame update

    float timer = 0.4f;
    float time = 0;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination1.transform.position);

        time = timer;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("footstepSound");
        /*        distanceToP1 = Vector3.Distance(destination1.transform.position, transform.position);
                distanceToP2 = Vector3.Distance(destination2.transform.position, transform.position);
                if (distanceToP1 < 0.05f)
                {
                    agent.SetDestination(destination2.transform.position);
                }
                if(distanceToP2 < 0.05f)
                {
                    agent.SetDestination(destination1.transform.position);
                }*/

        time -= Time.deltaTime;
        
        if(time < 0)
        {
            int i = Random.Range(0, footSteps.Length);
            audioSource.clip = footSteps[i];
            audioSource.Play();
            // play
            time = timer;
        }
    }

   private IEnumerator footstepSound()
    {
        if (!audioSource.isPlaying)
        {
            int i = Random.Range(0, footSteps.Length);
            audioSource.clip = footSteps[i];
            audioSource.Play();
            yield return new WaitForSeconds(.5f);
            Debug.Log("Sound");
        }
    }
}
