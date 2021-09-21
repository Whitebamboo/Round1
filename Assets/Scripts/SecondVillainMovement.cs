using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondVillainMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float alertDistance;
    public float waitTime;

    public float patrolRange;
    public bool isPatroling;
    public bool isAlert;
    public Vector3 DesiredPosition;
    Vector3 lastPos;
    float rePatrolTime = 2f;
    public float movesSpeed;

    public AudioClip[] nightmareSounds;
    public AudioSource audioSource;
    public Animator nightmareAC;
    public Material fadingMaterial;
    public GameObject target;
    public NavMeshAgent agent;

    private bool WITSound2Played;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
/*        agent = GetComponentInParent<NavMeshAgent>();*/
        /*nightmareAC = GetComponent<Animator>();*/
        target = GameObject.FindGameObjectWithTag("MainCharacter");
        isPatroling = false;
        StartCoroutine(CalcVelocity());
        WITSound2Played = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (!isPatroling && !isAlert)
        {
            Patrol();
        }
        if (isPatroling == true)
        {
            rePatrolTime -= Time.deltaTime;
            if(rePatrolTime < 0)
            {
                isPatroling = false;
                rePatrolTime = 4f;

            }
        }
        if (movesSpeed > 0.01)
        {
            nightmareAC.SetBool("isMoving", true);
        }
        else
        {
            nightmareAC.SetBool("isMoving", false);
        }
        //checking whether the villain is patrol or chase the target after get alerted
        if (distance < alertDistance)
        {
            if (!WITSound2Played)
            {
                SoundManage.Instance.PlayWITSound2();
                WITSound2Played = true;
            }
            agent.SetDestination(target.transform.position);
            isAlert = true;
        }
        else
        {
            isAlert = false;
        }
    }
    public void Patrol()
    {

        Vector3 RandomPosition = new Vector3(Random.Range(-patrolRange, patrolRange), 0, Random.Range(-patrolRange, patrolRange));
/*        Debug.Log(RandomPosition);*/
        DesiredPosition = transform.position + RandomPosition;
        agent.SetDestination(DesiredPosition);
        isPatroling = true;
        /*        Debug.Log(DesiredPosition);*/
        //check if the desiredposion lands on the map
        /*        int layermask = 1 << 6;
                layermask = ~layermask;*/
        /*        RaycastHit hit;
                if (Physics.Raycast(DesiredPosition, -Vector3.up, out hit, 1f))
                {
        *//*            Debug.Log("Hit");*//*
                    if (!Physics.CheckSphere(DesiredPosition, 0.01f))
                    {
        *//*                Debug.Log("Did not collided");*//*
                        agent.SetDestination(DesiredPosition);
                        isPatroling = true;
                    }
                    else
                    {
        *//*                Debug.Log("collided");*//*
                    }
                }*/
    }
/*    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("MainCharacter"))
        {
            nightmareAC.SetTrigger("Attack");
            audioSource.clip = nightmareSounds[0];
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = fadingMaterial;
            fadingMaterial.SetFloat("_FadeStartTime", Time.time);
            audioSource.Play();
        }
    }*/

    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            lastPos = transform.position;
            yield return new WaitForFixedUpdate();
            movesSpeed = Vector3.Distance(transform.position, lastPos) / Time.fixedDeltaTime;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, alertDistance);
    }
}
