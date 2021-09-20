using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 90;
    public static int currentHealth;

    [SerializeField] private Volume volume;
    [SerializeField] private VolumeProfile volumeProfile_1;
    [SerializeField] private VolumeProfile volumeProfile_2;
    [SerializeField] private VolumeProfile volumeProfile_3;

    public static bool winStatus;

    NavMeshAgent agent;
    public bool isSlowDown;
    public bool gethurt;
    float getHurtTime;
    public float hurtDuration;
    float time;
    public float slowDownDuration;
    public Animator boyAC;
    public BoxMovement playermovement;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        boyAC = GetComponentInChildren<Animator>();
        isSlowDown = false;
        gethurt = false;
        hurtDuration = 2f;
        getHurtTime = hurtDuration;
        slowDownDuration = 5f;
        time = slowDownDuration;
        winStatus = true;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthStatus();
        if (isSlowDown)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                agent.speed = 0.07f;
                agent.acceleration = 0.3f;
                boyAC.speed = 1f;
                // play
                time = slowDownDuration;
                isSlowDown = false;
            }
        }
        if (gethurt)
        {
            getHurtTime -= Time.deltaTime;
            if (getHurtTime < 0)
            {
                boyAC.SetBool("GetHurt", false);
                agent.speed = 0.07f;
                agent.acceleration = 0.3f;
                // play
                getHurtTime = hurtDuration;
                gethurt = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nightmare"))
        {
            TakeDamage(30);
            SoundManage.Instance.PlayScreamingSound();
            SoundManage.Instance.PlayAttackedSound();
            GetHurt();
            Destroy(collision.gameObject,2f);
            collision.gameObject.GetComponent<VillainMovement>().enabled = false;
        }

        if (collision.gameObject.CompareTag("NightmareSec"))
        {
            isSlowDown = true;
            gethurt = true;
            boyAC.SetBool("GetHurt", true);
            agent.speed = 0.035f;
            agent.acceleration = 0.15f;
            boyAC.speed = 0.5f;
            Destroy(collision.gameObject, 2f);
            collision.gameObject.GetComponent<SecondVillainMovement>().enabled = false;
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    private void GetHurt()
    {
        gethurt = true;
        boyAC.SetBool("GetHurt",true);
        agent.velocity = new Vector3(0,0,0);
        agent.speed = 0f;
        agent.acceleration = 0f;
    }


    private void healthStatus()
    {
        if (currentHealth == 90)
        {
            volume.profile = volumeProfile_1;
        }
        else if (currentHealth == 60)
        {
            volume.profile = volumeProfile_2;
        }
        else if (currentHealth == 30)
        {
            volume.profile = volumeProfile_3;
        }
        else if (currentHealth == 0)
        {
            winStatus = false;
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.CompareTag("Destination"))
        {
            SceneManager.LoadScene(2);
        }
        else if (other.CompareTag("HelpSoundTrigger"))
        {
            SoundManage.Instance.PlayHelpSound();
        }
    }

}
