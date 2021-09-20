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
    public float movesSpeed;
    Vector3 lastPos;
    public bool isWalking;
    public bool isSlowDown;
    public Animator boyAC;
    // Start is called before the first frame update

    float timer = 0.4f;
    float time = 0;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination1.transform.position);
        boyAC = GetComponentInChildren<Animator>();
        StartCoroutine(CalcVelocity());

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

        if (movesSpeed > 0.01)
        {
            isWalking = true;
            boyAC.SetBool("isWalking", true);
        }
        else
        {
            isWalking = false;
            boyAC.SetBool("isWalking", false);
        }

        if (isWalking)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                int i = Random.Range(0, footSteps.Length);
                audioSource.clip = footSteps[i];
                audioSource.Play();
                // play
                time = timer;
            }
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
    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            lastPos = transform.position;
            yield return new WaitForFixedUpdate();
            movesSpeed = Vector3.Distance(transform.position, lastPos) / Time.fixedDeltaTime;
        }

    }


}
