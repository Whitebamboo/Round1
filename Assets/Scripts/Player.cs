using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 90;
    public int currentHealth;

    [SerializeField] private Volume volume;
    [SerializeField] private VolumeProfile volumeProfile_1;
    [SerializeField] private VolumeProfile volumeProfile_2;
    [SerializeField] private VolumeProfile volumeProfile_3;

    public static bool winStatus; 


    // Start is called before the first frame update
    void Start()
    {
        winStatus = true;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthStatus();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Nightmare"))
        {
            TakeDamage(30);
            Destroy(collision.gameObject,3f);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
        if(other.CompareTag("Destination")){
            SceneManager.LoadScene(2);
        }
    }
}
